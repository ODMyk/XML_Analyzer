using XML_Manager;
using CommunityToolkit.Maui.Storage;
using CommunityToolkit.Maui;

namespace GUI;

public partial class MainPage: ContentPage
{
    private IParser parser;
	private FileResult ChosenFile;

	private IFileSaver fileSaver;

	private IFilePicker filePicker;
	public MainPage()
	{
		InitializeComponent();
		fileSaver = FileSaver.Default;
		filePicker = FilePicker.Default;
		ParserPicker.SelectedIndex = 1;
	}
}
