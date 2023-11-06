using XML_Manager;

namespace GUI;

public partial class MainPage : ContentPage
{
	private FilterOptions CollectFilters()
	{
		var filters = new FilterOptions();
		if (TitleCheckbox.IsChecked)
		{
			filters.Title = TitleEntry.Text ?? "";
		}

		if (DescriptionCheckbox.IsChecked)
		{
			filters.Description = DescriptionEntry.Text ?? "";
		}

		if (AuthorCheckbox.IsChecked)
		{
			filters.Author = AuthorEntry.Text ?? "";
		}

		if (GenreCheckbox.IsChecked)
		{
			filters.Genre = GenreEntry.Text ?? "";
		}

		if (YearCheckbox.IsChecked)
		{
			filters.Year = YearEntry.Text ?? "";
		}

		return filters;
	}

	private void ClearFilters()
	{
		TitleEntry.Text = "";
		TitleCheckbox.IsChecked = false;
		AuthorEntry.Text = "";
		AuthorCheckbox.IsChecked = false;
		GenreEntry.Text = "";
		GenreCheckbox.IsChecked = false;
		YearEntry.Text = "";
		YearCheckbox.IsChecked = false;
		DescriptionEntry.Text = "";
		DescriptionCheckbox.IsChecked = false;
	}

	private void ClearResults()
	{
		while (ResultsTable.Children.Count > 5) { ResultsTable.Children.RemoveAt(5); }
		while (ResultsTable.RowDefinitions.Count > 1) { ResultsTable.RowDefinitions.RemoveAt(1); }
	}

	private void CreateLabel(int row, int column, string text)
	{
		var label = new Label { Text = text, VerticalOptions = LayoutOptions.Center, HorizontalOptions = LayoutOptions.Center };
		ResultsTable.SetRow(label, row);
		ResultsTable.SetColumn(label, column);
		ResultsTable.Children.Add(label);
	}

	private void CreateButton(int row, string text)
	{
		var button = new Button { Text = "View", VerticalOptions = LayoutOptions.Center, HorizontalOptions = LayoutOptions.Center };
		button.Clicked += async (object sender, EventArgs e) => await DisplayAlert("Description", text, "Ok");
		ResultsTable.SetRow(button, row);
		ResultsTable.SetColumn(button, 4);
		ResultsTable.Children.Add(button);
	}

	private void DisplayResult(Book book, int row)
	{
		ResultsTable.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
		CreateLabel(row, 0, book.Title);
		CreateLabel(row, 1, book.Author.FirstName + " " + book.Author.LastName);
		CreateLabel(row, 2, book.Year);
		CreateLabel(row, 3, book.Genre);
		CreateButton(row, book.Description);
	}

	private async Task ValidateFile()
	{
		if (parser == null || ChosenFile == null) return;
		if (parser.Load(await ChosenFile.OpenReadAsync())) return;

		StatusLabel.Text = "File is not chosen";
		await DisplayAlert("Invalid file", "The file does not satisfy XSD Schema", "Ok");
	}
}
