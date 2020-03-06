using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TicTacToeUnitTest
{
    [TestClass]
    public class UnitTestBoard
    {

        public char[,] CharArray3By3 { get; set; }

        private TestContext testContextInstance;

        public TestContext TestContext
        {
            get { return testContextInstance; }
            set { testContextInstance = value; }
        }

        // constructor
        public UnitTestBoard() 
        {

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
        public void Number_Of_Starting_Board()
        {
            // arrange         
            int _total = 0;
            foreach (var item in CharArray3By3)
            {
                _total = _total + Convert.ToInt32(item);
            }
            int _expected = 45; // starting board with  1-- 9 spot holders

            // act
            TestContext.WriteLine("Start board total: " + _total.ToString());

            // assert
            Assert.AreEqual(_expected, _total);
        }


        [TestMethod]
        public void Total_for_X_Draw() 
        {

            // arrange
            // 5x's and 4o's
            Char _currentChar = 'X';
            int _switchPoint = 1;
            int _total = 0;
            int _expected = 756;

            for (int row = 0; row < 3; row++)
            {
                for (int cell = 0; cell < 3; cell++)
                {
                    CharArray3By3[row, cell] = _currentChar;
                    if (_switchPoint == 5) 
                    {
                        _currentChar = 'O';
                    }
                    _switchPoint++;
                }
            }

            // act
            // calculate the total
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    _total = _total + Convert.ToInt32(CharArray3By3[i, j]);
                }
            }

            // assert
            TestContext.WriteLine("Total: " + _total.ToString());
            Assert.AreEqual(_expected, _total);

        }




    }
}
