using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiAppinleveropdracht.MVVM.Viewmodels
{
    public class TruthOrDrinkGame
    {
        private readonly List<string> _questions;
        private int _currentQuestionIndex;

        public TruthOrDrinkGame()
        {
            _questions = new List<string>
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

            _currentQuestionIndex = 0;
        }

        public string GetNextQuestion()
        {
            if (_currentQuestionIndex >= _questions.Count)
                _currentQuestionIndex = 0; // Als vragen zijn geweest dan begint die opnieuw bij eerste vraag

            return _questions[_currentQuestionIndex++];
        }
    }
}
