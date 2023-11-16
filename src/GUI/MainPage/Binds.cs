﻿using XML_Manager;
using System.Text;
using System.Xml;
using System.Xml.Schema;

namespace GUI;

public partial class MainPage : ContentPage
{

	private async void ExitButton_Clicked(object sender, EventArgs e)
	{
		var option = await DisplayAlert("Confirm exit", "Are you sure tou want to exit the program ?", "Yes", "No");
		if (option)
		{
			System.Environment.Exit(0);
		}
	}

	private void ImportValidationSchema(string filepath)
	{
		var schema = new XmlSchemaSet();
		schema.Add("", filepath);

		validationSettings = new XmlReaderSettings
		{
			Schemas = schema
		};
		validationSettings.ValidationEventHandler += (object? sender, ValidationEventArgs e) =>
		{
			if (e.Severity == XmlSeverityType.Error) throw new Exception();
		};
		validationSettings.ValidationType = ValidationType.Schema;
	}
	private async void OpenButton_Clicked(object sender, EventArgs e)
	{
		if (validationSettings == null)
		{
			ImportValidationSchema("/storage/emulated/0/documents/books.xsd");
		}

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

	private async void ExportButton_Clicked(object sender, EventArgs e)
	{
		if (ChosenFile == null)
		{
			await DisplayAlert("Error", "Input file is not chosen", "I'm sorry");
			return;
		}

		if (exporter == null)
		{
			exporter = new();
			exporter.Load("/storage/emulated/0/documents/books.xsl");
		}

		using var stream = new MemoryStream(Encoding.Default.GetBytes(""));
		var result = await fileSaver.SaveAsync(ChosenFile.FileName.Split(".")[0] + ".html", stream, new CancellationTokenSource().Token);
		exporter.Transform(ChosenFile.FullPath, result.FilePath);
		await DisplayAlert("Success", "File was exported successfully", "Ok");
	}

	private async void FindButton_Clicked(object sender, EventArgs e)
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

	private void ClearButton_Clicked(object sender, EventArgs e)
	{
		ClearFilters();
	}

	private async void Parser_Selected(object sender, EventArgs e)
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
