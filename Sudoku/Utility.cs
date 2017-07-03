using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Sudoku
{
    public static class Utility
    {
        public static void ReadFromFile(string path,int[,] board)
        {
            StringBuilder sb = new StringBuilder();

            List<string> lines = File.ReadLines(path).Where(s=>!string.IsNullOrEmpty(s.Trim())).ToList();

            if (lines.Count != 9)
            {
                throw new Exception("invalid file format.");
            }
            
            for (int i = 0; i < 9; ++i)
            {
                List<int> lineNumbers = new List<int>();

                try {
                    int lineNumber = Convert.ToInt32(lines[i]);

                    lineNumbers = GetIntArray(lineNumber);

                    for (int j = 0; j < 9; ++j)
                    {
                        board[i, j] = lineNumbers[j];
                    }

                    sb.Clear();
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
