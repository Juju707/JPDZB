using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;

namespace Z5
{
    ///<summary>
    /// The File Operations class.
    /// Contains all methods for operations on file
    ///</summary>
    /// <remarks>
    /// <para>This class can create a file,check if a file exists at given directory, get content of a file into a datatable,count vovels in a line that is to be added to a file and write to file.</para>
    /// <para>These operations are performed on strings and datatables.</para>
    /// </remarks>
    public class FileOperations
    {
        /// <summary>
        /// Create file with given name or at given directory.
        /// </summary>
        /// <param name="fileName">A string.</param>
        public void CreateFile(String fileName)
        {
            FileStream fs = File.Create(fileName);
            fs.Close();
        }
        /// <summary>
        /// Check if file with given name or at given directory exists 
        /// </summary>
        /// <returns>
        /// A boolean value for validation whether file exists
        /// </returns>
        /// <param name="fileName">A string.</param>
        public Boolean CheckIfExists(String name)
        {
            if (File.Exists(name) || File.Exists(name)) return true;
            return false;
        }
        /// <summary>
        /// Read file and create datatable with words in the first column and number of vowels in the second column.
        /// File must be formatted in the following manner: Word [tab] Number
        /// </summary>
        /// <returns>
        /// A data table containing words and the counted vowels, read from text file
        /// </returns>
        /// <param name="fileName">A string.</param>
        public DataTable GetDataTable(string fileName)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("Word", typeof(string)));
            dt.Columns.Add(new DataColumn("Count", typeof(int)));

            string[] lines = System.IO.File.ReadAllLines(fileName);

            foreach (string line in lines)
            {
                var words = line.Split('\t');
                DataRow dr = dt.NewRow();
                for (int i = 0; i < 2; i++) { dr[i] = words[i];}
                dt.Rows.Add(dr);
            }
            return dt;
        }
        /// <summary>
        /// Add new row to datatable.
        /// Checks if word has already appeared in the datatable and counts the vowels if not. The word and it's value are then added to datatable
        /// </summary>
        /// <returns>
        /// A datatable with new row if the word hasn't appeared yet
        /// </returns>
        /// <param name="vowels">A hash set.</param>
        /// <param name="dt">A datatable.</param>
        /// <param name="word">A string</param>
        public DataTable CountVowels(HashSet<char> vowels, DataTable dt, string word)
        {
            bool contains = dt.AsEnumerable().Any(row => word == row.Field<String>("Word"));
            if (!contains) { 
            int total = word.Count(c => vowels.Contains(c));
            dt.Rows.Add(word, total);
            }
            return dt;
        }
        /// <summary>
        /// Write datatable to file
        /// Writes the datatable to file. Each row is formatted in the following manner:Word [tab] Number
        /// </summary>
        /// <param name="dt">A datatable.</param>
        /// <param name="fileName">A string.</param>
        public void WriteFile(DataTable dt, string fileName)
        {
            {
                StreamWriter sw =  new StreamWriter(fileName, false);
                foreach (DataRow row in dt.Rows)
                {
                    object[] array = row.ItemArray;
                    for (int i = 0; i < array.Length; i++)
                    {
                        sw.Write(array[i].ToString() + "\t");
                    }
                    sw.WriteLine();
                }
                sw.Close();
            }
        }

    }
    ///<summary>
    /// The main class.
    /// Performs operations compatible with user's input.
    ///</summary>
    class Zadanie5
    {
        /// <summary>
        ///Checks if all of the arguments have been given
        ///Takes value from user and checks whether file or directory exists
        ///If it does not exist, the file is created and user is free to put any words
        ///If file does exist, all it's content is written to datatable
        ///If the datatable contains wrong format (word tab number) an appropriate comment is shown
        ///To stop input, a word "stop" is required
        ///After stopping, all words gathered in datatable are saved in the text file
        ///An error is caught if given file name has incorrect format,a proper comment is shown
        ///If multiplication matrix can be created, it is displayed with proper formatting
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            
            if (args.Length != 1)
            {
                Console.WriteLine("The function requires 1 argument(name of file).");
                Console.ReadKey();
            }
            else{

                if (args[0].Contains(".txt"))
                {
                    FileOperations fo = new FileOperations();
                    if (!fo.CheckIfExists(args[0]))
                    {
                        fo.CreateFile(args[0]);
                    }try
                    {
                        DataTable dt = fo.GetDataTable(args[0]);
                        var vowels = new HashSet<char> { 'a', 'e', 'i', 'o', 'u' };
                        Console.WriteLine("To stop input and write to file, write 'stop'");
                        do
                        {
                            string word = Console.ReadLine().ToLower();
                            fo.CountVowels(vowels, dt, word);
                        } while (Console.ReadLine().ToLower() != "stop");

                        fo.WriteFile(dt, args[0]);
                    }
                    catch
                    {
                        Console.WriteLine("Please make sure the content in text file is formatted in following way: Word [tab] Value");
                    }
                }
                else
                {
                    Console.WriteLine("A given name has incorrect format.Please make sure there are no spaces in the name. Example of correct format: MyFile.txt");
                }
            }
        }

    }
}
