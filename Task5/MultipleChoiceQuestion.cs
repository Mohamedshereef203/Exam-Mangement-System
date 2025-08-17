using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5
{
    class MultipleChoiceQuestion : Question
    {
        public List<string> Options { get; set; } = new List<string>();
        public List<int> CorrectIndex { get; set; } = new List<int>();

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
            List<int> selected = new List<int>();
            string[] parts = answer.Split(',');

            foreach (string part in parts)
            {
                string trimmingSpaces = part.Trim();
                int index = int.Parse(trimmingSpaces) - 1;
                selected.Add(index);
            }

            if (selected.Count != CorrectIndex.Count)
            {
                return false;
            }

            foreach (int index in selected)
            {
                if (!CorrectIndex.Contains(index))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
