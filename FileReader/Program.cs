using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace FileReader
{
    class Program
    {
        static void Main(string[] args)
        {
            var read = new DataReader();
            string output = @"C:\Users\mark\OneDrive - m8IT GmbH & Co.KG\Dokumente\Solutions\FileReader\FileReader\FileReader\astro_out.csv";
            string input = @"C:\Users\mark\OneDrive - m8IT GmbH & Co.KG\Dokumente\Solutions\FileReader\FileReader\FileReader\file_astro.txt";
            read.ReadLine(input);
            read.WriteLine(output);
        }
    }
}
