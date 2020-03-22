using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Z4;
namespace Z4Test
{
    [TestClass]
    public class Z4Test
    {
        [TestMethod]
        public void CalculatedMatrices()
        {
            // Arrange
            List<int> nArgValues = new List<int>() { 6, 3, 1};
            MultiplicationArray matrix = new MultiplicationArray();
            List<double[,]> results = new List<double[,]>();
            //Act
            for (int i = 0; i < 3; i++)
            {
                results.Add(matrix.CalculateArray( nArgValues[i]));
            }
            //Assert
            List<double[,]> expected = new List<double[,]>() {
                new double[,] { { 0, 1, 2, 3, 4, 5, 6 }, { 1, 1, 2, 3, 4, 5, 6 }, { 2, 2, 4, 6, 8, 10, 12 }, { 3, 3, 6, 9, 12, 15, 18 },{ 4, 4, 8, 12, 16, 20, 24 },{ 5, 5, 10, 15, 20, 25, 30 },{ 6, 6, 12, 18, 24, 30, 36 } },
                new double[,] {{ 0, 1, 2, 3 },{ 1, 1, 2, 3 },{ 2, 2, 4, 6 },{ 3, 3, 6, 9} },
                new double[,] { {0,1},{ 1, 1 } }
            };
            for (int n= 0;n < 3;n++)
            {
                CollectionAssert.AreEqual(expected[n].Cast<double>().ToArray(),
                                          results[n].Cast<double>().ToArray(),
                                          StructuralComparisons.StructuralComparer);
            }
            
        }
        [TestMethod]
        public void MatrixExists()
        {
            // Arrange
            List<double> nArgValues = new List<double>() { 6, 1.2, 0, -4, -0.3 };
            MultiplicationArray matrix = new MultiplicationArray();
            List<bool> results = new List<bool>();
            //Act
            for (int i = 0; i < 5; i++)
            {
                results.Add(matrix.CheckIfExists(nArgValues[i]));
            }
            //Assert
            List<bool> expected = new List<bool>() { true, false, false, false, false };

            CollectionAssert.AreEqual(expected, results);
        }
    }
}
