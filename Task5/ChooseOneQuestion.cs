using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5
{
    class ChooseOneQuestion : Question
    {
        public List<string> Options { get; set; } = new List<string>();
        public int CorrectIndex { get; set; }

        public override void Display()
        {
            Console.WriteLine(Text);
            for (int i = 0; i < Options.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {Options[i]}");
            }
        }

        public override bool CheckAnswer(string answer)
        {
            string trimmingSpaces = answer.Trim();
            int selected = int.Parse(trimmingSpaces);
            int index = selected - 1;

            if (index == CorrectIndex)
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
