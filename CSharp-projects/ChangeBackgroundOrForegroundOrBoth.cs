using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Enumarator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ChangeBackgroundOrForgroundChoice();
            Console.WriteLine(GetRandomString(200));
            Console.ReadKey();
        }


        enum enBackgroundOrForground
        {
            NONE,
            Background,
            Forground,
            BOTH
        }

        private static void PrintColors()
        {
            Console.WriteLine("Those Are The Valid Colors To Choice From:");
            foreach (System.ConsoleColor color in Enum.GetValues(typeof(System.ConsoleColor)))
            {
                Console.WriteLine($"{color} = {(byte)color}");
            }
        }

        private static byte BackgroundOrForgroundChoice()
        {
            byte userChoice = default(byte);
            bool invalidChoice = false;
            foreach (enBackgroundOrForground choice in Enum.GetValues(typeof(enBackgroundOrForground)))
            {
                Console.WriteLine($"{choice} = {(byte)choice}");
            }

            Console.Write("\nDo You Need To Change Background Or Forground?\n Enter Your Choice:");

            do
            {
                invalidChoice = (!byte.TryParse(Console.ReadLine(), out userChoice) || (!IsNumberBetween(userChoice, 0, 3)));
                if (invalidChoice)
                {
                    Console.Write("Enter A Valid Choice: ");
                }
            } while (invalidChoice);
            return userChoice;
        }

        private static bool IsNumberBetween(byte number, byte from, byte to) => number >= from && number <= to;

        private static ConsoleColor ColorChoice(string type)
        {
            string userColor;
            ConsoleColor targetColor = ConsoleColor.Black;
            byte maxEnumValue = (byte)Enum.GetValues(typeof(ConsoleColor)).Cast<ConsoleColor>().Max();
            byte minEnumValue = (byte)Enum.GetValues(typeof(ConsoleColor)).Cast<ConsoleColor>().Min();
            bool invalidChoice = false;

            Console.Write($"Please Enter A {type}Color:");
            do
            {
                userColor = Console.ReadLine();
                targetColor = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), userColor, true);
                invalidChoice = !IsNumberBetween((byte)targetColor, minEnumValue, maxEnumValue);
                if (invalidChoice)
                {
                    Console.Write($"Enter A Valid {type}Color: ");
                }

            } while (invalidChoice);
            return targetColor;
        }

        private static void ChangeBackgroundOrForgroundChoice()
        {
            PrintColors();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            enBackgroundOrForground choice = (enBackgroundOrForground)BackgroundOrForgroundChoice();


            switch (choice)
            {
                case enBackgroundOrForground.NONE:
                    break;

                case enBackgroundOrForground.Forground:
                    Console.ForegroundColor = ColorChoice("ForeGround");
                    break;

                case enBackgroundOrForground.Background:
                    Console.BackgroundColor = ColorChoice("Background");
                    break;

                case enBackgroundOrForground.BOTH:
                    Console.ForegroundColor = ColorChoice("ForeGround");
                    Console.BackgroundColor = ColorChoice("Background");
                    break;
            }
        }
        private static string GetRandomString(int length)
        {
            Random random = new Random();
            string randomString = "%";
            for (int i = 0; i < length; i++)
            {
                randomString += (random.Next((int)'a', (int)'z')).ToString();
            }
            return randomString;
        }
    }
}