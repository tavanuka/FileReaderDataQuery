using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace FileReader
{
    public static class DataWriter
    {
        public static IList<T> Clone<T>(this IList<T> ListToClone) where T: ICloneable
        {
            return ListToClone.Select(item => (T)item.Clone()).ToList();
        }
        public static void DataWrite()
        {
            
        }
    }
}
