using XML_Manager;

namespace GUI;

public partial class MainPage: ContentPage
{
    private FilterOptions CollectFilters() {
		var filters = new FilterOptions();
		if (TitleCheckbox.IsChecked) {
			filters.Title = TitleEntry.Text;
		}

		if (DescriptionCheckbox.IsChecked) {
			filters.Description = DescriptionEntry.Text;
		}

		if (AuthorCheckbox.IsChecked) {
			filters.Author = AuthorEntry.Text;
		}

		if (GenreCheckbox.IsChecked) {
			filters.Genre = GenreEntry.Text;
		}

		if (YearCheckbox.IsChecked) {
			filters.Year = YearEntry.Text;
		}

		return filters;
	}

	private void ClearFilters() {
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

	private void ClearResults() {
		while (ResultsTable.Children.Count > 5) { ResultsTable.Children.RemoveAt(5); }
		while (ResultsTable.RowDefinitions.Count > 1) { ResultsTable.RowDefinitions.RemoveAt(1); }
	}
}