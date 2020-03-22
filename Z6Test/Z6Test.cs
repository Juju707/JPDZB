using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Z6;

namespace Z6Test
{
    [TestClass]
    public class Z6Test
    {
        [TestMethod]
        public void WordsInBothLists()
        {
            // Arrange
            List<string> list1 = new List<string>{"math","biology","dog","random","eh" };
            List<string> list2 = new List<string>{"dog","cat","random","math", "help"};
            FileOperations fo = new FileOperations();
            //Act
            List<string> result = fo.GetReccuringWords(list1,list2);
            //Assert
            List<string> expected= new List<string>() { "dog","math","random" };
            CollectionAssert.AreEqual(expected, result);


        }
        [TestMethod]
        public void GetAllWords()
        {
            // Arrange
            List<string> expected = new List<string> {"bioinformatyka","biomedyczna", "dziedzina"  ,"interdyscyplinarna","inzynieria","jest","medycyna","nauk","rehabilitacja","terapia" };
            string fileName = "File1.txt";
            FileOperations fo = new FileOperations();
            //Act
            List<string> result = fo.GetWords(fileName);
            //Assert
            CollectionAssert.AreEqual(expected, result);

        }
        [TestMethod]
        public void FileExists()
        {
            // Arrange
            string fileName1 = "File3.txt";
            string fileName2 = "File1.txt";
            FileOperations fo = new FileOperations();
            bool expected = false;
            //Act
            bool result=fo.CheckIfExists(fileName1,fileName2);

            //Assert
            Assert.AreEqual(expected, result);
        }
    }
}
