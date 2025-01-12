namespace MauiAppinleveropdracht
{
    public class TruthOrDrinkGame
    {
        private readonly string _theme;
        private readonly API _api;
        private readonly List<string> _defaultQuestions;
        private int _currentDefaultIndex;

        public TruthOrDrinkGame(string theme)
        {
            _theme = theme;
            _api = new API();
            _defaultQuestions = new List<string>
            {
                "What is the most embarrassing thing you've ever done?",
                "Have you ever cheated on a test?",
                "What is your biggest fear?",
                "Who was your first crush?",
                "Have you ever lied to your best friend?",
                "What's the most trouble you've ever gotten into?",
                "What’s something you’ve never told anyone?",
                "Have you ever stolen something?",
                "What’s your most embarrassing habit?",
                "If you could change one thing about yourself, what would it be?"
            };
            _currentDefaultIndex = 0;
        }

        public async Task<string> GetNextQuestionAsync()
        {
            if (_theme == "Special")
            {
                return await _api.GetSpecialQuestionAsync();
            }
            else if (_theme == "Default")
            {
                if (_defaultQuestions.Count == 0)
                {
                    return "Geen standaardvragen beschikbaar.";
                }

                var question = _defaultQuestions[_currentDefaultIndex];
                _currentDefaultIndex = (_currentDefaultIndex + 1) % _defaultQuestions.Count;
                return question;
            }

            return "Geen vragen beschikbaar voor dit thema.";
        }
    }
}