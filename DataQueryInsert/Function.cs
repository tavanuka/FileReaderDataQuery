using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Data.SqlClient;
using System.Security;
using FileReader;

namespace DataQueryInsert
{
    public class Function
    {

        string connection = "Server = den1.mssql8.gear.host; Database=astrodatasql";
        string insert_query = "INSERT INTO [PersonAstro] (FirstName,LastName,Gender,DateOfBirth,TimeOfBirth,City,Country) VALUES (@FirstName ,@LastName ,@Gender , @DateOfBirth ,@TimeOfBirth ,@City ,@Country)";
        string input = @"C:\Users\mark\OneDrive - m8IT GmbH & Co.KG\Dokumente\Solutions\FileReader\FileReader\FileReader\test.csv";
        DataReader read = new DataReader();


        public void Initialize(SecureString pw)
        {
           
            SqlCredential cred = new SqlCredential("astrodatasql", pw);
            var rec = read.CsvRead(input);
            
            Console.WriteLine("Attempting to log in");
            using (SqlConnection conn = new SqlConnection(connection, cred))
            {
                SqlCommand cmd = new SqlCommand(insert_query, conn);
                cmd.Parameters.AddWithValue("@FirstName", rec[0].FirstName);
                cmd.Parameters.AddWithValue("@LastName", rec[0].LastName);
                cmd.Parameters.AddWithValue("@Gender", rec[0].Gender);
                cmd.Parameters.AddWithValue("@DateOfBirth", rec[0].DateOfBirth);
                cmd.Parameters.AddWithValue("@TimeOfBirth", rec[0].TimeOfBirth);
                cmd.Parameters.AddWithValue("@City", rec[0].City);
                cmd.Parameters.AddWithValue("@Country", rec[0].Country);
                
            }

        }
    }
}