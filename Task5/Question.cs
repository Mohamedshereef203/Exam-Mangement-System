using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5
{
    abstract class Question
    {
        public string Text { get; set; }
        public string Difficulty { get; set; }
        public int Score { get; set; }

        public abstract void Display();
        public abstract bool CheckAnswer(string answer);
    }
}
