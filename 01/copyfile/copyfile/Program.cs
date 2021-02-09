﻿using System;
using System.IO;

namespace copyfile
{
    class Program
    {
        static int Main(string[] args)
        {
            if ( args.Length != 2 )
            {
                return 1;
            }

            string inpFileName = args[0] + ".txt";

            string outFileName = args[1] + ".txt";

            try
            {
                File.Copy( Path.Combine( inpFileName ), Path.Combine( outFileName ) );
            }
            catch ( Exception ERROR_NAME )
            {
                Console.WriteLine( ERROR_NAME );
                
                return 1;
            }

            return 0;
        }
    }
}