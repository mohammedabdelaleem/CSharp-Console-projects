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
            char TryAgain = 'n';
          do
            {
                Console.Clear();
                LoadProgramTitle("Random Values Generator.");
                PerformUserChoice( ReadUserChoice());

                Console.Write("TryAgain[Y,N]: ");
                TryAgain=char.Parse(Console.ReadLine());
            } while (char.ToUpper(TryAgain)=='Y');

            Console.ReadKey();
        }


        private static void LoadProgramTitle(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Thread.Sleep(500);
            Console.Clear();
            Console.WriteLine(message + "..");
            Thread.Sleep(500);
            Console.Clear();
            Console.WriteLine(message + "....");
            Thread.Sleep(500);
            Console.Clear();
            Console.WriteLine(message + "......");
            Thread.Sleep(500);

            Console.ResetColor();
        }

        private static byte ReadUserChoice()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("[1]Generate Random Number    [2]Generate Random String");
            byte choice = default;
            bool isFalied = false;

            Console.Write("Enter Your Choice: ");
            do
            {
                isFalied = ((!byte.TryParse(Console.ReadLine(), out choice)) || (choice < 1 || choice > 2));
                if (isFalied) Console.WriteLine("Enter A Valid Choice: ");
            } while (isFalied);
            Console.ResetColor();
            return choice;
        }

        public static int GenerateRandoNmumberBetween(int min, int max)
        {
            Random rand = new Random();
            return rand.Next(min, max + 1);
        }

        private enum enPermission
        {
            All=0 ,CapitalLetter =1 , SmallLetter = 2 , Number=4 , SpecialCharacter=16
        }

        public const string Buffer = "ABCDEFGHIJKLMNOPQRSTUWXYZabcdefghijklmnopqrstuwxyz0123456789-*/=-!@#$%^&*()";
        private static StringBuilder GenerateRandomString(int length)
        {
            Random random = new Random();
            StringBuilder randomString = new StringBuilder("");
            int permissioins=0;

            SetPermission(ref permissioins);

            int i = 0;
            while(i<=length)
            {
                if (permissioins == (int)enPermission.All && i <= length)
                {
                    randomString.Append(Buffer[(random.Next(0, Buffer.Length - 1))]);
                    i++;
                }

                if ((((int)enPermission.CapitalLetter & permissioins) ==(int) enPermission.CapitalLetter) && i <= length)
                {
                    randomString.Append(Buffer[(random.Next(0, Buffer.IndexOf("a")))]);
                    i++;
                }

                if ((((int)enPermission.SmallLetter & permissioins) == (int)enPermission.SmallLetter) && i <= length)
                {
                    randomString.Append(Buffer[(random.Next(Buffer.IndexOf("a"), Buffer.IndexOf("z")+1))]);
                    i++;
                }

                if ((((int)enPermission.Number & permissioins) == (int)enPermission.Number) && i <= length)
                {
                    randomString.Append(Buffer[(random.Next(Buffer.IndexOf("0"), Buffer.IndexOf("9") + 1))]);
                    i++;
                }

                if ((((int)enPermission.SpecialCharacter & permissioins) == (int)enPermission.SpecialCharacter) && i <= length)
                {
                    randomString.Append(Buffer[(random.Next(Buffer.IndexOf("9")+1, Buffer.Length-1))]);
                    i++;
                }
            }

            return randomString;
        }

        private static void SetPermission(ref int Permission)
        {
            char choice = 'n';


            Console.WriteLine("[0]String Include All Types Of Character");
            choice = char.Parse(Console.ReadLine());
            if (char.ToUpper(choice) == 'Y')
            { 
                Permission += (int)enPermission.All;
                return;
            }
            Console.WriteLine("[1] Include Capital Letters [Y/N].");
            choice=char.Parse(Console.ReadLine());
            if (char.ToUpper(choice) == 'Y')
                Permission += (int)enPermission.CapitalLetter;

            Console.WriteLine("[2] Include Small Letters.");
            choice = char.Parse(Console.ReadLine());
            if (char.ToUpper(choice) == 'Y')
                Permission += (int)enPermission.SmallLetter;

            Console.WriteLine("[3] Include Numbers.");
            choice = char.Parse(Console.ReadLine());
            if (char.ToUpper(choice) == 'Y')
                Permission += (int)enPermission.Number;

            Console.WriteLine("[4] Include Special Characters.");
            choice = char.Parse(Console.ReadLine());
            if (char.ToUpper(choice) == 'Y')
                Permission += (int)enPermission.SpecialCharacter;
        }

        private static int ReadNumber(string message, string ERROR= "Enter A Valid Length: ")
        {
            bool isFalied = false;
            int number = default;

            Console.Write(message);
            do
            {
                isFalied = ((!int.TryParse(Console.ReadLine(), out number)) || (number < 1 || number > int.MaxValue));
                if (isFalied) Console.Write(ERROR);
            } while (isFalied);
            return number;
        }

        private static void PerformUserChoice(byte choice)
        {
            switch (choice)
            {
                case 1:
                    Console.WriteLine(GenerateRandoNmumberBetween(ReadNumber("Enter A Minimum: "), ReadNumber("Enter A Maximum: ")));
                    break;

                case 2:
                    Console.WriteLine(GenerateRandomString(ReadNumber("Enter A Length: " )));
                    break;
            }
        }

    }
}

