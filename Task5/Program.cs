using System;

namespace Task5
{
   

    class Program
    {
        static void DoctorMode()
        {
            Console.Write("\n How many questions you want to put in the Exam : ");
            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                Console.WriteLine($"\n---- Question {i + 1} ---");

                Console.WriteLine("Choose question type:");
                Console.WriteLine("1. True or False");
                Console.WriteLine("2. Choose One");
                Console.WriteLine("3. Multiple Choice");
                string typeChoice = Console.ReadLine();

                Console.WriteLine("Choose difficulty:");
                Console.WriteLine("1. Easy");
                Console.WriteLine("2. Medium");
                Console.WriteLine("3. Hard");
                string diffChoice = Console.ReadLine();
                string difficulty;

                switch (diffChoice)
                {
                    case "1":
                        difficulty = "Easy";
                        break;
                    case "2":
                        difficulty = "Medium";
                        break;
                    case "3":
                        difficulty = "Hard";
                        break;
                    default:
                        difficulty = "Invalied Choice";
                        break;
                }

                Console.Write("Enter question text: ");
                string text = Console.ReadLine();

                Console.Write("Enter question score: ");
                int score = int.Parse(Console.ReadLine());

                Question q = null;

                if (typeChoice == "1")
                {
                    Console.Write("Enter correct answer (True/False): ");
                    string correct = Console.ReadLine().Trim().ToLower();

                    TrueFalseQuestion q1 = new TrueFalseQuestion();
                    q1.Text = text;
                    q1.Difficulty = difficulty;
                    q1.Score = score;
                    q1.CorrectAnswer = (correct == "true");
                    q = q1;
                }
                else if (typeChoice == "2")
                {
                    var options = new List<string>();
                    Console.WriteLine("Enter 4 options : ");

                    for (int j = 0; j < 4; j++)
                    {
                        Console.Write($"Option {j + 1}: ");
                        options.Add(Console.ReadLine());
                    }

                    Console.Write("Enter correct option number (1-4): ");
                    int correctIndex = int.Parse(Console.ReadLine()) - 1;

                    ChooseOneQuestion q1 = new ChooseOneQuestion();
                    q1.Text = text;
                    q1.Difficulty = difficulty;
                    q1.Score = score;
                    q1.Options = options;
                    q1.CorrectIndex = correctIndex;
                    q = q1;
                }
                else if (typeChoice == "3")
                {
                    var options = new List<string>();
                    Console.WriteLine("Enter 4 options:");
                    for (int j = 0; j < 4; j++)
                    {
                        Console.Write($"Option {j + 1}: ");
                        options.Add(Console.ReadLine());
                    }
 // لازم ندخل اكتر من اخيار صحيح                                                                    
                    Console.Write("Enter correct option numbers (Choice two option by using , between them  ) : ");
                    List<int> correctIndex = new List<int>();

                    string input = Console.ReadLine(); 
                    string[] parts = input.Split(','); 

                    foreach (string part in parts)
                    {
                        string trimmingSpaces = part.Trim(); 
                        int index = int.Parse(trimmingSpaces) - 1; 
                        correctIndex.Add(index); 
                    }

                    MultipleChoiceQuestion q1 = new MultipleChoiceQuestion();

                    q1.Text = text;
                    q1.Difficulty = difficulty;
                    q1.Score = score;
                    q1.Options = options;
                    q1.CorrectIndex = correctIndex;
                    q = q1;
                }

                if (q != null)
                  {
                    questions.Add(q);
                  }
            }

            Console.WriteLine("\n Questions added successfully");
        }

        static void StudentMode()
        {
            Console.WriteLine("\n Choose difficulty : ");
            Console.WriteLine("1. Easy ");
            Console.WriteLine("2. Medium ");
            Console.WriteLine("3. Hard ");
            string diffChoice = Console.ReadLine();
            string difficulty;

            switch (diffChoice)
            {
                case "1":
                    difficulty = "Easy";
                    break;
                case "2":
                    difficulty = "Medium";
                    break;
                case "3":
                    difficulty = "Hard";
                    break;
                default:
                    difficulty = "Unknown";
                    break;
            }

            List<Question> selectedQuestions = new List<Question>();

            foreach (Question q in questions)
            {
                if (q.Difficulty == difficulty)
                {
                    selectedQuestions.Add(q);
                }
            }

            if (selectedQuestions.Count == 0)
            {
                Console.WriteLine("No questions available for this difficulty.");
                return;
            }

            int totalScore = 0;
            int earnedScore = 0;

            foreach (var q in selectedQuestions)
            {
                Console.WriteLine();
                q.Display();
                Console.Write("Your answer: ");
                string answer = Console.ReadLine();

                bool isCorrect = q.CheckAnswer(answer);

                if (isCorrect)
                {
                    earnedScore = earnedScore + q.Score;
                }

                totalScore = totalScore + q.Score;
            }
            Console.WriteLine("Wishing all students success. Whoever cheats is not one of us.");

            Console.WriteLine($"\nYour final score: {earnedScore} From {totalScore}");
        }




        static List<Question> questions = new List<Question>();

        static void Main()
        {
            string choice;
            do
            {
                Console.WriteLine("Choose Mode : ");
                Console.WriteLine("1. Doctor Mode");
                Console.WriteLine("2. Student Mode");
                Console.WriteLine("3. Exit");
                Console.Write("Enter your choice : ");
                choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        DoctorMode();
                        break;
                    case "2":
                        StudentMode();
                        break;
                    case "3":
                        Console.WriteLine("Thank you for using my program ");
                        break;
                    default:
                        Console.WriteLine("Invalid choice");
                        break;
                }

            } while (choice != "3");
        }

       
    }
}
