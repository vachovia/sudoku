using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku
{
    public static class Validator
    {
        public static bool isValidSudoku(List<List<int>> board)
        {
            for (int i = 0; i < 9; i++)
            {
                HashSet<int> rows = new HashSet<int>();
                HashSet<int> columns = new HashSet<int>();
                HashSet<int> cube = new HashSet<int>();

                for (int j = 0; j < 9; j++)
                {
                    if (!rows.Add(board[i][j]) || !columns.Add(board[j][i])) 
                    {
                        return false;
                    }

                    int RowIndex = 3 * (i / 3); int ColIndex = 3 * (i % 3);

                    if (!cube.Add(board[RowIndex + j / 3][ColIndex + j % 3]))
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
