using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Sudoku
{
    public static class Utility
    {
        public static List<List<int>> ReadFromFile(string path)
        {
            List<string> lines = File.ReadLines(path).Where(s=>!string.IsNullOrEmpty(s.Trim())).ToList();

            if (lines.Count != 9)
            {
                throw new Exception("invalid sudoku file format.");
            }

            List<List<int>> allNumbers = new List<List<int>>();
            
            for (int i = 0; i < 9; ++i)
            {
                List<int> lineNumbers = new List<int>();

                try {
                    int lineNumber = Convert.ToInt32(lines[i]);

                    lineNumbers = GetIntArray(lineNumber);

                    allNumbers.Add(lineNumbers);
                }
                catch(FormatException ex)
                {
                    throw new Exception(ex.Message);
                }
                catch(OverflowException ex)
                {
                    throw new Exception(ex.Message);
                }
            }

            return allNumbers;
        }

        public static bool ValidateInput(List<List<int>> allNumbers)
        {
            for (int i = 0; i < 9; ++i)
            {
                if (allNumbers[i].Count != 9)
                {
                    return false;
                }
            }

            return true;
        }

        public static List<int> GetIntArray(int num)
        {
            List<int> listOfInts = new List<int>();

            while (num > 0)
            {
                listOfInts.Add(num % 10);
                num = num / 10;
            }

            listOfInts.Reverse();

            return listOfInts;
        }
    }
}
