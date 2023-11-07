namespace GUI;

public partial class MainPage : ContentPage
{
	private IParser parser;
	private FileResult ChosenFile;

	private readonly IFileSaver fileSaver;

	private IFilePicker filePicker;
	public MainPage()
	{
		InitializeComponent();
		fileSaver = FileSaver.Default;
		filePicker = FilePicker.Default;
		ParserPicker.SelectedIndex = 1;
	}
}
