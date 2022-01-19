using System.Collections.Generic;

namespace Trivia
{
    public class Question
    {
        private string category;
        private List<string> items;

        public Question(string category)
        {
            this.category = category;
            items = new List<string>();
        }

        public void AddItem(string itemName)
        {
            items.Add(itemName);
        }
    }
}