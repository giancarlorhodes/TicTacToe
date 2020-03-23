using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToeCommon.Interfaces;

namespace TicTacToeCommon
{
    public class BotLogic : IBotLogic
    {
        public bool IsFirstMove(char[,] inBoardState)
        {
            for (int _row = 0; _row < 3; _row++)
            {
                for (int _cell = 0; _cell < 3; _cell++)
                {
                    if (inBoardState[_row, _cell] != '_')
                        return false;
                }
            }

            return true;
        }

        public string Analyze(char[,] inBoardState, Player inPlayer)
        {

            // this is just the number where the token should go
            string _pickedPosition = null;

            // 1. look for winning move - kill move
            // will return null if no win move
            _pickedPosition = this.WinMove(inBoardState, inPlayer);
            if (_pickedPosition != null) return _pickedPosition; // kill move found, return it


            // 2. prevent loss - defensive move
            // will return null if no save move
            _pickedPosition = this.PreventLoss(inBoardState, inPlayer);
            if (_pickedPosition != null) return _pickedPosition; // save move found, return it

          

            // 3.  best next move - this is the crux
            _pickedPosition = this.NeutralMove(inBoardState, inPlayer); /// this should never return null

            return _pickedPosition;
        
        }


        private string PreventLoss(char[,] inBoardState, Player inCurrentPlayer) 
        {

            // this is just the number where the token should go
            string _pickedThisPosition = null;

            //  simple - look for opposing player with 2 tokens in a line, 
            char _otherPlayerToken = inCurrentPlayer.PlayerToken == 'X' ? 'O' : 'X';


            // look diagonal first
            if (inBoardState[0, 0] == _otherPlayerToken && inBoardState[2, 2] == _otherPlayerToken && inBoardState[1,1] != inCurrentPlayer.PlayerToken)
            {
                return _pickedThisPosition = "5";
            }
            else if (inBoardState[2, 0] == _otherPlayerToken && inBoardState[0, 2] == _otherPlayerToken && inBoardState[1, 1] != inCurrentPlayer.PlayerToken)
            {
                return _pickedThisPosition = "5";
            }
            else if (inBoardState[0, 0] == _otherPlayerToken && inBoardState[1, 1] == _otherPlayerToken && inBoardState[2, 2] != inCurrentPlayer.PlayerToken)
            {
                return _pickedThisPosition = "9";
            }
            else if (inBoardState[0, 2] == _otherPlayerToken && inBoardState[1, 1] == _otherPlayerToken && inBoardState[2, 0] != inCurrentPlayer.PlayerToken)
            {
                return _pickedThisPosition = "7";
            }
            else if (inBoardState[2, 0] == _otherPlayerToken && inBoardState[1, 1] == _otherPlayerToken && inBoardState[0, 2] != inCurrentPlayer.PlayerToken)
            {
                return _pickedThisPosition = "3";
            }
            else if (inBoardState[2, 2] == _otherPlayerToken && inBoardState[1, 1] == _otherPlayerToken && inBoardState[0, 0] != inCurrentPlayer.PlayerToken)
            {
                return _pickedThisPosition = "1";
            }

            // look horizonal
            else if (inBoardState[0, 0] == _otherPlayerToken && inBoardState[0, 1] == _otherPlayerToken && inBoardState[0, 2] != inCurrentPlayer.PlayerToken)
            {
                return _pickedThisPosition = "3";
            }
            else if (inBoardState[0, 0] == _otherPlayerToken && inBoardState[0, 2] == _otherPlayerToken && inBoardState[0, 1] != inCurrentPlayer.PlayerToken)
            {
                return _pickedThisPosition = "2";
            }
            else if (inBoardState[0, 1] == _otherPlayerToken && inBoardState[0, 2] == _otherPlayerToken && inBoardState[0, 0] != inCurrentPlayer.PlayerToken)
            {
                return _pickedThisPosition = "1";
            }
            else if (inBoardState[1, 0] == _otherPlayerToken && inBoardState[1, 1] == _otherPlayerToken && inBoardState[1, 2] != inCurrentPlayer.PlayerToken)
            {
                return _pickedThisPosition = "6";
            }
            else if (inBoardState[1, 0] == _otherPlayerToken && inBoardState[1, 2] == _otherPlayerToken && inBoardState[1, 1] != inCurrentPlayer.PlayerToken)
            {
                return _pickedThisPosition = "5";
            }
            else if (inBoardState[1, 1] == _otherPlayerToken && inBoardState[1, 2] == _otherPlayerToken && inBoardState[1, 0] != inCurrentPlayer.PlayerToken)
            {
                return _pickedThisPosition = "4";
            }
            else if (inBoardState[2, 0] == _otherPlayerToken && inBoardState[2, 1] == _otherPlayerToken && inBoardState[2, 2] != inCurrentPlayer.PlayerToken)
            {
                return _pickedThisPosition = "9";
            }
            else if (inBoardState[2, 1] == _otherPlayerToken && inBoardState[2, 2] == _otherPlayerToken && inBoardState[2, 0] != inCurrentPlayer.PlayerToken)
            {
                return _pickedThisPosition = "7";
            }
            else if (inBoardState[2, 0] == _otherPlayerToken && inBoardState[2, 2] == _otherPlayerToken && inBoardState[2, 1] != inCurrentPlayer.PlayerToken)
            {
                return _pickedThisPosition = "8";
            }


            // look vertical
            else if (inBoardState[0, 0] == _otherPlayerToken && inBoardState[1, 0] == _otherPlayerToken && inBoardState[2, 0] != inCurrentPlayer.PlayerToken)
            {
                return _pickedThisPosition = "7";
            }
            else if (inBoardState[0, 0] == _otherPlayerToken && inBoardState[2, 0] == _otherPlayerToken && inBoardState[1, 0] != inCurrentPlayer.PlayerToken)
            {
                return _pickedThisPosition = "4";
            }
            else if (inBoardState[1, 0] == _otherPlayerToken && inBoardState[2, 0] == _otherPlayerToken && inBoardState[0, 0] != inCurrentPlayer.PlayerToken)
            {
                return _pickedThisPosition = "1";
            }
            else if (inBoardState[0, 1] == _otherPlayerToken && inBoardState[1, 1] == _otherPlayerToken && inBoardState[2, 1] != inCurrentPlayer.PlayerToken)
            {
                return _pickedThisPosition = "8";
            }
            else if (inBoardState[0, 1] == _otherPlayerToken && inBoardState[2, 1] == _otherPlayerToken && inBoardState[1, 1] != inCurrentPlayer.PlayerToken)
            {
                return _pickedThisPosition = "5";
            }
            else if (inBoardState[1, 1] == _otherPlayerToken && inBoardState[2, 1] == _otherPlayerToken && inBoardState[0, 1] != inCurrentPlayer.PlayerToken)
            {
                return _pickedThisPosition = "2";
            }
            else if (inBoardState[0, 2] == _otherPlayerToken && inBoardState[1, 2] == _otherPlayerToken && inBoardState[2, 2] != inCurrentPlayer.PlayerToken)
            {
                return _pickedThisPosition = "9";
            }
            else if (inBoardState[0, 2] == _otherPlayerToken && inBoardState[2, 2] == _otherPlayerToken && inBoardState[1, 2] != inCurrentPlayer.PlayerToken)
            {
                return _pickedThisPosition = "6";
            }
            else if (inBoardState[1, 2] == _otherPlayerToken && inBoardState[2, 2] == _otherPlayerToken && inBoardState[0, 2] != inCurrentPlayer.PlayerToken)
            {
                return _pickedThisPosition = "3";
            }


            else
            {
                return _pickedThisPosition; // null
            }

        
        }


