using System.Collections.Generic;

namespace FileReader
{
    public class CountryData
    {
        public CountryData()
        {
            Country = new List<CountryData>();
        }
        public List<CountryData> Country { get; set; }
        public string CountryName { get; set; }
    }
}