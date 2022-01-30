using System;
using System.IO;
using System.Threading;
using System.Media;
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
            SoundPlayer Player = new SoundPlayer("Guy screaming meme.wav");
            bool death = false;
            int rounds = 1;
            int round = 1;
            int endscore = 0;
            string text = "";
            while (true)
            {
                Player.PlayLooping();
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
                                    round++;
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
                                    round++;
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
                                    round++;
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
                        Player.Stop();
                        SoundPlayer Death = new SoundPlayer("lego-yoda-death-sound-effect.wav");
                        Death.Play();
                        var path = "score.txt";
                        if(!(File.Exists(path)))
                        {
                            File.Create(path).Close();
                            File.WriteAllText(path, text);
                        }
                        string textfil = File.ReadAllText(path);
                        try
                        {
                            int convertion = int.Parse(textfil);
                            if (convertion < endscore)
                            {
                                convertion = endscore;
                                textfil = Convert.ToString(convertion);
                                File.WriteAllText(path, textfil);
                            }

                        }
                        catch
                        {
                            if (textfil.Length == 0)
                            {
                                if(round == 1)
                                {
                                    File.WriteAllText(path, "0");
                                }
                                else
                                {
                                    File.WriteAllText(path, text);
                                }
                            }
                        }

                        Console.Write("Clear score yes/no: ");
                        string result = Console.ReadLine();
                        if (result == "yes")
                        {
                            File.WriteAllText(path, "0");
                        }
                        else
                        {
                            Console.WriteLine("Ok!");
                        }

                        string readtextfile = File.ReadAllText(path);



                        Console.Clear();
                        Console.WriteLine("Your Score: " + endscore + " HighScore: " + readtextfile);
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
