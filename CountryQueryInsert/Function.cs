using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Security;
using System.Text;
using FileReader;

namespace CountryQueryInsert
{
    class Function
    {
        string query_insert = "INSERT INTO Country (Country) VALUES (@Country)";
        string input = @"C:\Users\mark\source\repos\AstroDataSolutions\AstroData\country_list.txt";
        DataReader read = new DataReader();

        public void Initialize(SecureString pw)
        {

            var count = read.StreamReader(input);

            var connectionString = ConfigurationManager.ConnectionStrings["astrodatasql"].ConnectionString;
            SqlCredential cred = new SqlCredential("astrodatasql", pw);

            Console.WriteLine("Attempting to log into {0}", "astrodatasql");
            using (SqlConnection conn = new SqlConnection(connectionString, cred))
                
            using(SqlCommand cmd = new SqlCommand(query_insert, conn))
            {
                Console.WriteLine("Successfuly logged in.");
                Int32 rowsAffected = 0;
                cmd.Parameters.Add("@Country", System.Data.SqlDbType.NVarChar);

                conn.Open();
                for(var i = 0; i < count.Count; i++)
                {
                    Console.WriteLine("Adding {0} to the table", count[i].CountryName);
                    cmd.Parameters["@Country"].Value = count[i].CountryName;
                    rowsAffected += cmd.ExecuteNonQuery();
                }

                try
                {
                    Console.WriteLine("RowsAffected: {0}", rowsAffected);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
