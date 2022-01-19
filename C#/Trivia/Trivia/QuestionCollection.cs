using System.Collections.Generic;

namespace Trivia
{
    public class QuestionCollection
    {
        public readonly LinkedList<string> popQuestions = new LinkedList<string>();
        public readonly LinkedList<string> scienceQuestions = new LinkedList<string>();
        public readonly LinkedList<string> sportsQuestions = new LinkedList<string>();
        public readonly LinkedList<string> rockQuestions = new LinkedList<string>();

        public QuestionCollection()
        {
            AddQuestions();
        }

        private void AddQuestions()
        {
            for (var i = 0; i < 50; i++)
            {
                popQuestions.AddLast("Pop Question " + i);
                scienceQuestions.AddLast("Science Question " + i);
                sportsQuestions.AddLast("Sports Question " + i);
                rockQuestions.AddLast("Rock Question " + i);
            }
        }
    }
}