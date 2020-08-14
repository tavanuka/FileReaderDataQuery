using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace FileReader
{
    public class PersonData
    {
        public PersonData()
        {
            Person = new List<PersonData>();
        }
        public List<PersonData> Person { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Gender { get; set; }

        public DateTime DateOfBirth { get; set; }

        public DateTime TimeOfBirth { get; set; }

        public string City { get; set; }

        public string Country { get; set; }
    }

}
