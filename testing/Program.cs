﻿using System;
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
            asterixFile.ReadFile(@"//mac/Home/Desktop/Windows/file3.ast");
            Console.WriteLine();
            List<DataBlock> dataBlockList = asterixFile.GetDataBlocks();
            Console.ReadLine();
        }
    }
}