        private string WinMove(char[,] inBoardState, Player inCurrentPlayer)
        {
            // this is just the number where the token should go
            string _pickedThisPosition = null;

            //  simple - look for opposing player with 2 tokens in a line, 
            char _otherPlayerToken = inCurrentPlayer.PlayerToken == 'X' ? 'O' : 'X';


            // look diagonal first
            if (inBoardState[0, 0] == inCurrentPlayer.PlayerToken && inBoardState[2, 2] == inCurrentPlayer.PlayerToken && inBoardState[1, 1] != _otherPlayerToken)
            {
                return _pickedThisPosition = "5";
            }
            else if (inBoardState[2, 0] == inCurrentPlayer.PlayerToken && inBoardState[0, 2] == inCurrentPlayer.PlayerToken && inBoardState[1, 1] != _otherPlayerToken)
            {
                return _pickedThisPosition = "5";
            }
            else if (inBoardState[0, 0] == inCurrentPlayer.PlayerToken && inBoardState[1, 1] == inCurrentPlayer.PlayerToken && inBoardState[2, 2] != _otherPlayerToken)
            {
                return _pickedThisPosition = "9";
            }
            else if (inBoardState[0, 2] == inCurrentPlayer.PlayerToken && inBoardState[1, 1] == inCurrentPlayer.PlayerToken && inBoardState[2, 0] != _otherPlayerToken)
            {
                return _pickedThisPosition = "7";
            }
            else if (inBoardState[2, 0] == inCurrentPlayer.PlayerToken && inBoardState[1, 1] == inCurrentPlayer.PlayerToken && inBoardState[0, 2] != _otherPlayerToken)
            {
                return _pickedThisPosition = "3";
            }
            else if (inBoardState[2, 2] == inCurrentPlayer.PlayerToken && inBoardState[1, 1] == inCurrentPlayer.PlayerToken && inBoardState[0, 0] != _otherPlayerToken) 
            {
                return _pickedThisPosition = "1";            
            }

            // look horizonal
            else if (inBoardState[0, 0] == inCurrentPlayer.PlayerToken && inBoardState[0, 1] == inCurrentPlayer.PlayerToken && inBoardState[0, 2] != _otherPlayerToken)
            {
                return _pickedThisPosition = "3";
            }
            else if (inBoardState[0, 0] == inCurrentPlayer.PlayerToken && inBoardState[0, 2] == inCurrentPlayer.PlayerToken && inBoardState[0, 1] != _otherPlayerToken)
            {
                return _pickedThisPosition = "2";
            }
            else if (inBoardState[0, 1] == inCurrentPlayer.PlayerToken && inBoardState[0, 2] == inCurrentPlayer.PlayerToken && inBoardState[0, 0] != _otherPlayerToken)
            {
                return _pickedThisPosition =  "1";
            }
            else if (inBoardState[1, 0] == inCurrentPlayer.PlayerToken && inBoardState[1, 1] == inCurrentPlayer.PlayerToken && inBoardState[1, 2] != _otherPlayerToken)
            {
                return _pickedThisPosition = "6";
            }
            else if (inBoardState[1, 0] == inCurrentPlayer.PlayerToken && inBoardState[1, 2] == inCurrentPlayer.PlayerToken && inBoardState[1, 1] != _otherPlayerToken)
            {
                return _pickedThisPosition =  "5";
            }
            else if (inBoardState[1, 1] == inCurrentPlayer.PlayerToken && inBoardState[1, 2] == inCurrentPlayer.PlayerToken && inBoardState[1, 0] != _otherPlayerToken)
            {
                return _pickedThisPosition = "4";
            }
            else if (inBoardState[2, 0] == inCurrentPlayer.PlayerToken && inBoardState[2, 1] == inCurrentPlayer.PlayerToken && inBoardState[2, 2] != _otherPlayerToken)
            {
                return _pickedThisPosition = "9";
            }
            else if (inBoardState[2, 1] == inCurrentPlayer.PlayerToken && inBoardState[2, 2] == inCurrentPlayer.PlayerToken && inBoardState[2, 0] != _otherPlayerToken) 
            {
                return _pickedThisPosition = "7";
            }
            else if (inBoardState[2, 0] == inCurrentPlayer.PlayerToken && inBoardState[2, 2] == inCurrentPlayer.PlayerToken && inBoardState[2, 1] != _otherPlayerToken)
            {
                return _pickedThisPosition = "8";
            }

            // look vertical
            else if (inBoardState[0, 0] == inCurrentPlayer.PlayerToken && inBoardState[1, 0] == inCurrentPlayer.PlayerToken && inBoardState[2, 0] != _otherPlayerToken)
            {
                return _pickedThisPosition = "7";
            }
            else if (inBoardState[0, 0] == inCurrentPlayer.PlayerToken && inBoardState[2, 0] == inCurrentPlayer.PlayerToken && inBoardState[1, 0] != _otherPlayerToken)
            {
                return _pickedThisPosition = "4";
            }
            else if (inBoardState[1, 0] == inCurrentPlayer.PlayerToken && inBoardState[2, 0] == inCurrentPlayer.PlayerToken && inBoardState[0, 0] != _otherPlayerToken)
            {
                return _pickedThisPosition = "1";
            }
            else if (inBoardState[0, 1] == inCurrentPlayer.PlayerToken && inBoardState[1, 1] == inCurrentPlayer.PlayerToken && inBoardState[2, 1] != _otherPlayerToken)
            {
                return _pickedThisPosition = "8";
            }
            else if (inBoardState[0, 1] == inCurrentPlayer.PlayerToken && inBoardState[2, 1] == inCurrentPlayer.PlayerToken && inBoardState[1, 1] != _otherPlayerToken)
            {
                return _pickedThisPosition = "5";
            }
            else if (inBoardState[1, 1] == inCurrentPlayer.PlayerToken && inBoardState[2, 1] == inCurrentPlayer.PlayerToken && inBoardState[0, 1] != _otherPlayerToken)
            {
                return _pickedThisPosition = "2";
            }
            else if (inBoardState[0, 2] == inCurrentPlayer.PlayerToken && inBoardState[1, 2] == inCurrentPlayer.PlayerToken && inBoardState[2, 2] != _otherPlayerToken)
            {
                return _pickedThisPosition = "9";
            }
            else if (inBoardState[0, 2] == inCurrentPlayer.PlayerToken && inBoardState[2, 2] == inCurrentPlayer.PlayerToken && inBoardState[1, 2] != _otherPlayerToken)
            {
                return _pickedThisPosition = "6";
            }
            else if (inBoardState[1, 2] == inCurrentPlayer.PlayerToken && inBoardState[2, 2] == inCurrentPlayer.PlayerToken && inBoardState[0, 2] != _otherPlayerToken)
            {
                return _pickedThisPosition = "3";
            }


            else
            {
                return _pickedThisPosition; // null
            }
        }


