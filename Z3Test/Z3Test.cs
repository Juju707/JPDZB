using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections;
using System.Collections.Generic;
using Z3;
namespace Z3Test
{
    [TestClass]
    public class Z3Test
    {
        
            [TestMethod]
            public void CalculatedSequences()
            {
                // Arrange
                List<double> a0ArgValues = new List<double>() { 0, 1, -2, 3, 11 };
                List<double> qArgValues = new List<double>() { 1, 1, 4, 3, 2 };
                List<int> nArgValues = new List<int>() { 6, 3, 4, 4, 5 };
                Sequence sequence = new Sequence();
                List<double[]> results = new List<double[]>();
                //Act
                for (int i = 0; i < 5; i++)
                {
                    results.Add(sequence.CalculateSequence(a0ArgValues[i],qArgValues[i],nArgValues[i]));
                }
                //Assert
                List<double[]> expected = new List<double[]>() {
                new double[] {0,0,0,0,0,0},
                new double[] { 1, 1, 1 },
                new double[] { -2, -8, -32, -128},
                new double[] { 3, 9, 27, 81},
                new double[] { 11, 22, 44, 88, 176}
                };

                CollectionAssert.AreEqual(expected, results, StructuralComparisons.StructuralComparer);
            }
        [TestMethod]
        public void SequenceExists()
        {
            // Arrange
            List<int> nArgValues = new List<int>() { 6, 1, 0, -4, -5 };
            Sequence sequence = new Sequence();
            List<bool> results = new List<bool>();
            //Act
            for (int i = 0; i < 5; i++)
            {
                results.Add(sequence.CheckIfExists( nArgValues[i]));
            }
            //Assert
            List<bool> expected = new List<bool>() { true,true,false,false,false};

            CollectionAssert.AreEqual(expected, results);
        }

    }
}
