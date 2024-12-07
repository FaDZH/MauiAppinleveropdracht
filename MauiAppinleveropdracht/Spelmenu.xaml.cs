namespace MauiAppinleveropdracht;

public partial class Spelmenu : ContentPage
{
	public Spelmenu()
	{
		InitializeComponent();
	}

    private void ThemaButton_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new Themas());
    }

    private void InviteButton_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new Invitemenu());

    }
}