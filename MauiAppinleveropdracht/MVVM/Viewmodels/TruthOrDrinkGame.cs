using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiAppinleveropdracht;

public class TruthOrDrinkGame
{
    private readonly List<string> _questions;
    private int _currentQuestionIndex;

    public TruthOrDrinkGame(string theme)
    {
        _questions = GetQuestionsForTheme(theme);
        _currentQuestionIndex = 0;
    }

    private List<string> GetQuestionsForTheme(string theme)
    {
        if (theme == "Default")
        {
            return new List<string>
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
        }

        // dit is een tijdelijk solution voor als er op special wordt gedrukt bij themas, dan geeft die gwn lege lijst
        return new List<string>();
    }

    public string GetNextQuestion()
    {
        if (_questions.Count == 0)
        {
            return "deze werkt nog niet lololol";
        }

        if (_currentQuestionIndex >= _questions.Count)
            _currentQuestionIndex = 0;

        return _questions[_currentQuestionIndex++];
    }
}
