using System;
using System.Security;

namespace CountryQueryInsert
{
    class Program
    {
        static void Main(string[] args)
        {
            var sql = new Function();
            SecureString pw = new SecureString();
            ConsoleKeyInfo key;

            Console.Write("Enter password: ");
            do
            {
                key = Console.ReadKey(true);

                // Ignore any key out of range.
                if (((int)key.Key) >= 14)
                {
                    pw.AppendChar(key.KeyChar);
                    Console.Write("*");
                }
            } while (key.Key != ConsoleKey.Enter);
            Console.WriteLine();
            pw.MakeReadOnly();

            sql.Initialize(pw);
        }
    }
}
