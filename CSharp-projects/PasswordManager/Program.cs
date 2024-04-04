// the src: https://www.youtube.com/watch?v=ERh-5JkHdRQ&t=17s

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PasswordManager
{
    internal class Program
    {
        static void Main(string[] args)
        {
            LogIn();
            Console.ReadLine();
        }


        private static void Start()
        {
            do
            {
                Console.Clear();
                Loading("Password Manager Project");
                PrintTheMainList();
                PerformUserChoice((enChoices)ReadChoice(0, 5));

            } while (true);
        }

        public enum enChoices { EXIT=0 ,listAllPasswords =1 , AddNewPassword=2 , ChangePassword=3 ,
            GetPassword=4 , RemovePassword=5
        }
     
       public static Dictionary<string, string> dictPasswords  = new Dictionary<string, string>();
        const string path = "D:\\University\\Coding\\Basic\\Basic-C#\\Projects\\PasswordManager\\myPasswords.txt";
        const string users_path = "D:\\University\\Coding\\Basic\\Basic-C#\\Projects\\PasswordManager\\Users.txt";


        public static void LogIn()
        {
            string user;
            string password;
           bool checkIfUserFoundByUsernameAndPassword = false;
            Dictionary<string, string> users = GetUsersFromFile(users_path);
            do
            {
                Console.Clear();
                ColorTheHeader("LOGIN Screen");
                Console.Write("\nEnter Username : ");
                user = Console.ReadLine();

                Console.Write("\nEnter Password : ");
                 password = Console.ReadLine();
                checkIfUserFoundByUsernameAndPassword = CheckIfUserFoundByUsernameAndPassword(user, password,  users);
                if (checkIfUserFoundByUsernameAndPassword == false)
                {
                    Console.WriteLine("\n\nInvalid Username , Password \a");
                    Thread.Sleep(3500);
                }
                else
                {
                    Start();
                }

            } while (!checkIfUserFoundByUsernameAndPassword);
          }

        private static bool CheckIfUserFoundByUsernameAndPassword(string user, string password, Dictionary<string, string> users)
        {
            
            foreach(var entry in users)
            {
                if (entry.Key.Equals(user,StringComparison.OrdinalIgnoreCase) && entry.Value == password)
                    return true;
            }
            return false;
        }

        private static Dictionary<string, string> GetUsersFromFile(string users_path)
        {
            Dictionary<string, string> current_users = new Dictionary<string, string>();

            try
            {
                string[] users = File.ReadAllLines(users_path);
                string[] entry ;
                foreach (string user in users)
                {
                    entry = user.Split(':');
                    current_users[entry[0]] = entry[1];
                }

                            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
            }
           return current_users;
        }

        public static Dictionary<string, string> GetPasswordsFromFileAsDictonary(string path)
        {
            try
            {
                dictPasswords.Clear();
                string[] passwords = File.ReadAllLines(path);
                string[] currentPassword = new string[2];
                foreach (string password in passwords)
                {
                    currentPassword = password.Split(':');
                    dictPasswords.Add(currentPassword[0], currentPassword[1]);
                }
            }
            catch (IOException e)
            {
                Console.WriteLine(e.ToString());
            }
            return dictPasswords;
        }

        public static byte ReadChoice(byte from, byte to)
        {
            byte choice = default(byte);
            bool isNotValid = true;

            Console.Write($"Enter Your Choice[{from} - {to}] : ");
            do
            {
                isNotValid = ! byte.TryParse(Console.ReadLine(), out choice) || choice < from || choice > to;
                if (isNotValid)
                {
                    Console.Write($"Please Enter A Valid Choice [{from} - {to}]\a : ");
                }

            } while (isNotValid);
            return choice;
        }

        public static string GetNumOfSpace(int num)
        {
            string spaces = "";
            for (int i = 0; i < num; i++)
                spaces += " ";
           
            return spaces;
        }
        public static void Loading(string message)
        {
            int strLen = message.Length;
            for (int i = 1; i <=4; i++)
            {
                if(i<4)
               Console.Write(message+"\r");
                else
                    Console.WriteLine(message );
                message += "."+ GetNumOfSpace(strLen/10); // by trial
                Thread.Sleep(800);
              //  Console.Clear();
            }
            Console.WriteLine("--------------------------");
        }

        public static void PrintTheMainList()
        {
            Console.WriteLine("1- List All Passwords.");
            Console.WriteLine("2- Add New Password.");
            Console.WriteLine("3- Change Password.");
            Console.WriteLine("4- Get Password.");
            Console.WriteLine("5- Remove Password.");
            Console.WriteLine("0- EXIT.");
            Console.WriteLine("----------------------------\n");

        }

        public static void PressAnyKeyToContinue()
        {
            Console.Write("\n\n\nPress Enter To Continue........");
            Console.Read();
        }
        public static void PerformUserChoice(enChoices choice)
        {
            switch(choice) {
                case enChoices.listAllPasswords:
                    ListAllPasswords(path);
                    PressAnyKeyToContinue();
                    break;

                case enChoices.AddNewPassword:
                    AddNewPassword();
                    PressAnyKeyToContinue();
                    break;

                case enChoices.ChangePassword:
                    ChangePassword();
                    PressAnyKeyToContinue();
                    break;

                case enChoices.GetPassword:
                    GetPassword();
                    PressAnyKeyToContinue();
                    break;

                case enChoices.RemovePassword:
                    RemovePassword();
                    PressAnyKeyToContinue();
                    break;
                case enChoices.EXIT:
                    Environment.Exit(0);// Exit the application with exit code 0 (success)
                    break;
            }
        }

        public static string ReadDictonaryKey()
        {
            string key;
            bool wrongKey = false;
            dictPasswords = GetPasswordsFromFileAsDictonary(path);
            Console.Write("Please Enter A Key : ");
            do
            {
                key = Console.ReadLine();
                if (dictPasswords.ContainsKey(key))
                {
                    Console.Write("This Key Is Found, Enter Another One : ");
                    wrongKey = true;
                }else
                    wrongKey = false;
            } while (wrongKey);

            return key;
        }

        public static string GetExistingDictonaryKeyIfFound()
        {
     //       dictPasswords = GetPasswordsFromFile(path);
            string key;
            Console.Write("Please Enter A Key : ");
            do
            {
                 key = Console.ReadLine();
                if (dictPasswords.ContainsKey(key) )
                {
                    break;
                }
                else
                {
                    Console.Write($"{key} Not Found ,Please Enter A Valid Key : ");
                    continue;
                }
            }while(true);

             return key;

        }

        public static string ConvertKeyValueStringsToRecord(string key, string value) =>  key + ":" + value;

        public static string[] GetAllPasswordsFromDictionaryPasswordsAsStringRecords()
        {
            string[] Keys = dictPasswords.Keys.ToArray();
            int len = Keys.Length;
            string[] Records = new string[len];
            string Record;
            for (int i = 0; i < len; i++)
            {
                Record = ConvertKeyValueStringsToRecord(Keys[i], dictPasswords[Keys[i]]);
                Records[i] = Record;
            }
            return Records;
        }


        private static void UpdatePasswordsFile(string path)
        {
            try
            {
                string[] Records = GetAllPasswordsFromDictionaryPasswordsAsStringRecords();
                File.WriteAllLines(path, Records);
                Console.WriteLine("\n\n\nFile Updated Successfully.........");
            }
            catch (IOException e)
            {
                Console.WriteLine(e.ToString());
            }
        }
        public static void  AddNewRecordToPasswordsFile(string path,string keyValuePair)
        {
            try
            {
                using (StreamWriter writer = File.AppendText(path))
                {
                    if(dictPasswords.Count == 0)
                         writer.WriteLine("\n"+ keyValuePair );
                    else
                        writer.WriteLine( keyValuePair );

                }
            }
            catch (IOException e)
            {
                Console.WriteLine(e.ToString());
            }

        }
      

        static string FormatString(string input, int width)
        {
            return input.PadRight(width);
        }
      
        private static void ColorTheHeader(string title)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.WriteLine(title+"\n\n\n");
            Console.ResetColor();
        }
        public static void PrintPassword(string key)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.BackgroundColor = ConsoleColor.White;
            Console.WriteLine("\n");
            Loading("The Password Is....");
            Console.WriteLine($"{key} : {dictPasswords[key]}");
            Console.WriteLine("\n");
            Console.ResetColor();
        }
        private static void ListAllPasswords(string path)
        {
            Console.Clear();
            ColorTheHeader("List All Passwords Screen");
            dictPasswords = GetPasswordsFromFileAsDictonary(path);
            string[] Keys= dictPasswords.Keys.ToArray();
            string[] Values = dictPasswords.Values.ToArray();

            if (Keys.Length > 0) {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("----------------------------------------");
                Console.WriteLine($"|{FormatString("     Keys", 15)} | {FormatString("     Values", 20)} |");
                Console.WriteLine("----------------------------------------");
                Console.ForegroundColor = ConsoleColor.White;

                for (int i = 0; i < Keys.Length; i++)
                {
                    Console.WriteLine($"| {FormatString(Keys[i],15)} | {FormatString(Values[i], 20)}|");
                    Console.WriteLine("----------------------------------------");
                }
            }
            else
                Console.WriteLine("No Passwords Found\a");
        }
        private static void AddNewPassword()
        {
            Console.Clear();
                      ColorTheHeader("Add New Password Screen");
                        string key = ReadDictonaryKey();

            Console.Write("Enter A Value : ");
            string value = Console.ReadLine();
            dictPasswords.Add(key, value);
            string keyValuePair = ConvertKeyValueStringsToRecord(key, value);
            AddNewRecordToPasswordsFile(path, keyValuePair); //appending into file 
            Console.WriteLine("\n\nAdding new Password Succesfully.....");
        }

        private static void ChangePassword()
        {
            Console.Clear();
            ColorTheHeader("Change Password Screen");

            string key = GetExistingDictonaryKeyIfFound();
            PrintPassword(key);

            Console.Write("Are You Sure [Y-N ] ? : ");
            char answer = char.Parse(Console.ReadLine());

            if (char.ToUpper(answer) == 'Y')
            {
                Console.Write("\nEnter A New Value : ");
                string value = Console.ReadLine();
                dictPasswords[key] = value;
                UpdatePasswordsFile(path);
            }else
            {
                Console.WriteLine("\nNo Changes Occured..!...");
            }
        }

      
       private static void GetPassword()
        {
            Console.Clear();
            ColorTheHeader("Change Password Screen");

            dictPasswords = GetPasswordsFromFileAsDictonary(path);
            string key = GetExistingDictonaryKeyIfFound() ;
            PrintPassword(key);
            
        }
        private static void RemovePassword()
        {
            Console.Clear();
            ColorTheHeader("Remove Password Screen");

            dictPasswords = GetPasswordsFromFileAsDictonary(path);
            string key = GetExistingDictonaryKeyIfFound();
            PrintPassword(key);

            Console.Write("Are You Sure [Y-N ] ? : ");
            char answer = char.Parse(Console.ReadLine());

            if (char.ToUpper(answer) == 'Y')
            {
                dictPasswords.Remove(key);
                UpdatePasswordsFile(path);
                Console.WriteLine("\n\n\nPassword Removed Successfully....");
            }
            else
            {
                Console.WriteLine("\nNo Changes Occured..!...");
            }
          
        }

       
    }
}
