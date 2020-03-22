using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using Z1;

namespace Z1Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TriangleArea()
        {
            // Arrange
            List<double> side1Values = new List<double>() { 3, 5, 3, 16 };
            List<double> side2Values = new List<double>() { 4, 7, 3, 12 };
            List<double> side3Values = new List<double>() { 5, 4, 3, 20 };
            Triangle triangle = new Triangle();
            List<double> results = new List<double>();
            //Act
            for(int i = 0; i < 4; i++)
            {
                results.Add(Math.Round(triangle.CalculateTriangle(side1Values[i], side2Values[i], side3Values[i]),3));
            }
            //Assert
            List<double> areas=new List<double>() { 6, 9.798, 3.897, 96 };
            CollectionAssert.AreEqual(areas, results);
        }
        [TestMethod]
        public void TriangleExists()
        {
            // Arrange
            List<double> side1Values = new List<double>() { 3, 7, -2, 0.2 };
            List<double> side2Values = new List<double>() { 4, 7, 3, 12 };
            List<double> side3Values = new List<double>() { 5, 4, 4, 26 };
            Triangle triangle = new Triangle();
            List<bool> results = new List<bool>();
            //Act
            for (int i = 0; i < 4; i++)
            {
                results.Add(triangle.CheckIfExists(side1Values[i], side2Values[i], side3Values[i]));
            }
            //Assert
            List<bool> areas = new List<bool>() { true, true, false, false };
            CollectionAssert.AreEqual(areas, results);
        }
    }
}
