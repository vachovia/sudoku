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
            bool isValidSudoku = false;
            bool isValidInput = false;

            OpenFileDialog dlg = new OpenFileDialog();

            dlg.Title = "Open A Sudoku Puzzle";
            dlg.Filter = "Sudoku Puzzle|*.txt;*.sud";

            if(dlg.ShowDialog() == DialogResult.OK){
                path = dlg.FileName;                
                try {
                    List<List<int>> allNumbers = Utility.ReadFromFile(path);
                    isValidInput = Utility.ValidateInput(allNumbers);
                    if(isValidInput)
                    {
                        isValidSudoku = Validator.isValidSudoku(allNumbers);
                        Console.WriteLine("{0}: input file is {1} sudoku solution", isValidSudoku, isValidSudoku ? "a valid" : "an invalid");
                        Console.ReadLine();
                    }
                    else
                    {
                        throw new Exception("invaild sudoku file format");
                    }
                    
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