        public string NeutralMove(char[,] inBoardState, Player inCurrentPlayer)
        {

           // this is just the number where the token should go
            string _pickedPosition = null;

            //  simple - look for opposing player with 2 tokens in a line, 
            char _otherPlayerToken = inCurrentPlayer.PlayerToken == 'X' ? 'O' : 'X';

            //TODO: logic goes here
            BotLogic _botLogic = new BotLogic();
            Random _random = new Random();

            //1-5 = 2, 6-10 = 4, 11-15 = 6, 16-20 = 8, 21-100 = center
            // if first by bot, then go on offense
            if (_botLogic.IsFirstMove(inBoardState))
            {
                int _somenumber = _random.Next(1, 101);
                if (_somenumber >= 1 && _somenumber <= 5)
                {
                    _pickedPosition = "2";
                }
                else if (_somenumber >= 6 && _somenumber <= 10)
                {
                    _pickedPosition = "4";
                }
                else if (_somenumber >= 11 && _somenumber <= 15)
                {
                    _pickedPosition = "6";
                }
                else if (_somenumber >= 16 && _somenumber <= 20)
                {
                    _pickedPosition = "8";
                }
                else
                {
                    _pickedPosition = "5"; // leghold trap
                }
            }
            else
            {
                // analyze board more - step 1
                int[,] _weightedBoard = this.WeightTheBoard(inBoardState, inCurrentPlayer);

                // score the board - step 2
                int[,] _scoredBoard = this.ScoreTheBoard(_weightedBoard, inCurrentPlayer);

                // step 3 pick a spot
                _pickedPosition = this.PickSpotBasedOnScoreBoard(_scoredBoard, inCurrentPlayer);

            }
          
            return _pickedPosition;
        }

