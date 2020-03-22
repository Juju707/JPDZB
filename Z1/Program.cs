using System;


namespace Z1
{
    ///<summary>
    /// The Triangle class.
    /// Contains all methods for performing operations on a triangle.
    ///</summary>
    /// <remarks>
    /// <para>This class can check whether triangle with given side's values exists and calculate it's area.</para>
    /// <para>These operations can be performed on both integers and doubles.</para>
    /// </remarks>
    public class Triangle
    {
        /// <summary>
        /// Calculate the area of a triangle with Heron's formula
        /// </summary>
        /// <returns>
        /// The area of a triangle
        /// </returns>
        /// <param name="side1">A double precision number.</param>
        /// <param name="side2">A double precision number.</param>
        /// <param name="side3">A double precision number.</param>
        public double CalculateTriangle(double side1, double side2, double side3)
        {
            var s = 0.5 * (side1 + side2 + side3);
            return Math.Sqrt(s * (s - side1) * (s - side2) * (s - side3));
        }
        /// <summary>
        /// Checks the condition for the existence of the triangle
        /// </summary>
        /// <returns>
        /// The validation whether triangle with given sides exists
        /// </returns>
        /// <param name="side1">A double precision number.</param>
        /// <param name="side2">A double precision number.</param>
        /// <param name="side3">A double precision number.</param>
        public bool CheckIfExists(double side1, double side2, double side3)
        {
            var a = side2 + side3;
            var b = side1 + side2;
            var c = side1 + side3;
            if (side1 < a && side3 < b && side2 < c) return true;
            return false;
        }
    }

    ///<summary>
    /// The main class.
    /// Performs operations compatible with user's input.
    ///</summary>
    class Zadanie1
    {
        /// <summary>
        ///Checks if all of the arguments have been given
        ///Validates whether the traingle can even exist
        ///An error is caught if even one of values is not numeric or the values does not meet the condition for triangle's existence
        ///Accordingly to the source of problem, appropriate comment is shown
        ///If triangle can exist it's area is displayed
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            var triangle = new Triangle();
            if (args.Length != 3)
            {
                Console.WriteLine("The function requires 3 numeric arguments, one for each side of a triangle.");
            }
            else
            {
                try
                {
                    if (triangle.CheckIfExists(Convert.ToDouble(args[0]), Convert.ToDouble(args[1]), Convert.ToDouble(args[2])))
                    {
                        Console.WriteLine("The area of triangle is {0}" , Math.Round(triangle.CalculateTriangle(Convert.ToDouble(args[0]), Convert.ToDouble(args[1]), Convert.ToDouble(args[2])), 3));
                    }
                    else
                    {
                        Console.WriteLine("Triangle does not exist. Please enter different values.");
                    }
                }
                catch
                {
                    Console.WriteLine("All 3 arguments have to be positive numeric values");
                }

            }
        }
    }
}
