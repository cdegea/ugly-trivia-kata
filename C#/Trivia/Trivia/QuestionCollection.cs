using System;
using System.Collections.Generic;

namespace Trivia
{
    public class QuestionCollection
    {
        public Dictionary<string, Question> questions = new Dictionary<string, Question>();
        public string[] categories = {
            "Pop",
            "Science",
            "Sports",
            "Rock"
        };

        public QuestionCollection()
        {
            AddQuestions();
        }

        private void AddQuestions()
        {
            foreach (var categoryName in categories)
            {
                questions.Add(categoryName, new Question(categoryName));
            }
        }

        public void GetNextQuestion(string nextCategory)
        {
            if (questions.TryGetValue(nextCategory, out var question))
            {
                question.GetNextQuestion();
            }
        }
    }
}