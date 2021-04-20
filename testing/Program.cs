using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary;

namespace testing
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello");
            AsterixFile asterixFile = new AsterixFile();
            asterixFile.ReadFile(@"C:\Users\Usuario\Desktop\4A\PGTA\Ficheros_asterix\201002-lebl-080001_smr.ast");
            Console.WriteLine();
            List<CAT10> cat10list = asterixFile.GetCAT10Blocks();
            Console.ReadLine();
        }
    }
}
