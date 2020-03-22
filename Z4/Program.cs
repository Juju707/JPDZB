using System;
using System.Collections.Generic;

namespace Z4
{
    ///<summary>
    /// The Multiplication Matrix class.
    /// Contains all methods for creating mutiplication matrix.
    ///</summary>
    /// <remarks>
    /// <para>This class can create multiplication matrix of n length.</para>
    /// <para>These operations are performed on integers or doubles.</para>
    /// </remarks>
    public class MultiplicationArray
    {
        /// <summary>
        /// Create multiplication matrix.
        /// For every element from 1 to n, the values in rows are multiplied by value in columns and stored in form of matrix.
        /// </summary>
        /// <returns>
        /// The 2D  array of n numbers.
        /// </returns>
        /// <param name="n">A double precision number.</param>
        public double[,] CalculateArray( int n)
        {
            double[,] array = new double[n+1,n+1];
            array[0,0] = 0;
            for (int i = 0; i < n+1 ; i++)
            { for (int j = 0; j < n+1; j++)
                {
                    if (j == 0) array[i, j] = i;
                    else if (i == 0) array[i, j] = j;
                    else array[i,j] = i * j;
                }
            }
            return array;
        }
        /// <summary>
        /// Checks the condition for the matrix
        /// </summary>
        /// <returns>
        /// A boolean value to validate whether matrix can be created
        /// </returns>
        public Boolean CheckIfExists(double n)
        {
            if ((n > 0) && ((n % 1) == 0)) return true;
            return false;
        }
        /// <summary>
        /// Prints an array of numbers with double precision for sequence with given values.
        /// Matrix is formatted with whitespace symbols
        /// </summary>
        public void PrintSequence(double[,] array)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    Console.Write(string.Format("{0}\t", array[i, j]));
                }
                Console.Write(Environment.NewLine + Environment.NewLine);
            }
        }

    }
    ///<summary>
    /// The main class.
    /// Performs operations compatible with user's input.
    ///</summary>
    class Zadanie4
    {
        /// <summary>
        /// Checks if all of the arguments have been given
        /// Takes values from user and creates a 2D array
        /// An error is caught if even one of values is not numeric or the values does not meet the condition for sequence's existence
        /// Accordingly to the source of problem, appropriate comment is shown
        /// If multiplication matrix can be created, it is displayed with proper formatting
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            if (args.Length != 1)
            {
                Console.WriteLine("The function requires 1 numeric argument(length of matrix).");
            }
            else
            {
                MultiplicationArray array = new MultiplicationArray();
                try {
                    var arrayExists = array.CheckIfExists(Convert.ToDouble(args[0]));
                     if (arrayExists){
                        array.PrintSequence(array.CalculateArray(Convert.ToInt32(args[0])));
                     }else{
                         Console.WriteLine("This matrix does not exist. Length of sequence must be a positive integer value");
                     }
                }
                catch{
                        Console.WriteLine("The argument must be a positive integer.");
                }
                

            }
        }

    }
}
