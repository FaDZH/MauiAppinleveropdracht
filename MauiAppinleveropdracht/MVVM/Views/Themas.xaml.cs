namespace MauiAppinleveropdracht;

public partial class Themas : ContentPage
{
    public Themas()
    {
        InitializeComponent();
    }

    private void OnButtonClicked(object sender, EventArgs e)
    {
        //hier haalt die het tekst dat op het button staat mee 
        var button = sender as Button;
        var selectedTheme = button?.Text ?? "Geen thema";

        Navigation.PushAsync(new Spelmenu(selectedTheme));
    }
}