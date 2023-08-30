using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleParsing
{
    internal class Contact
    {
        private string Name;
        private string DOB;
        private string Email;
        private string PhoneNumber;
        private DateTime parsedDOB;
        public int age;
        private string FirstName;
        private string LastName;

        //constructor for rows which provide all the info we're looking for
        public Contact(string name, string dOB, string email, string phoneNumber)
        {
            Name = name;
            DOB = dOB;
            Email = email;
            PhoneNumber = phoneNumber;

            //parse date of birth and calculate age
            parsedDOB = DateTime.Parse(DOB);
            int now = int.Parse(DateTime.Now.ToString("yyyyMMdd"));
            int birthDate = int.Parse(parsedDOB.ToString("yyyyMMdd"));
            age = (now - birthDate) / 10000;

            //get First & Last Name from Name;
            string[] firstAndLastName = Name.Split(' ');
            FirstName = firstAndLastName[0];
            LastName = firstAndLastName[1];

            //adding white space to the mobile number
            if (PhoneNumber != null && PhoneNumber.Length > 5)
            {
                PhoneNumber = PhoneNumber.Insert(5, " ");
                //removing excess characters if phone number too long
                if (PhoneNumber.Length > 12)
                {
                   PhoneNumber = PhoneNumber.Substring(0, 12);
                }
            }
        }

        //constructor which accounts for telephone number missing, thus setting it to null.
        public Contact(string name, string dOB, string email):
            this(name, dOB, email, null)
        {
        }

        public void printDetails()
        {
            Console.WriteLine(FirstName.PadRight(15) + " " + LastName.PadRight(15) + " " + DOB.PadRight(15) + " " + age + "   " + Email.PadRight(30) + " " + PhoneNumber);
        }

    }
}
