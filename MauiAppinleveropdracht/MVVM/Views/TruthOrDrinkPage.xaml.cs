using System.Collections.Generic;
using Microsoft.Maui.Devices;
using Microsoft.Maui.ApplicationModel;

namespace MauiAppinleveropdracht;

public partial class TruthOrDrinkPage : ContentPage
{
    private readonly TruthOrDrinkGame _game;
    private readonly List<string> _players;
    private int _currentPlayerIndex;
    private int _drinkCount;
    private Question _currentQuestion;

    public TruthOrDrinkPage(List<string> players, string theme)
    {
        InitializeComponent();
        _players = players;
        _game = new TruthOrDrinkGame(theme);
        _currentPlayerIndex = 0;
        _drinkCount = 0;

        _ = LoadNextQuestionAsync();
    }

    private async Task LoadNextQuestionAsync()
    {
        _currentQuestion = await _game.GetNextQuestionAsync();

        string currentPlayer = _players[_currentPlayerIndex];
        QuestionLabel.Text = $"{currentPlayer}'s beurt: {_currentQuestion.Text}";
        _currentPlayerIndex = (_currentPlayerIndex + 1) % _players.Count;

        //controleert eerst of de vraag een foto vereist en doet pas daarna de zichtbaarheid van de knoppen aan
        if (_currentQuestion.RequiresPhoto)
        {
            TruthButton.IsVisible = false;
            DrinkButton.IsVisible = false;
            OpenGalleryButton.IsVisible = true;
        }
        else
        {
            TruthButton.IsVisible = true;
            DrinkButton.IsVisible = true;
            OpenGalleryButton.IsVisible = false;
        }
    }

    private async void OnTruthClicked(object sender, EventArgs e)
    {
        await LoadNextQuestionAsync();
    }

    private async void OnDrinkClicked(object sender, EventArgs e)
    {
        _drinkCount++;

        if (_drinkCount >= 5)
        {
            ShowDrinkWarning();
            _drinkCount = 0;
        }

        await LoadNextQuestionAsync();
    }

    private async void OnOpenGalleryClicked(object sender, EventArgs e)
    {
        //opent het galerij en laat de gebruiker een foto kiezen
        var result = await FilePicker.Default.PickAsync(new PickOptions
        {
            PickerTitle = "Kies een foto",
            FileTypes = FilePickerFileType.Images
        });

        if (result != null)
        {
            Console.WriteLine($"Foto gekozen: {result.FullPath}");

            await DisplayAlert("Foto Gekozen", "Je hebt een foto gekozen. Volgende vraag wordt geladen.", "OK");
        }
        else
        {
            Console.WriteLine("Geen foto geselecteerd.");
        }

        await LoadNextQuestionAsync();
    }

    private async void ShowDrinkWarning()
    {
        if (Vibration.Default.IsSupported)
        {
            Console.WriteLine("Vibratie gestart voor 1 seconde."); // checken of het vibratie werkt door debug te gebruiken
            Vibration.Default.Vibrate(TimeSpan.FromSeconds(1));
        }
        else
        {
            Console.WriteLine("Vibratie wordt niet ondersteund op dit apparaat.");
        }

        await DisplayAlert("Rustig aan!", "Je hebt te vaak achter elkaar op 'Drink' geklikt. Neem een pauze!", "OK");
    }
}
