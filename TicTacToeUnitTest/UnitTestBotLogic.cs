using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TicTacToe;
using TicTacToeCommon;


namespace TicTacToeUnitTest
{

    [TestClass]
    public class UnitTestBotLogic
    {
        // fields
        private BotLogic _botLogic;
        private GameBoard _gameBoard;
        private Player _player;

        public UnitTestBotLogic()
        {
            _botLogic = new BotLogic();
            _gameBoard = new GameBoard();
            _player = new Player { PlayerFirstName = "Bot", PlayerID = 666, PlayerLastName = "Boy", PlayerType = PlayerType.Bot, PlayerToken = 'X' };
        }

        [TestMethod]
        public void Check_For_First_Move()
        {

            // arrange
            bool _expected = false;
            bool _actual = false; 

            // act
            // this should back are true because the board state should be default state of
            // a new game
            _actual = _botLogic.IsFirstMove(_gameBoard.BoardState);

            // assert
            Assert.AreNotEqual(_expected, _actual);

        }

        [TestMethod]
        public void PreventLoss_Diagonal_1_and_9_Block_At_5() 
        {
            // arrange
            string _expected = "5";
            string _actual = "";        
            _gameBoard.BoardState[0, 0] = 'O';
            _gameBoard.BoardState[2, 2] = 'O';

            // act
            _actual = _botLogic.Analyze(_gameBoard.BoardState, _player);

            // assert
            Assert.AreEqual(_expected, _actual);        
        }


        [TestMethod]
        public void PreventLoss_Diagonal_7_and_3_Block_At_5()
        {
            // arrange
            string _expected = "5";
            string _actual = "";
            _gameBoard.BoardState[2, 0] = 'O';
            _gameBoard.BoardState[0, 2] = 'O';

            // act
            _actual = _botLogic.Analyze(_gameBoard.BoardState, _player);

            // assert
            Assert.AreEqual(_expected, _actual);
        }


        [TestMethod]
        public void PreventLoss_Diagonal_1_and_5_Block_At_9()
        {
            // arrange
            string _expected = "9";
            string _actual = "";
            _gameBoard.BoardState[0, 0] = 'O'; 
            _gameBoard.BoardState[1, 1] = 'O';  

            // act
            _actual = _botLogic.Analyze(_gameBoard.BoardState, _player);

            // assert
            Assert.AreEqual(_expected, _actual);
        }

        [TestMethod]
        public void PreventLoss_Diagonal_3_and_5_Block_At_7()
        {
            // arrange
            string _expected = "7";
            string _actual = "";
            _gameBoard.BoardState[0, 2] = 'O'; 
            _gameBoard.BoardState[1, 1] = 'O';  

            // act
            _actual = _botLogic.Analyze(_gameBoard.BoardState, _player);

            // assert
            Assert.AreEqual(_expected, _actual);
        }


        [TestMethod]
        public void PreventLoss_Diagonal_7_and_5_Block_At_3()
        {
            // arrange
            string _expected = "3";
            string _actual = "";
            _gameBoard.BoardState[2, 0] = 'O'; 
            _gameBoard.BoardState[1, 1] = 'O';  

            // act
            _actual = _botLogic.Analyze(_gameBoard.BoardState, _player);

            // assert
            Assert.AreEqual(_expected, _actual);
        }


        [TestMethod]
        public void PreventLoss_Diagonal_9_and_5_Block_At_9()
        {
            // arrange
            string _expected = "1";
            string _actual = "";
            _gameBoard.BoardState[2, 2] = 'O'; 
            _gameBoard.BoardState[1, 1] = 'O';  

            // act
            _actual = _botLogic.Analyze(_gameBoard.BoardState, _player);

            // assert
            Assert.AreEqual(_expected, _actual);
        }


