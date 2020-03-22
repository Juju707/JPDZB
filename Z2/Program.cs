using System;

namespace Z2
{
    ///<summary>
    /// The Fibonacci class.
    /// Contains all methods for performing operations on numbers from Fibonacci's sequence.
    ///</summary>
    /// <remarks>
    /// <para>This class can check whether given numbers belong to Fibonacci's sequence and search for n next elements.</para>
    /// <para>These operations are performed on arrays and integers.</para>
    /// </remarks>
    public class Fibonacci
    {
        /// <summary>
        /// Calculate the n next elements in fibonacci's sequence starting from given 2 numbers
        /// </summary>
        /// <returns>
        /// The array of n numbers following the first 2 given elements 
        /// </returns>
        /// <param name="first">A single precision number.</param>
        /// <param name="second">A single precision number.</param>
        /// <param name="len">A single precision number.</param>
        public long[] CalculateSequence(long first, long second, double len)
        {
            long[] sequence = new long[Convert.ToInt32(len)];
            sequence[0] = first;sequence[1] = second;
            int counter = 2;
            while (counter < len)
            {
                sequence[counter] = sequence[counter - 1] + sequence[counter - 2];
                counter++;
            }
            return sequence;
        }
        /// <summary>
        /// Checks if the give numbers belong to fibonacci's sequence
        /// </summary>
        /// <returns>
        /// A boolean value to state whether numbers belong to fibonacci's sequence
        /// </returns>
        /// <param name="first">A single precision number.</param>
        /// <param name="second">A single precision number.</param>
        /// <param name="len">A double precision number.</param>
        public bool CheckIfExists(long first, long second, double len)
        {
            if (((len % 1) == 0) && (len > 2) && (first >= 0) && (second >= 0) && IsFibonacci(first) && IsFibonacci(second))
            {
                if(IsNext(first,second))return true;
            }
            return false;
        }
        /// <summary>
        /// Checks if given number is a perfect square
        /// </summary>
        /// <returns>
        /// A boolean value to state whether x is perfect square 
        /// </returns>
        /// <param name="x">A single precision number.</param>
        public bool IsPerfectSquare(long x)
        {
            long s = (int)Math.Sqrt(x);
            return (s * s == x);
        }
        /// <summary>
        /// Number is part of Fibonacci if one of:( 5*n*n + 4),(5*n*n - 4) or both are a perfect square 
        /// </summary>
        /// <returns>
        /// A boolean value to state whether number is part of Fibonacci's sequence
        /// </returns>
        /// <param name="n">A single precision number.</param>
        public bool IsFibonacci(long n)
        {
            return IsPerfectSquare(5 * n * n + 4) || IsPerfectSquare(5 * n * n - 4);
        }

        /// <summary>
        /// Checks if given number is the next number in Fibonacci's sequence
        /// </summary>
        /// <param name="first">A single precision number.</param>
        /// <param name="second">A single precision number.</param>
        /// <returns>A boolean value whether second element is the following element in fibonacci's sequence
        /// </returns>
        public bool IsNext(long first, long second)
        {
            long a = (long)Math.Round(first * (1 + Math.Sqrt(5)) / 2.0);
            if (a == second ||(first==1&&second==1)||(first==0&&second==1)) return true;
            return false;
        }
        /// <summary>
        /// Prints array of numbers with single precision
        /// </summary>
        public void PrintSequence(long[] sequence)
        {
            string[] stringSequence =new string[sequence.Length];
            for( int n=0;n<sequence.Length;n++){
                stringSequence[n] = sequence[n].ToString();
            }
            Console.WriteLine("Your sequence: [{0}]", string.Join(" ; ", stringSequence));
        }

    }
    ///<summary>
    /// The main class.
    /// Performs operations compatible with user's input.
    ///</summary>
    class Zadanie2
    {
        /// <summary>
        /// Checks if all of the arguments have been given 
        /// Validates whether the traingle can even exist
        /// An error is caught if even one of values is not numeric or the values does not belong to fibonacci's sequence
        /// Accordingly to the source of problem, appropriate comment is shown
        /// If numbers are rigth, the sequence of given length with following numbers is shown
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {

            if (args.Length != 3){Console.WriteLine("The function requires 3 numeric arguments(first and second element of fibonacci's sequence and the length of sequence to display).");}
            else
            {
                long first, second;
                double len;
                Fibonacci fibonacci=new Fibonacci();
                try
                {
                    first = Convert.ToInt64(args[0]); second = Convert.ToInt64(args[1]);len = Convert.ToDouble(args[2]);
                    if (((Convert.ToDouble(args[0]) % 1) == 0) && ((Convert.ToDouble(args[1]) % 1) == 0)&&fibonacci.CheckIfExists(first, second, len))
                    {
                      fibonacci.PrintSequence(fibonacci.CalculateSequence(first, second, len));
                    }
                    else
                    {
                        Console.WriteLine("First 2 arguments have to be non-negative integer values that belong to Fibonacci's sequence and the third argument,length of sequence to display, must be a positive integer value bigger than 2. Please make sure that the first argument is smaller than the second argument and both of them belong to Fibonacci's sequence.");
                    }
                }
                catch
                {   
                    Console.WriteLine("First 2 arguments have to be non-negative integer values and the third argument must be a positive integer value bigger than 2.");
                    
                }

            }
        }
    }
}
