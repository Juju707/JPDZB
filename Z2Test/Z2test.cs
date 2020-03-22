using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections;
using System.Collections.Generic;
using Z2;
namespace Z2Test
{
    [TestClass]
    public class Z2Test
    {
        [TestMethod]
        public void CalculatedSequences()
        {
            // Arrange
            List<long> firstArgValues = new List<long>() { 0, 1, 5, 233, 28657 };
            List<long> secondArgValues = new List<long>() { 1, 1, 8, 377, 46368 };
            List<double> lenArgValues = new List<double>() { 6, 3, 4, 5, 5 };
            Fibonacci fibonacci = new Fibonacci();
            List<long[]> results = new List<long[]>();
            //Act
            for (int i = 0; i < 5; i++)
            {
                results.Add(fibonacci.CalculateSequence(firstArgValues[i], secondArgValues[i], lenArgValues[i]));
            }
            //Assert
            List<long[]> expected = new List<long[]>() {
                new long[] {0,1,1,2,3,5},
                new long[] { 1, 1, 2 },
                new long[] { 5, 8, 13, 21},
                new long[] { 233, 377, 610, 987, 1597 },
                new long[] { 28657, 46368, 75025, 121393, 196418}
            };
            
            CollectionAssert.AreEqual(expected, results, StructuralComparisons.StructuralComparer);
        }
        [TestMethod]
        public void SequenceExists()
        {
            // Arrange
            List<long> firstArgValues = new List<long>() { 0, 5, 1, 1,-1 };
            List<long> secondArgValues = new List<long>() { 1, 8, 2, 8 ,0};
            List<double> lenArgValues = new List<double>() { 6, 1.5, -7, 1 ,5};
            Fibonacci fibonacci = new Fibonacci();
            List<bool> results = new List<bool>();
            //Act
            for (int i = 0; i < 5; i++)
            {
                results.Add(fibonacci.CheckIfExists(firstArgValues[i],secondArgValues[i],lenArgValues[i]));
            }
            //Assert
            List<bool> expected = new List<bool>() { true, false, false, false,false };
            CollectionAssert.AreEqual(expected, results);
        }
        [TestMethod]
        public void PerfectSquares()
        {
            // Arrange
            List<long> numericValues = new List<long>() { 9, 16, -4, 11 };
            Fibonacci fibonacci = new Fibonacci();
            List<bool> results = new List<bool>();
            //Act
            for (int i = 0; i < 4; i++)
            {
                results.Add(fibonacci.IsPerfectSquare(numericValues[i]));
            }
            //Assert
            List<bool> squared = new List<bool>() { true, true, false, false };
            CollectionAssert.AreEqual(squared, results);
        }
        [TestMethod]
        public void IsAFibonacciNumber()
        {
            // Arrange
            List<long> numericValues = new List<long>() { 1,0,7, 317811};
            Fibonacci fibonacci = new Fibonacci();
            List<bool> results = new List<bool>();
            //Act
            for (int i = 0; i < 4; i++)
            {
                results.Add(fibonacci.IsFibonacci(numericValues[i]));
            }
            //Assert
            List<bool> expected = new List<bool>() { true, true, false, true };
            CollectionAssert.AreEqual(expected, results);
        }
        [TestMethod]
        public void IsANextFibonacciNumber()
        {
            // Arrange
            List<long> firstArgValues = new List<long>() { 1, 5, 7, 1};
            List<long> secondArgValues = new List<long>() { 1, 8, -7, 8 };
            Fibonacci fibonacci = new Fibonacci();
            List<bool> results = new List<bool>();
            //Act
            for (int i = 0; i < 4; i++)
            {
                results.Add(fibonacci.IsNext(firstArgValues[i],secondArgValues[i]));
            }
            //Assert
            List<bool> expected = new List<bool>() { true, true, false, false };
            CollectionAssert.AreEqual(expected, results);
        }
    }
}
