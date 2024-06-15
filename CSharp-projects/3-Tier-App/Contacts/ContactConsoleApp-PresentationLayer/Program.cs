using ContactBuissnessLayer;
using System.Data;

namespace ContactConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Test Contact Methods
           // TestFindContact(1);
            //TestAddNewContact();
            // TestUpdateContact(6);
            // TestDeleteContact(4);
           //  TestListAllContacts();
            // TestIsContactExists(i); 
            #endregion

            #region Test Country Methods
            //for (int i = 0; i < 10; i++)
            //    TestFindCountry(i); // Find Ok 
            //TestAddNewCountry(); // Ok
            //  TestUpdateCountry(5);//Ok
               // TestDeleteCountry(3); //Ok
            //  TestListAllCountries(); //Ok
             //TestIsCountryExists(1);//Ok
             //TestIsCountryExists(10);
           //   TestFindCountryByName("EgYpt");
            #endregion
            Console.ReadLine(); 
        }



        #region Test Contact Mehtods
        public static void PrintContact(clsContact Contact)
        {
            Console.WriteLine($"Contact [{Contact.ID}] Info : ");
            Console.WriteLine("------------------------------------------\n");
            Console.WriteLine($"Firstname   : {Contact.FirstName}");
            Console.WriteLine($"LastName    : {Contact.LastName}");
            Console.WriteLine($"Email       : {Contact.Email}");
            Console.WriteLine($"Phone       : {Contact.Phone}");
            Console.WriteLine($"Address     : {Contact.Address}");
            Console.WriteLine($"DateOfBirth : {Contact.DateOfBirth}");
            Console.WriteLine($"CountryID   : {Contact.CountryID}");
            Console.WriteLine($"ImagePath   : {Contact.ImagePath}");
            Console.WriteLine("\n------------------------------------------\n\n");
        }

        public static void TestFindContact(int ID)
        {
            clsContact Contact = clsContact.Find(ID);

            if (Contact != null)
            {
                PrintContact(Contact);
            }
            else
            {
                Console.WriteLine($"Contact With {ID} Not Found\a");
            }
        }

        public static void TestAddNewContact()
        {
            clsContact Contact = new clsContact();

            Contact.FirstName = "Ahmed";
            Contact.LastName = "Abd El-aleem";
            Contact.Email = "Mohammed@gmail";
            Contact.Phone = "01030632293";
            Contact.Address = "Elagroudy Mosque st";
            Contact.CountryID = 5; // [1-5] how great sqlserver Data integrity 
            Contact.DateOfBirth = DateTime.Now;

            if (Contact.Save())
                Console.WriteLine($"Contact {Contact.ID} Added successfully..");

            else Console.WriteLine("Error\a");


        }

        public static void TestUpdateContact(int ID)
        {

            clsContact Contact = clsContact.Find(ID);
            if (Contact != null)
            {
                Contact.FirstName = "Mohammed";
                Contact.LastName = "Mostafa";
                Contact.Phone = "0101211122";

                if (Contact.Save())
                    Console.WriteLine("Contact updated successfully");
                else
                    Console.WriteLine("Error");
            }
        }

        public static void TestDeleteContact(int ID)
        {
            if (clsContact.IsExists(ID))
            {
                if (clsContact.DeleteContact(ID))
                {
                    Console.WriteLine("Contact Deleted Succefully.");
                }

            }
            else { Console.WriteLine("Contact Not Found"); }
        }

        public static void TestIsContactExists(int ID)
        {
            if (clsContact.IsExists(ID))
            {
                Console.WriteLine($"Contact {ID} Founded Succefully.");
            }
            else
            {
                Console.WriteLine("Contact Not Founded\a");
            }
        }

        private static void TestListAllContacts()
        {
            DataTable Contacts = clsContact.GetAllContacts();

            Console.WriteLine("Contacts Data:...");

            foreach (DataRow Record in Contacts.Rows)
            {
                Console.WriteLine($"({Record["ContactID"]} , {Record["FirstName"]} , {Record["LastName"]})");
            }

        }

        #endregion


        #region Test Country Methods
        public static void TestFindCountry(int ID)
        {
            clsCountry country = clsCountry.Find(ID);

            if (country != null)
            {
                Console.WriteLine($"( {country.CountryID} , {country.CountryName} , {country.Code} , {country.PhoneCode} )");
            }
            else
            {
                Console.WriteLine($"Country With {ID} Not Found");
            }
        }

        public static void TestAddNewCountry()
        {
            clsCountry country = new clsCountry();
            country.CountryName = "Morotania";
            country.Code = "050";
            country.PhoneCode = "333";

            if (country.Save())
                Console.WriteLine($"Country Number {country.CountryID} Added successfully..");

            else Console.WriteLine("Error\a");


        }

        public static void TestUpdateCountry(int ID)
        {

            clsCountry Country = clsCountry.Find(ID);
            if (Country != null)
            {
                Country.Code = "888";
                Country.PhoneCode = "069";

                if (Country.Save())
                    Console.WriteLine("Country updated successfully");
                else
                    Console.WriteLine("Error");
            }
            else
                Console.WriteLine($"Country {ID} Not Found");
        }

        public static void TestDeleteCountry(int ID)
        {
            if (clsCountry.IsExists(ID))
            {
                if (clsCountry.DeleteCountry(ID))
                {
                    Console.WriteLine("Country Deleted Succefully.");
                }

            }
            else { Console.WriteLine($"Country Number {ID} Not Found"); }
        }

        private static void TestListAllCountries()
        {
            DataTable Countries = clsCountry.GetAllCountries();

            Console.WriteLine("Contacts Data:...");

            foreach (DataRow Record in Countries.Rows)
            {
                Console.WriteLine($"( {Record["CountryID"]} , {Record["CountryName"]} , {Record["Code"]}, {Record["PhoneCode"]} )");
            }

        }

        public static void TestIsCountryExists(int ID)
        {
            if (clsCountry.IsExists(ID))
            {
                Console.WriteLine($"Country {ID} Founded Succefully.");
            }
            else
            {
                Console.WriteLine($"Country {ID} Not Founded\a");
            }
        }

        public static void TestExixtanceCountryByName(string Name)
        {
            if (clsCountry.IsExists(Name))
            {
                Console.WriteLine($"Country Founded Succefully.");
            }
            else
            {
                Console.WriteLine($"Country Not Founded\a");
            }
        }

        public static void TestFindCountryByName(string Name)
        {
            clsCountry country = clsCountry.Find(Name);
            if (country != null)
            {
                Console.WriteLine($"Country Founded => ( {country.CountryID} , {country.CountryName}, {country.Code}, {country.PhoneCode} ).");
            }
            else
            {
                Console.WriteLine($"Country Not Founded\a");
            }
        }


        #endregion
    }
}
