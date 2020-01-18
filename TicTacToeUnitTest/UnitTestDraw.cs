using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TicTacToeUnitTest
{
    [TestClass]
    public class UnitTestDraw
    {

        public char[,] CharArray3By3 { get; set; }

        public UnitTestDraw() {

            CharArray3By3 = new char[3, 3];

            int counter = 1;
            for (int row = 0; row < 3; row++)
            {
                for (int cell = 0; cell < 3; cell++)
                {
                    CharArray3By3[row, cell] = Convert.ToChar(counter);
                    counter++;
                }
            }
        
        }

        [TestMethod]
        public void Draw_All_XXX()
        {

            // arrange         
            int number = (int)CharArray3By3[0, 0] + (int)CharArray3By3[0, 1] + (int)CharArray3By3[0, 2] + (int)CharArray3By3[1, 0] +
            (int)CharArray3By3[1, 1] + (int)CharArray3By3[1, 2] + (int)CharArray3By3[2, 0] + (int)CharArray3By3[2, 1] + (int)CharArray3By3[2, 2];
            Console.WriteLine("winner1 is " + number);

            // act




            // assert

        }
    }
}
