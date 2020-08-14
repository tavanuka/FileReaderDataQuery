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
        string insert_query = "INSERT INTO PersonAstro (FirstName,LastName,Gender,DateOfBirth,TimeOfBirth,City,Country) VALUES (@FirstName ,@LastName ,@Gender , @DateOfBirth ,@TimeOfBirth ,@City ,@Country);";
        string input = @"C:\Users\mark\OneDrive - m8IT GmbH & Co.KG\Dokumente\Solutions\FileReader\FileReader\FileReader\astro_out.csv";
        DataReader read = new DataReader();

        public void Initialize(SecureString pw)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["astrodatasql"].ConnectionString;
            SqlCredential cred = new SqlCredential("astrodatasql", pw);
            var rec = read.CsvRead(input);
            
            Console.WriteLine("Attempting to log in");
            using (SqlConnection conn = new SqlConnection(connectionString, cred))
            using(SqlCommand cmd = new SqlCommand(insert_query, conn))
            {
                Console.WriteLine("Succesfully logged in to {0}", connectionString);

                int rowsAffected = 0;
                
                cmd.Parameters.Add("@FirstName", System.Data.SqlDbType.NVarChar);
                cmd.Parameters.Add("@LastName", System.Data.SqlDbType.NVarChar);
                cmd.Parameters.Add("@Gender", System.Data.SqlDbType.Char);
                cmd.Parameters.Add("@DateOfBirth", System.Data.SqlDbType.Date);
                cmd.Parameters.Add("@TimeOfBirth", System.Data.SqlDbType.Time);
                cmd.Parameters.Add("@City", System.Data.SqlDbType.NVarChar);
                cmd.Parameters.Add("@Country", System.Data.SqlDbType.NVarChar);

                conn.Open();
                for (var i = 0; i < rec.Count; i++)
                {
                    Console.WriteLine("Adding {0} to the table",  rec[i].FirstName);

                    cmd.Parameters["@FirstName"].Value = rec[i].FirstName;
                    cmd.Parameters["@LastName"].Value = rec[i].LastName;
                    cmd.Parameters["@Gender"].Value = rec[i].Gender;
                    cmd.Parameters["@DateOfBirth"].Value = rec[i].DateOfBirth;
                    cmd.Parameters["@TimeOfBirth"].Value = rec[i].TimeOfBirth.TimeOfDay;
                    cmd.Parameters["@City"].Value = rec[i].City;
                    cmd.Parameters["@Country"].Value = rec[i].Country;

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