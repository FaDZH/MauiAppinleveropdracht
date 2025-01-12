using System.Collections.Generic;
using Microsoft.Maui.Devices;

namespace MauiAppinleveropdracht;

public partial class TruthOrDrinkPage : ContentPage
{
    private readonly TruthOrDrinkGame _game;
    private readonly List<string> _players;
    private int _currentPlayerIndex;
    private int _drinkCount; 

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
        string currentPlayer = _players[_currentPlayerIndex];
        string nextQuestion = await _game.GetNextQuestionAsync();

        QuestionLabel.Text = $"{currentPlayer}'s beurt: {nextQuestion}";
        _currentPlayerIndex = (_currentPlayerIndex + 1) % _players.Count;
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

    private async void ShowDrinkWarning()
    {
        if (Vibration.Default.IsSupported)
        {
            Console.WriteLine("Vibratie gestart voor 1 seconde."); //als dit bericht in console komt dan heb ik een indicatie dat het functie is gestart.
            Vibration.Default.Vibrate(TimeSpan.FromSeconds(1));
        }
        else
        {
            Console.WriteLine("Vibratie wordt niet ondersteund op dit apparaat."); //als ik het zonder dit deed ging mijn emulator steeds crashen dus ja.
        }

        await DisplayAlert("Rustig aan!", "Je hebt te vaak achter elkaar op 'Drink' geklikt. Neem een pauze!", "OK");
    }

}