        [TestMethod]
        public void PreventLoss_Horizonal_1_and_2_Block_At_3()
        {
            // arrange
            string _expected = "3";
            string _actual = "";
            _gameBoard.BoardState[0, 0] = 'O'; 
            _gameBoard.BoardState[0, 1] = 'O';  

            // act
            _actual = _botLogic.Analyze(_gameBoard.BoardState, _player);

            // assert
            Assert.AreEqual(_expected, _actual);
        }

        [TestMethod]
        public void PreventLoss_Horizonal_1_and_3_Block_At_2()
        {
            // arrange
            string _expected = "2";
            string _actual = "";
            _gameBoard.BoardState[0, 0] = 'O';
            _gameBoard.BoardState[0, 2] = 'O';

            // act
            _actual = _botLogic.Analyze(_gameBoard.BoardState, _player);

            // assert
            Assert.AreEqual(_expected, _actual);
        }

        [TestMethod]
        public void PreventLoss_Horizonal_2_and_3_Block_At_1()
        {
            // arrange
            string _expected = "1";
            string _actual = "";
            _gameBoard.BoardState[0, 1] = 'O';
            _gameBoard.BoardState[0, 2] = 'O';

            // act
            _actual = _botLogic.Analyze(_gameBoard.BoardState, _player);

            // assert
            Assert.AreEqual(_expected, _actual);
        }

        [TestMethod]
        public void PreventLoss_Horizonal_4_and_5_Block_At_6()
        {
            // arrange
            string _expected = "6";
            string _actual = "";
            _gameBoard.BoardState[1, 0] = 'O';
            _gameBoard.BoardState[1, 1] = 'O';

            // act
            _actual = _botLogic.Analyze(_gameBoard.BoardState, _player);

            // assert
            Assert.AreEqual(_expected, _actual);
        }

        [TestMethod]
        public void PreventLoss_Horizonal_4_and_6_Block_At_5()
        {
            // arrange
            string _expected = "5";
            string _actual = "";
            _gameBoard.BoardState[1, 0] = 'O';
            _gameBoard.BoardState[1, 2] = 'O';

            // act
            _actual = _botLogic.Analyze(_gameBoard.BoardState, _player);

            // assert
            Assert.AreEqual(_expected, _actual);
        }

        [TestMethod]
        public void PreventLoss_Horizonal_5_and_6_Block_At_4()
        {
            // arrange
            string _expected = "4";
            string _actual = "";
            _gameBoard.BoardState[1, 1] = 'O';
            _gameBoard.BoardState[1, 2] = 'O';

            // act
            _actual = _botLogic.Analyze(_gameBoard.BoardState, _player);

            // assert
            Assert.AreEqual(_expected, _actual);
        }



        [TestMethod]
        public void PreventLoss_Horizonal_7_and_8_Block_At_9()
        {
            // arrange
            string _expected = "9";
            string _actual = "";
            _gameBoard.BoardState[2, 0] = 'O';
            _gameBoard.BoardState[2, 1] = 'O';

            // act
            _actual = _botLogic.Analyze(_gameBoard.BoardState, _player);

            // assert
            Assert.AreEqual(_expected, _actual);
        }


        [TestMethod]
        public void PreventLoss_Horizonal_8_and_9_Block_At_7()
        {
            // arrange
            string _expected = "7";
            string _actual = "";
            _gameBoard.BoardState[2, 1] = 'O';
            _gameBoard.BoardState[2, 2] = 'O';

            // act
            _actual = _botLogic.Analyze(_gameBoard.BoardState, _player);

            // assert
            Assert.AreEqual(_expected, _actual);
        }

        [TestMethod]
        public void PreventLoss_Horizonal_7_and_9_Block_At_8()
        {
            // arrange
            string _expected = "8";
            string _actual = "";
            _gameBoard.BoardState[2, 0] = 'O';
            _gameBoard.BoardState[2, 2] = 'O';

            // act
            _actual = _botLogic.Analyze(_gameBoard.BoardState, _player);

            // assert
            Assert.AreEqual(_expected, _actual);
        }