        private string PickSpotBasedOnScoreBoard(int[,] scoredBoard, Player inCurrentPlayer)
        {
            return null;
        }

        private int[,] ScoreTheBoard(int[,] weightedBoard, Player inCurrentPlayer)
        {
            int[,] _scoredArray = new int[3, 3];

            // go position by postion and score that position
            // positions 1,3,7,9 are bit special because they have diagonal possibilities
            // you don't get value for your position, it's everything around you
           

            // position 1
            // position with a 1 and need to score it
            // it's a summation of everything excluding itself
            if (weightedBoard[0, 0] == 1)
            {
                _scoredArray[0, 0] = weightedBoard[0, 1] + weightedBoard[0, 2] + weightedBoard[1, 1] + weightedBoard[2, 2] + weightedBoard[1, 0] + weightedBoard[2, 0];
            }
            else 
            {
                // use zeroes for occupied positions
                // 2 = currentPlayer token, -1 = opposing player token
                _scoredArray[0, 0] = 0;
            }

            // position 2
            // position with a 1 and need to score it
            // it's a summation of everything excluding itself
            if (weightedBoard[0, 1] == 1)
            {
                _scoredArray[0, 1] = weightedBoard[0, 0] + weightedBoard[0, 2] + weightedBoard[1, 1] + weightedBoard[2, 1];
            }
            else
            {
                // use zeroes for occupied positions
                // 2 = currentPlayer token, -1 = opposing player token
                _scoredArray[0, 1] = 0;
            }


            // position 3
            // position with a 1 and need to score it
            // it's a summation of everything excluding itself
            if (weightedBoard[0, 2] == 1)
            {
                _scoredArray[0, 2] = weightedBoard[0, 0] + weightedBoard[0, 1] + weightedBoard[1, 1] + weightedBoard[2, 0] + weightedBoard[1, 2] + weightedBoard[2, 2];
            }
            else
            {
                // use zeroes for occupied positions
                // 2 = currentPlayer token, -1 = opposing player token
                _scoredArray[0, 2] = 0;
            }

            // position 4
            // position with a 1 and need to score it
            // it's a summation of everything excluding itself
            if (weightedBoard[1, 0] == 1)
            {
                _scoredArray[1, 0] = weightedBoard[0, 0] + weightedBoard[2, 0] + weightedBoard[1, 1] + weightedBoard[1, 2];
            }
            else
            {
                // use zeroes for occupied positions
                // 2 = currentPlayer token, -1 = opposing player token
                _scoredArray[1, 0] = 0;
            }

            // position 5
            // position with a 1 and need to score it
            // it's a summation of everything excluding itself
            if (weightedBoard[1, 1] == 1)
            {
                _scoredArray[1, 1] = weightedBoard[0, 0] + weightedBoard[2, 2] + weightedBoard[0, 2] + weightedBoard[2, 0] + 
                    weightedBoard[1,0] + weightedBoard[1,2] + weightedBoard[0,1] + weightedBoard[2,1];
            }
            else
            {
                // use zeroes for occupied positions
                // 2 = currentPlayer token, -1 = opposing player token
                _scoredArray[1, 1] = 0;
            }

            // position 6
            // position with a 1 and need to score it
            // it's a summation of everything excluding itself
            if (weightedBoard[1, 2] == 1)
            {
                _scoredArray[1, 2] = weightedBoard[1, 1] + weightedBoard[1, 0] + weightedBoard[0, 2] + weightedBoard[2, 2];
            }
            else
            {
                // use zeroes for occupied positions
                // 2 = currentPlayer token, -1 = opposing player token
                _scoredArray[1, 2] = 0;
            }

            // position 7
            // position with a 1 and need to score it
            // it's a summation of everything excluding itself
            if (weightedBoard[2, 0] == 1)
            {
                _scoredArray[2, 0] = weightedBoard[1, 1] + weightedBoard[0, 2] + weightedBoard[1, 0] + weightedBoard[0, 0] + weightedBoard[2, 1] + weightedBoard[2, 2];
            }
            else
            {
                // use zeroes for occupied positions
                // 2 = currentPlayer token, -1 = opposing player token
                _scoredArray[2, 0] = 0;
            }


            // position 8
            // position with a 1 and need to score it
            // it's a summation of everything excluding itself
            if (weightedBoard[2, 1] == 1)
            {
                _scoredArray[2, 1] = weightedBoard[1, 1] + weightedBoard[0, 1] + weightedBoard[2, 0] + weightedBoard[2, 2];
            }
            else
            {
                // use zeroes for occupied positions
                // 2 = currentPlayer token, -1 = opposing player token
                _scoredArray[2, 1] = 0;
            }


            // position 9
            // position with a 1 and need to score it
            // it's a summation of everything excluding itself
            if (weightedBoard[2, 2] == 1)
            {
                _scoredArray[2, 2] = weightedBoard[1, 1] + weightedBoard[0, 0] + weightedBoard[2, 1] + weightedBoard[2, 0] + weightedBoard[1, 2] + weightedBoard[0, 2];
            }
            else
            {
                // use zeroes for occupied positions
                // 2 = currentPlayer token, -1 = opposing player token
                _scoredArray[2, 2] = 0;
            }

            return _scoredArray;
        }

        public int[,] WeightTheBoard(char[,] inBoardState, Player inCurrentPlayer)
        {
            int[,] _weightArray = new int[3, 3];

            //  simple - look for opposing player with 2 tokens in a line, 
            char _otherPlayerToken = inCurrentPlayer.PlayerToken == 'X' ? 'O' : 'X';

            // go thru each posiition and weight it.
            // look at each available spot, this means any square that is unoccupied
            for (int _row = 0; _row < 3; _row++)
            {
                for (int _cell = 0; _cell < 3; _cell++)
                {
                    if (inBoardState[_row, _cell] == inCurrentPlayer.PlayerToken)
                    {
                        _weightArray[_row, _cell] = 2;
                    }
                    else if (inBoardState[_row, _cell] == _otherPlayerToken)
                    {
                        _weightArray[_row, _cell] = -1;
                    }
                    else 
                    {
                        _weightArray[_row, _cell] = 1;
                    }
                }
            }
            return _weightArray;
        }


    }
}
