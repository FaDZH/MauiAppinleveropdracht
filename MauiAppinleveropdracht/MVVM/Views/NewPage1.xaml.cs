namespace MauiAppinleveropdracht;

public partial class NewPage1 : ContentPage
{
	public NewPage1()
	{
		InitializeComponent();
	}

    private async void SpelenButton_Clicked(object sender, EventArgs e)
    {
        // pakt hier de gebruikersnaam die eerder is opgeslagen in App.CurrentUserName
        string currentUserName = App.CurrentUserName;

        await Navigation.PushAsync(new Spelmenu(currentUserName));
    }

}