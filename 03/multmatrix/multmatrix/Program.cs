﻿using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace multmatrix
{
    class Program
    {
        static int Main(string[] args)
        {
            if (args.Length != 2)
            {
                Console.WriteLine( "Invalid arguments count" );
                Console.WriteLine( "Uasge: multmatrix.exe <matrix file1> <matrix file2>" );    

                return 1;
            }

            string firstTerm = File.ReadAllText( args[0] );
            string secondTerm = File.ReadAllText( args[1] );

            //read matrix in input file
            double[][] firstMatrix;
            double[][] secondMatrix;
            try
            {
                firstMatrix = ReadMatrix( firstTerm );
                secondMatrix = ReadMatrix( secondTerm );
            }
            catch ( Exception error )
            {
                Console.WriteLine( error.Message );
                
                return 1;
            }

            double[][] resultMatrix = new double[3][];
            for ( int i = 0; i < 3; ++i )
            {
                resultMatrix[i] = new double[3];
            }

            Parallel.For(0, firstMatrix.Length, i =>
            {
                for (int j = 0; j < 3; ++j)
                {
                    for (int k = 0; k < 3; ++k)
                    {
                        resultMatrix[i][j] += firstMatrix[i][k] * secondMatrix[k][j];
                    }
                }
            });

            Console.WriteLine( MatrixAsString( resultMatrix ) );

            return 0;
        }

        static double[][] ReadMatrix( string matrix )
        {
            double[][] resultMatrix = new double[3][];
            int i = 0;
            while ( matrix.Contains( "  " ) )
            {
                matrix = matrix.Replace( "  ", " " );
            }
            foreach ( string row in matrix.Trim().Split( '\n' ) )
            {
                resultMatrix[i] = row.Trim().Split( ' ' ).Select( Convert.ToDouble ).ToArray();
                i++;
            }

            return resultMatrix;
        }

        static string MatrixAsString( double[][] matrix )
        {
            string result = String.Empty;
            for ( int i = 0; i < matrix.Length; ++i )
            {
                for ( int j = 0; j < matrix[ i ].Length; ++j )
                {
                    result += matrix[i][j].ToString("F3").PadLeft(8) + " ";
                }
                result += Environment.NewLine;
            }

            return result;
        }
    }
}