using MauiAppinleveropdracht.MVVM.Viewmodels;

namespace MauiAppinleveropdracht;

public partial class TruthOrDrinkPage : ContentPage
{
    private readonly TruthOrDrinkGame _game;
    private readonly List<string> _players;
    private int _currentPlayerIndex;

    public TruthOrDrinkPage(List<string> players)
    {
        InitializeComponent();
        _game = new TruthOrDrinkGame();
        _players = players;
        _currentPlayerIndex = 0;

        LoadNextQuestion();
    }

    private void LoadNextQuestion()
    {
        string currentPlayer = _players[_currentPlayerIndex];
        string nextQuestion = _game.GetNextQuestion();

        QuestionLabel.Text = $"{currentPlayer}'s beurt: {nextQuestion}";
        _currentPlayerIndex = (_currentPlayerIndex + 1) % _players.Count;
    }

    private void OnTruthClicked(object sender, EventArgs e)
    {
        LoadNextQuestion();
    }

    private void OnDrinkClicked(object sender, EventArgs e)
    {
        LoadNextQuestion();
    }
}
