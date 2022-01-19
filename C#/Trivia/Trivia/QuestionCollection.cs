using System.Collections.Generic;

namespace Trivia
{
    public class QuestionCollection
    {
        public readonly Question popQuestions = new Question("Pop");
        public readonly Question scienceQuestions = new Question("Science");
        public readonly Question sportsQuestions = new Question("Sports");
        public readonly Question rockQuestions = new Question("Rock");

        public QuestionCollection()
        {
            AddQuestions();
        }

        private void AddQuestions()
        {
            for (var i = 0; i < 50; i++)
            {
                popQuestions.AddItem("Pop Question " + i);
                scienceQuestions.AddItem("Science Question " + i);
                sportsQuestions.AddItem("Sports Question " + i);
                rockQuestions.AddItem("Rock Question " + i);
            }
        }
    }
}