using MauiAppinleveropdracht;
using System.Diagnostics;

namespace MauiAppinleveropdracht;

public partial class Spelmenu : ContentPage
{
    private string _selectedTheme;

    public Spelmenu(string selectedTheme = "Geen thema")
    {
        InitializeComponent();

        //dit is voor het opslaan van gekozen thema en het laten zien 
        _selectedTheme = selectedTheme;
        ThemeLabel.Text = $"Gekozen thema: {_selectedTheme}";
    }

    private void InviteButton_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new Invitemenu());
    }

    private void ThemaButton_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new Themas());
    }
}