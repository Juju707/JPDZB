using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace Z6
{
    ///<summary>
    /// The File Operations class.
    /// Contains all methods for operations on file.
    ///</summary>
    /// <remarks>
    /// <para>This class can check if a file exists at given directory, get content of a file into a list and compare two lists.</para>
    /// <para>These operations are performed on strings and lists.</para>
    /// </remarks>
    public class FileOperations
    {
        /// <summary>
        /// Check if file with given name or at given directory exists 
        /// </summary>
        /// <param name="name1">A string</param>
        /// <param name="name2">A string</param>
        /// <returns>
        /// A boolean value to validate whether file exists at given directory
        /// </returns>
        public Boolean CheckIfExists(String name1, String name2)
        {
            if ((File.Exists(name1) || File.Exists(name1)) && (File.Exists(name2) || File.Exists(name2))) return true;
            return false;
        }
        /// <summary>
        /// Reads words from a file and gets all distinct words
        /// Uses regular expressions to replace characters that are not letters or numbers with spaces.
        /// Then split the text into words and use LINQ to get the unique words.
        /// </summary>
        /// <param name="fileName">A string</param>
        /// <returns> A list with distinct words from file</returns>
        public List<string> GetWords(string fileName)
        {
            string text = File.ReadAllText(fileName);
            Regex reg_exp = new Regex("[^a-zA-Z]");
            text = reg_exp.Replace(text, " ");
            Regex.Replace(text, @"\s+", " ");
            string[] words = text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var query = (from string word in words orderby word select word).Distinct();
            return query.ToList().ConvertAll(d => d.ToLower());
        }
        /// <summary>
        /// Finds words occuring in both lists and makes a list out of them in alphabetical order
        /// </summary>
        /// <param name="list1">A list of strings</param>
        /// <param name="list2">A list of strings</param>
        /// <returns>A list with words appearing on both lists</returns>
        public List<string> GetReccuringWords(List<string> list1, List<string> list2)
        {
            var result = list1.Intersect(list2);
            return result.OrderBy(x => x).ToList();
        }
        /// <summary>
        /// Prints a list
        /// </summary>
        /// <param name="list">A list of strings</param>
        public void printList(List<string> list)
        {
            Console.WriteLine("Words appearing in both files: ");
            list.ForEach(Console.WriteLine);
        }

    }

    ///<summary>
    /// The main class.
    /// Performs operations compatible with user's input.
    ///</summary>
    class Zadanie6
        {
        /// <summary>
        /// Checks if all of the arguments have been given
        /// Checks if both files exist and if so reads content from both.
        /// Contents are stored in lists of strings that are compared and words occuring in both of then are stored in final list
        /// That list is sorted alphabetically and then displayed in command line
        /// An error is caught if given any file name has incorrect format,a proper comment is shown
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
            {
            if (args.Length != 2)
                {
                    Console.WriteLine("The function requires 2 arguments(names of files).");
                    Console.ReadKey();
                }
                else
                {
                    FileOperations fo = new FileOperations();

                    if (fo.CheckIfExists(args[0], args[1]))
                    {
                        List<string> list1 = fo.GetWords(args[0]);
                        List<string> list2 = fo.GetWords(args[1]);
                        List<string> finalList = fo.GetReccuringWords(list1, list2);
                        fo.printList(finalList);

                    }
                    else
                    {
                        Console.WriteLine("A given name has incorrect format. Example of correct format: MyFile.txt");
                        Console.ReadKey();
                    }
                }
            }

        }
    
}
