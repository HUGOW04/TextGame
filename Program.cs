using System;
using System.IO;
using System.Threading;
namespace TextGame
{
    class Program
    {

        static void lore()
        {
            Console.WriteLine("You are inside a cave with 3 exits but one is the right one press 1 or 2 or 3");
            Console.Write("input your answer: ");
        }
        static string Play_again()
        {

            Console.Write("play again yes/no: ");
            string answer = Console.ReadLine();
            if (answer == "yes")
            {
                return "yes";
            }
            else if (answer == "no")
            {
                Environment.Exit(0);
                return "no";
            }
            else
            {
                return "Answer correcly dumbass!";
            }
        }
        static int pick()
        {
            string[] animal = { "Tiger", "Cobra", "Monke" };

            Random random = new Random();
            int num = random.Next(0, 10);
            if (num > 2)
            {
                Console.WriteLine("You survived");
                return num;

            }
            else
            {
                Console.WriteLine("You died to " + animal[num]);
                return num;
            }
        }
        static void Main(string[] args)
        {

            bool death = false;
            int rounds = 1;
            int endscore = 0;
            string text = "";
            while (true)
            {
                while (true)
                {
                    Console.Clear();
                    try
                    {
                        Console.WriteLine("Rounds: " + rounds);
                        lore();
                        int input = int.Parse(Console.ReadLine());
                        switch (input)
                        {
                            case 1:
                                if (pick() > 2)
                                {
                                    rounds++;
                                    endscore++;
                                    text = endscore.ToString();
                                }
                                else
                                {
                                    rounds = 1;
                                    death = true;

                                }
                                break;
                            case 2:
                                if (pick() > 2)
                                {
                                    rounds++;
                                    endscore++;
                                    text = endscore.ToString();

                                }
                                else
                                {
                                    rounds = 1;
                                    death = true;

                                }
                                break;
                            case 3:
                                if (pick() > 2)
                                {
                                    rounds++;
                                    endscore++;
                                    text = endscore.ToString();
                                }
                                else
                                {
                                    rounds = 1;
                                    death = true;

                                }
                                break;

                        }
                    }
                    catch
                    {
                        Console.WriteLine("You must input 1 or 2 or 3");
                    }
                    Thread.Sleep(1000);
                    while (death == true && rounds == 1)
                    {
                        var path = "score.txt";
                        string read = "";
                        read = Convert.ToString(endscore);
                        int score = Convert.ToInt32(read);
                        if(score < endscore)
                        {
                            score = endscore;
                            File.WriteAllText(path, read);
                        }
                        else if(File.ReadAllText(path)=="")
                        {
                            File.WriteAllText(path, read);
                        }
                        else if(score > endscore)
                        {
                            File.ReadAllText(path);
                        }


                        Console.Clear();
                        Console.WriteLine("Your Score: " + endscore + " HighScore: " + read);
                        Console.WriteLine("--------------");
                        if (Play_again() == "yes")
                        {
                            break;
                        }
                        else if (Play_again() == "no")
                        {
                            Environment.Exit(0);
                        }
                    }
                }

            }
        }

    }
}