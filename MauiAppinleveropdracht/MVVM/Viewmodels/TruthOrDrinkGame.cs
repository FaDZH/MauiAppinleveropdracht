namespace MauiAppinleveropdracht
{
    public class TruthOrDrinkGame
    {
        private readonly string _theme;
        private readonly API _api;
        private readonly List<Question> _defaultQuestions;
        private int _currentDefaultIndex;

        public TruthOrDrinkGame(string theme)
        {
            _theme = theme;
            _api = new API();
            _defaultQuestions = new List<Question>
            {
                new Question { Text = "Who was your first crush?", RequiresPhoto = false },
                new Question { Text = "What is your favorite selfie that you’ve ever taken? Show it to the group.", RequiresPhoto = true },
                new Question { Text = "Have you ever cheated on a test?", RequiresPhoto = false },
                new Question { Text = "Choose a photo where you think you look good and show it to the group.", RequiresPhoto = true },
                new Question { Text = "What is your biggest fear?", RequiresPhoto = false },
                new Question { Text = "Pick a photo from your phone that represents a special moment and share the story behind it.", RequiresPhoto = true },
                new Question { Text = "What is the oldest photo on your phone? Show it to the group.", RequiresPhoto = true },
                new Question { Text = "Show the first photo in your gallery. What does it mean to you?", RequiresPhoto = true },
                new Question { Text = "What’s your most embarrassing habit?", RequiresPhoto = false },
                new Question { Text = "What is the most embarrassing photo on your phone?", RequiresPhoto = true },
                new Question { Text = "Have you ever lied to your best friend?", RequiresPhoto = false },
                new Question { Text = "Show a photo of your pet (or a cute animal photo if you don’t have a pet).", RequiresPhoto = true },
                new Question { Text = "If you could change one thing about yourself, what would it be?", RequiresPhoto = false },
                new Question { Text = "Show a photo of the last vacation you went on. Where were you?", RequiresPhoto = true },
                new Question { Text = "What is the most embarrassing thing you've ever done?", RequiresPhoto = false },
                new Question { Text = "Have you ever stolen something?", RequiresPhoto = false },
                new Question { Text = "What’s something you’ve never told anyone?", RequiresPhoto = false },
                new Question { Text = "Pick a photo you’d never post online and show it to the group.", RequiresPhoto = true },
                new Question { Text = "Show a photo of a meal you cooked. How did it turn out?", RequiresPhoto = true },
                new Question { Text = "What's the most trouble you've ever gotten into?", RequiresPhoto = false }
            };

            _currentDefaultIndex = 0;
        }

        public async Task<Question> GetNextQuestionAsync()
        {
            if (_theme == "Special")
            {
                var specialQuestion = await _api.GetSpecialQuestionAsync();
                return new Question { Text = specialQuestion, RequiresPhoto = false }; //zodat de vragen die van Api komen geen foto uit gallerij functie hebben
            }
            else if (_theme == "Default")
            {
                if (_defaultQuestions.Count == 0)
                {
                    return new Question { Text = "Geen standaardvragen beschikbaar.", RequiresPhoto = false };
                }

                var question = _defaultQuestions[_currentDefaultIndex];
                _currentDefaultIndex = (_currentDefaultIndex + 1) % _defaultQuestions.Count;
                return question;
            }

            return new Question { Text = "Geen vragen beschikbaar voor dit thema.", RequiresPhoto = false };
        }
    }

    public class Question
    {
        public string Text { get; set; }
        public bool RequiresPhoto { get; set; }
    }
}
