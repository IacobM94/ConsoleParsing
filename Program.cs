using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Runtime.InteropServices;
using static System.Net.Mime.MediaTypeNames;
using System.Text.RegularExpressions;
using System.ComponentModel.Design;

namespace ConsoleParsing
{
    internal class Program
    {
        //read .txt file & remove any blank or null results.
        //Code will find the text file relative to the project directory
        public static string projectFolder = Directory.GetCurrentDirectory();
        public static string grandParentDirectory = Directory.GetParent(Directory.GetParent(projectFolder).FullName).FullName;
        public static string filePath = Path.Combine(grandParentDirectory, @"docs\contacts.txt");
        public static string[] contactDetails = File.ReadAllLines(filePath);

        static void Main(string[] args)
        {

            //cleanup the data.
            contactDetails = contactDetails.Where(x => !string.IsNullOrWhiteSpace(x)).ToArray();


            //create an array of contacts
            Contact[] Contacts = new Contact[contactDetails.Length];


            //add data into each Contact instance
            for (int i = 0; i < contactDetails.Length; i++)
            {
                char[] separators = new char[] { '\t' };
                string[] parsedContact = contactDetails[i].Split(separators, StringSplitOptions.RemoveEmptyEntries);

                if (parsedContact.Length >= 4)
                {
                    Contacts[i] = new Contact(parsedContact[0], parsedContact[1], parsedContact[2], parsedContact[3]);
                }
                else
                {
                    Contacts[i] = new Contact(parsedContact[0], parsedContact[1], parsedContact[2]);
                }
            }

            //sort the Contacts by age - this will sort in ascending order
            Array.Sort(Contacts, new AgeComparer());
            //reverse the order to show age in descending order
            Array.Reverse(Contacts);
            Console.WriteLine("First Name".PadRight(16) + "Last Name".PadRight(16) + "Date of Birth".PadRight(16) + "Age".PadRight(5) + "Email".PadRight(31) + "Phone Number");
            Console.WriteLine("------------------------------------------------------------------------------------------------");
            for (int i = 0; i < Contacts.Length; i++)
            {
                Contacts[i].printDetails();
            }

            Console.WriteLine("\nContacts Parsed!\nPress any key to continue...");
            Console.ReadKey();
        }
    }
}
