using System;
using System.IO;
using System.Linq;

namespace the_long_game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hey there! Please enter your name below.");
            string userName = Console.ReadLine();

            string docPath = @$"userFiles\{userName}.txt"; //path to this user's file
            int lastScore = int.Parse(File.ReadAllLines(docPath).Last()); //get most recent score
            //int playerScore = 0;
            int newScore = KeyCount(lastScore);

            if (!File.Exists(docPath)) //if this userName has NOT already been entered
            {
                Directory.CreateDirectory("userFiles"); //create if directory does not already exist
                using (FileStream fs = File.Create(docPath)) { } //open and close FileStream

                using (StreamWriter sw = new StreamWriter(docPath))
                {
                    sw.WriteLine(userName);
                    sw.WriteLine("0"); //every player starts at 0
                }
            }

            using (StreamWriter streamWriter = new StreamWriter(docPath, true))
            {
                //playerScore = newScore + lastScore;
                streamWriter.WriteLine(lastScore); //update score
            }
        }

        /*
         * KeyCount: main game function. takes previous playerScore
         * every key press increments score by 1
         * pressing 'enter' ends the game
         * returns updated playerScore
         */
        static int KeyCount(int playerScore)
        {
            Console.WriteLine($"Starting Score: {playerScore}");
            Console.WriteLine("Press any key to increase your score!");

            bool notEnter = true;

            while (notEnter)
            {
                if (Console.ReadKey().Key == ConsoleKey.Enter)
                {
                    Console.WriteLine("Game Over");
                    notEnter = false;
                }
                else
                {
                    playerScore += 1;
                    Console.WriteLine($"\nScore: {playerScore}");
                }
            }

            return playerScore;
        }
    }
}
