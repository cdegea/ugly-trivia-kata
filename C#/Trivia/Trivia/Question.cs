using System;
using System.Collections.Generic;
using System.Linq;

namespace Trivia
{
    public class Question
    {
        private List<string> items;

        public Question(string category)
        {
            items = new List<string>();
            GenerateQuestions(category);
        }

        private void GenerateQuestions(string category)
        {
            for (var i = 0; i < 50; i++)
            {
                items.Add($"{category} Question {i}");
            }
        }

        public void GetNextQuestion()
        {
            Console.WriteLine(this.items.First());
            this.items.RemoveAt(0);
        }
    }
}