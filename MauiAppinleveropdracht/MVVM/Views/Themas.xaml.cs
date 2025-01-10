namespace MauiAppinleveropdracht;

public partial class Themas : ContentPage
{
	public Themas()
	{
		InitializeComponent();
	}

    private void OnButtonClicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new Spelmenu());
    }

}