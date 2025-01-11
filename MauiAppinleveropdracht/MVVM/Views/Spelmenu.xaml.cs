using MauiAppinleveropdracht;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace MauiAppinleveropdracht;

public partial class Spelmenu : ContentPage
{
    public ObservableCollection<string> Players { get; private set; } = new ObservableCollection<string>();

    private string _selectedTheme;
    private string _currentUserName;

    public Spelmenu(string currentUserName, string selectedTheme = "Geen thema")
    {
        InitializeComponent();

        _currentUserName = currentUserName;
        _selectedTheme = selectedTheme;

        ThemeLabel.Text = $"Gekozen thema: {_selectedTheme}";

        // Voegt hier gebruiker toe als eerste speler (oftewel naam waarmee gebruikeri ngelogd is)
        Players.Add(_currentUserName);

        // bind het lijst van spelers aan CollectionView
        PlayersListView.ItemsSource = Players;
    }

    private void AddPlayerButton_Clicked(object sender, EventArgs e)
    {
        string playerName = PlayerNameEntry.Text?.Trim();

        if (string.IsNullOrEmpty(playerName))
        {
            DisplayAlert("Fout", "Voer een geldige spelernaam in.", "OK");
            return;
        }

        if (Players.Contains(playerName))
        {
            DisplayAlert("Fout", "Deze speler is al toegevoegd.", "OK");
            return;
        }

        Players.Add(playerName);
        PlayerNameEntry.Text = string.Empty; // Maakt het invoerveld leeg
    }

    private void RemovePlayerButton_Clicked(object sender, EventArgs e)
    {
        var selectedPlayer = PlayersListView.SelectedItem as string;

        if (string.IsNullOrEmpty(selectedPlayer))
        {
            DisplayAlert("Fout", "Selecteer een speler om te verwijderen.", "OK");
            return;
        }

        if (selectedPlayer == _currentUserName)
        {
            DisplayAlert("Fout", "Je kunt jezelf niet verwijderen.", "OK");
            return;
        }

        Players.Remove(selectedPlayer);
    }

    private async void StartButton_Clicked(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(_selectedTheme) || _selectedTheme == "Geen thema")
        {
            await DisplayAlert("Fout", "Je moet een thema kiezen voordat je het spel kunt starten.", "OK");
            return;
        }

        if (Players.Count == 0)
        {
            await DisplayAlert("Fout", "Voeg minimaal één speler toe om te starten.", "OK");
            return;
        }

        // Start het spel met het geselecteerde thema
        await Navigation.PushAsync(new TruthOrDrinkPage(Players.ToList(), _selectedTheme));
    }


    private async void InviteButton_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Invitemenu());
    }

    private async void ThemaButton_Clicked(object sender, EventArgs e)
    {
        // Maakt een nieuwe themapagina
        var themasPage = new Themas();

        // Navigeert naar de themapagina
        await Navigation.PushAsync(themasPage);

        // Wacht totdat gebruiker iets heeft geselecteerd
        string selectedTheme = await themasPage.ThemeSelectionTask.Task;

        // controleert of er een thema is gekozenn en slaat die op
        if (!string.IsNullOrEmpty(selectedTheme))
        {
            _selectedTheme = selectedTheme; 
            ThemeLabel.Text = $"Gekozen thema: {selectedTheme}";
        }
    }



}
