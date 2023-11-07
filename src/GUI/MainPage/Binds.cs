namespace GUI;

public partial class MainPage : ContentPage
{
	private async void ExitButton_Clicked(object _, EventArgs __)
	{
		var option = await DisplayAlert("Confirm exit", "Are you sure tou want to exit the program ?", "Yes", "No");
		if (option)
		{
			System.Environment.Exit(0);
		}
	}

	private async void OpenButton_Clicked(object _, EventArgs __)
	{
		var customFileType = new FilePickerFileType(
				new Dictionary<DevicePlatform, IEnumerable<string>>
				{
					{ DevicePlatform.Android, new[] { "text/xml" } },
				});
		var options = new PickOptions() { PickerTitle = "Select xml file with books", FileTypes = customFileType };
		ChosenFile = await filePicker.PickAsync(options);
		StatusLabel.Text = "Chosen file: " + ChosenFile.FileName;
		await ValidateFile();
	}

	private async void ExportButton_Clicked(object _, EventArgs __)
	{
		if (ChosenFile == null)
		{
			await DisplayAlert("Error", "Input file is not chosen", "I'm sorry");
			return;
		}

		using var stream = new MemoryStream(Encoding.Default.GetBytes(""));
		var result = await fileSaver.SaveAsync(ChosenFile.FileName.Split(".")[0] + ".html", stream, new CancellationTokenSource().Token);
		Exporter.Export(ChosenFile.FullPath, result.FilePath);
		await DisplayAlert("Success", "File was exported successfully", "Ok");
	}

	private async void FindButton_Clicked(object _, EventArgs __)
	{
		if (ChosenFile == null)
		{
			await DisplayAlert("Error", "Input file is not chosen", "I'm sorry");
			return;
		}

		if (parser == null)
		{
			await DisplayAlert("Error", "Parser type is not chosen", "I'm sorry");
			return;
		}

		var filterOptions = CollectFilters();
		ClearResults();

		var results = parser.Find(filterOptions);
		for (int i = 1; i <= results.Count; ++i)
		{
			DisplayResult(results[i - 1], i);
		}
	}

	private void ClearButton_Clicked(object _, EventArgs __)
	{
		ClearFilters();
	}

	private async void Parser_Selected(object _, EventArgs __)
	{
		switch (ParserPicker.SelectedIndex)
		{
			case 0:
				parser = new SAXParser();
				break;
			case 1:
				parser = new DOMParser();
				break;
			case 2:
				parser = new LINQParser();
				break;
		}
		await ValidateFile();
	}
}
