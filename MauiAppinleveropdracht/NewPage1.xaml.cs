namespace MauiAppinleveropdracht;

public partial class NewPage1 : ContentPage
{
	public NewPage1()
	{
		InitializeComponent();
	}

    private void SpelenButton_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new Spelmenu());

    }
}