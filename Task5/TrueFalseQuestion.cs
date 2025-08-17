using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5
{

    class TrueFalseQuestion : Question
    {
        public bool CorrectAnswer { get; set;}

        public override void Display()
        {
            Console.WriteLine(Text);
            Console.WriteLine("Type your answer (True / False) : ");
        }

        public override bool CheckAnswer(string answer)
        {
            string trimmingSpaces = answer.Trim().ToLower();

            bool userTakeTrue = (trimmingSpaces == "true");

            if (userTakeTrue == CorrectAnswer)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
