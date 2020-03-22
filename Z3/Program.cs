using System;
using System.Collections.Generic;

namespace Z3
{
    ///<summary>
    /// The Geometric sequence class.
    /// Contains all methods for performing operations on numbers from geometric sequence.
    ///</summary>
    /// <remarks>
    /// <para>This class can calculate sequence from given values.</para>
    /// <para>These operations are performed on integers or doubles.</para>
    /// </remarks>
    public class Sequence
    {
        /// <summary>
        /// Calculate the n next elements in geometric sequence
        /// </summary>
        /// <returns>
        /// The array of n numbers.
        /// </returns>
        /// <param name="a0">A double precision number.</param>
        /// <param name="q">A double precision number.</param>
        /// <param name="n">A double precision number.</param>
        public double[] CalculateSequence(double a0, double q, int n)
        {
            double[] sequence = new double[n];
            sequence[0] = a0;
            for (int i = 0; i < n-1; i++)
            {
                sequence[i + 1] = sequence[i] * q;
            }
            return sequence;
        }
        /// <summary>
        /// Checks the condition for the sequence
        /// </summary>
        /// <returns>
        /// The validation whether sequence can be calculated
        /// </returns>
        /// <param name="n">A single precision number.</param>
        public Boolean CheckIfExists(int n)
        {
            if (n > 0)return true;
            return false;
        }
        /// <summary>
        /// Prints an array of numbers with double precision for sequence with given values
        /// </summary>
        public void PrintSequence(double[] sequence,double a0,double q,int n)
        {
            string[] stringSequence = new string[sequence.Length];
            for (int i = 0; i < sequence.Length; i++)
            {
                stringSequence[i] = sequence[i].ToString("0.00");
            }
            Console.WriteLine("For a0= {0}, q={1} and n={2}, your sequence is [{3}]", a0.ToString(),q.ToString(),n.ToString(),string.Join(" ; ", stringSequence));
            Console.ReadKey();
        }

    }
    ///<summary>
    /// The main class.
    /// Performs operations compatible with input in lists.
    ///</summary>
    class Zadanie3
    {
        /// <summary>
        ///Takes values from lists in loop  (Condition: All lists have the same length or at least the nList is the shortest)
        ///An error is caught if even one of values is not numeric or the values does not meet the condition for sequence's existence
        ///Accordingly to the source of problem, appropriate comment is shown
        ///If sequence can be calculated, it's n elements are displayed
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            List<double> a0List = new List<double>() { 3, -1.5, -4.3, 1.7 };
            List<double> qList = new List<double>() { 2, 3, -4, -0.3 };
            List<int> nList = new List<int>() { 5, 4, 7, 5 };
            var sequence = new Sequence();
            for (int i = 0; i < nList.Count; i++)
            {
                try
                {
                    var sequenceExists = sequence.CheckIfExists(nList[i]);
                    if (sequenceExists)
                    {
                        sequence.PrintSequence(sequence.CalculateSequence(a0List[i],qList[i],nList[i]), a0List[i], qList[i], nList[i]);
                    }
                    else
                    {
                        Console.WriteLine("This sequence doesn not exist. Length of sequence must be a positive integer value");
                    }
                }
                catch
                {
                    Console.WriteLine("The first two arguments (a0,q) must be numeric values and third argument (length of sequence) should be a positive integer value.");
                }
            }

        }

    }
}
