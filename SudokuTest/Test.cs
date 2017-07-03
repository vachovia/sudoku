using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace SudokuTest
{
    [TestClass]
    public class Test
    {
         List<List<int>> validSolution= new List<List<int>>(){ 
                                    new List<int>(){5,3,4,6,7,8,9,1,2}, new List<int>(){6,7,2,1,9,5,3,4,8}, new List<int>(){1,9,8,3,4,2,5,6,7},
                                    new List<int>(){8,5,9,7,6,1,4,2,3}, new List<int>(){4,2,6,8,5,3,7,9,1}, new List<int>(){7,1,3,9,2,4,8,5,6},
                                    new List<int>(){9,6,1,5,3,7,2,8,4}, new List<int>(){2,8,7,4,1,9,6,3,5}, new List<int>(){3,4,5,2,8,6,1,7,9}
                              };
         List<List<int>> invalidSolution = new List<List<int>>(){ 
                                    new List<int>(){5,3,4,6,7,8,9,1,3}, new List<int>(){6,7,2,1,9,5,3,4,8}, new List<int>(){1,9,8,3,4,2,5,6,7},
                                    new List<int>(){8,5,9,7,6,1,4,2,3}, new List<int>(){4,2,6,8,5,3,7,9,1}, new List<int>(){7,1,3,9,2,4,8,5,6},
                                    new List<int>(){9,6,1,5,3,7,2,8,4}, new List<int>(){2,8,7,4,1,9,6,3,5}, new List<int>(){3,4,5,2,8,6,1,7,9}
                              };

         List<List<int>> invalidInput = new List<List<int>>(){ 
                                    new List<int>(){5,3,4,6,7,8,9}, 
                              };
         [TestMethod]
         public void InvalidInput()
         {
             Assert.IsFalse(
                 Sudoku.Utility.ValidateInput(invalidInput)
             );
         }

         [TestMethod]
         public void ValidInput()
         {
             Assert.IsTrue(
                 Sudoku.Utility.ValidateInput(invalidSolution)
             );

             Assert.IsTrue(
                 Sudoku.Utility.ValidateInput(validSolution)
             );
         }

         [TestMethod]
         public void ValidateSudoku()
         {
             Assert.IsFalse(
                Sudoku.Validator.isValidSudoku(invalidSolution)
             );

             Assert.IsTrue(
                Sudoku.Validator.isValidSudoku(validSolution)
             );

             Assert.IsFalse(
                Sudoku.Validator.isValidSudoku(invalidInput)
             );
         }
    }
}
