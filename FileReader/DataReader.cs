using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;

namespace FileReader
{
    public class DataReader
    {
        public void ReadLine(string inputPath)
        {
            using (StreamReader sr = new StreamReader(inputPath))
            {
                
                string line = "";
                while ((line = sr.ReadLine()) != null)
                {
                    if (Regex.IsMatch(line, "(?:#A93:)") == true)
                    {
                        var obj = line.Split(',');
                        obj[0] = obj[0].Remove(0, 5);
                        pd.Person.Add(new PersonData
                        {
                            FirstName = obj[0],
                            LastName = obj[1],
                            Gender = obj[2],
                            DateOfBirth = obj[3],
                            TimeOfBirth = obj[4],
                            City = obj[5],
                            Country = obj[6]
                        }); 
                        Console.WriteLine(line);
                    }

                }
            }

        }
        public void WriteLine(string InputPath)
        {
            using (var writer = new StreamWriter(InputPath))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.WriteRecords(pd.Person);
            }
        }
        
        public  List<PersonData> CsvRead(string InputPath)
        {
            using (var reader = new StreamReader(InputPath))
                using (var csr = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                var records = csr.GetRecords<PersonData>();
                var rec = records.ToList();
                return rec;
                }
        }
        public PersonData pd = new PersonData();
    }
}
