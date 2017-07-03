using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sudoku
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            string path;
            bool isValid = false;

            OpenFileDialog dlg = new OpenFileDialog();

            dlg.Title = "Open A Sudoku Puzzle";
            dlg.Filter = "Sudoku Puzzle|*.txt;*.sud";

            if(dlg.ShowDialog() == DialogResult.OK){
                path = dlg.FileName;

                int[,] allNumbers = new int[9, 9];
                try {
                    Utility.ReadFromFile(path, allNumbers);
                    isValid = Validator.isValidSudoku(allNumbers);
                    Console.WriteLine("{0}: input file is {1} sudoku solution", isValid, isValid ? "a valid" : "an invalid");
                    Console.ReadLine();
                }
                catch(Exception ex)
                {
                    Console.WriteLine("False: error while processing file - {0}", ex.Message);
                    Console.ReadLine();
                }                
            }            
        }        
    }
}