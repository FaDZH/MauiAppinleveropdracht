using System.Collections.Generic;
using System.Threading.Tasks;

namespace MauiAppinleveropdracht
{
    public partial class TruthOrDrinkPage : ContentPage
    {
        private readonly TruthOrDrinkGame _game;
        private readonly List<string> _players;
        private int _currentPlayerIndex;

        public TruthOrDrinkPage(List<string> players, string theme)
        {
            InitializeComponent();
            _players = players;
            _game = new TruthOrDrinkGame(theme);
            _currentPlayerIndex = 0;

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
            await LoadNextQuestionAsync();
        }
    }
}