        [TestMethod]
        public void PreventLoss_Vertical_1_and_4_Block_At_7()
        {
            // arrange
            string _expected = "7";
            string _actual = "";
            _gameBoard.BoardState[0, 0] = 'O';
            _gameBoard.BoardState[1, 0] = 'O';

            // act
            _actual = _botLogic.Analyze(_gameBoard.BoardState, _player);

            // assert
            Assert.AreEqual(_expected, _actual);
        }


        [TestMethod]
        public void PreventLoss_Vertical_1_and_7_Block_At_4()
        {
            // arrange
            string _expected = "4";
            string _actual = "";
            _gameBoard.BoardState[0, 0] = 'O';
            _gameBoard.BoardState[2, 0] = 'O';

            // act
            _actual = _botLogic.Analyze(_gameBoard.BoardState, _player);

            // assert
            Assert.AreEqual(_expected, _actual);
        }


        [TestMethod]
        public void PreventLoss_Vertical_4_and_7_Block_At_1()
        {
            // arrange
            string _expected = "1";
            string _actual = "";
            _gameBoard.BoardState[1, 0] = 'O';
            _gameBoard.BoardState[2, 0] = 'O';

            // act
            _actual = _botLogic.Analyze(_gameBoard.BoardState, _player);

            // assert
            Assert.AreEqual(_expected, _actual);
        }


        [TestMethod]
        public void PreventLoss_Vertical_2_and_5_Block_At_8()
        {
            // arrange
            string _expected = "8";
            string _actual = "";
            _gameBoard.BoardState[0, 1] = 'O';
            _gameBoard.BoardState[1, 1] = 'O';

            // act
            _actual = _botLogic.Analyze(_gameBoard.BoardState, _player);

            // assert
            Assert.AreEqual(_expected, _actual);
        }

        [TestMethod]
        public void PreventLoss_Vertical_2_and_8_Block_At_5()
        {
            // arrange
            string _expected = "5";
            string _actual = "";
            _gameBoard.BoardState[0, 1] = 'O';
            _gameBoard.BoardState[2, 1] = 'O';

            // act
            _actual = _botLogic.Analyze(_gameBoard.BoardState, _player);

            // assert
            Assert.AreEqual(_expected, _actual);
        }

        [TestMethod]
        public void PreventLoss_Vertical_5_and_8_Block_At_2()
        {
            // arrange
            string _expected = "2";
            string _actual = "";
            _gameBoard.BoardState[1, 1] = 'O';
            _gameBoard.BoardState[2, 1] = 'O';

            // act
            _actual = _botLogic.Analyze(_gameBoard.BoardState, _player);

            // assert
            Assert.AreEqual(_expected, _actual);
        }



        [TestMethod]
        public void PreventLoss_Vertical_3_and_6_Block_At_9()
        {
            // arrange
            string _expected = "9";
            string _actual = "";
            _gameBoard.BoardState[0, 2] = 'O';
            _gameBoard.BoardState[1, 2] = 'O';

            // act
            _actual = _botLogic.Analyze(_gameBoard.BoardState, _player);

            // assert
            Assert.AreEqual(_expected, _actual);
        }


        [TestMethod]
        public void PreventLoss_Vertical_3_and_9_Block_At_6()
        {
            // arrange
            string _expected = "6";
            string _actual = "";
            _gameBoard.BoardState[0, 2] = 'O';
            _gameBoard.BoardState[2, 2] = 'O';

            // act
            _actual = _botLogic.Analyze(_gameBoard.BoardState, _player);

            // assert
            Assert.AreEqual(_expected, _actual);
        }


        [TestMethod]
        public void PreventLoss_Vertical_6_and_9_Block_At_3()
        {
            // arrange
            string _expected = "3";
            string _actual = "";
            _gameBoard.BoardState[1, 2] = 'O';
            _gameBoard.BoardState[2, 2] = 'O';

            // act
            _actual = _botLogic.Analyze(_gameBoard.BoardState, _player);

            // assert
            Assert.AreEqual(_expected, _actual);
        }






    }
}
