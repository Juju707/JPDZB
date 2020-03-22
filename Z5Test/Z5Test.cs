using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Z5;
namespace Z5Test
{
    [TestClass]
    public class Z5Test
    {
        [TestMethod]
        public void GetDt()
        {
            // Arrange
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("Word", typeof(string)));
            dt.Columns.Add(new DataColumn("Count", typeof(int)));
            var vowels = new HashSet<char> { 'a', 'e', 'i', 'o', 'u' };
            DataRow dr1 = dt.NewRow();
            dr1["Word"] = "kot";
            dr1["Count"] = 1;
            dt.Rows.Add(dr1);
            FileOperations fo = new FileOperations();
            //Act
            DataTable result = fo.GetDataTable("MyFile.txt");
            //Assert
            Assert.AreEqual(dt.Rows[0][0], result.Rows[0][0]);
            Assert.AreEqual(dt.Rows[0][1], result.Rows[0][1]);


        }
        [TestMethod]
        public void CountVowels()
        {
            // Arrange
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("Word", typeof(string)));
            dt.Columns.Add(new DataColumn("Count", typeof(int)));
            var vowels = new HashSet<char> { 'a', 'e', 'i', 'o', 'u' };
            string word = "kot";
            int expectedInt = 1;
            FileOperations fo = new FileOperations();
            //Act
            fo.CountVowels(vowels, dt, word);
            //Assert
            Assert.AreEqual(dt.Rows[0][0], word);
            Assert.AreEqual(dt.Rows[0][1], expectedInt);

        }
        [TestMethod]
        public void WriteToFile()
        {
            // Arrange
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("Word", typeof(string)));
            dt.Columns.Add(new DataColumn("Count", typeof(int)));
            DataRow dr = dt.NewRow();
            dr["Word"] = "kot";
            dr["Count"] = 1;
            dt.Rows.Add(dr);
            FileOperations fo = new FileOperations();
            
            //Act
            fo.WriteFile(dt,"MyFile.txt");
            DataTable result=fo.GetDataTable("MyFile.txt");

            //Assert
            Assert.AreEqual(dt.Rows[0][0], dr[0]);
            Assert.AreEqual(dt.Rows[0][1], dr[1]);
        }
        [TestMethod]
        public void CreateNewFile()
        {
            // Arrange
            Random random = new Random();
            string fileName ="RandomFileName.txt";
            FileOperations fo = new FileOperations();
            //Act
            fo.CreateFile(fileName);
            //Assert
            bool result=fo.CheckIfExists(fileName);
            bool expected = true;
            Assert.AreEqual(result, expected);
        }
        [TestMethod]
        public void FileExists()
        {
            // Arrange
            
            string fileName = "MyFile.txt";
            FileOperations fo = new FileOperations();
            bool expected = true;
            //Act
            bool result = fo.CheckIfExists(fileName);

            //Assert
            Assert.AreEqual(expected, result);
        }
    }
}
