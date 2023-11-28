using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;

namespace map_HW
{
    internal class Program
    {
        static void Main(string[] args)
        {
            map<int, string> myMap = new map<int, string>(1,"asdf");
            myMap.Add(3, "qwe");
            myMap.Add(3, "qwe");
            myMap.Add(6, "qwe");
            myMap.Add(2, "qwe");
            myMap.Add(4, "qwe");
            myMap.Add(12, "qwe");
            Console.WriteLine(myMap);

            foreach(var i in myMap)
            {
                Console.WriteLine(i);
            }

            Dictionary<int, int> asdf = new Dictionary<int, int>();
            asdf.Add(1, 2);
            asdf.Add(2, 2);
            asdf.Add(4, 2);
            asdf.Add(3, 2);
            Console.WriteLine(asdf);

        }
    }
}
