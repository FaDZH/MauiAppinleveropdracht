using MauiAppinleveropdracht.MVVM.Viewmodels;

namespace MauiAppinleveropdracht;

public partial class TruthOrDrinkPage : ContentPage
{
    private readonly TruthOrDrinkGame _game;

    public TruthOrDrinkPage()
    {
        InitializeComponent();
        _game = new TruthOrDrinkGame();
        LoadNextQuestion();
    }

    private void LoadNextQuestion()
    {
        var nextQuestion = _game.GetNextQuestion();
        QuestionLabel.Text = nextQuestion;
    }

    private void OnTruthClicked(object sender, EventArgs e)
    {
        // Laad de volgende vraag nadat gebruiker op truth klikt
        LoadNextQuestion();
    }

    private void OnDrinkClicked(object sender, EventArgs e)
    {
        // Laad de volgende vraag na het klikken van drink
        LoadNextQuestion();
    }
}
