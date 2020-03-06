using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeCommon
{
    public class BotLogic
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

            // 1. prevent loss - defensive move
            _pickedPosition = this.PreventLoss(inBoardState, inPlayer);
            if (_pickedPosition != null) return _pickedPosition;

            // 2. look for winning move - kill move
            // it's null, go on attack
            _pickedPosition = this.Attack(inBoardState, inPlayer);
            if (_pickedPosition != null) return _pickedPosition; // kill move

            // 3.  best next move - this is the crux
            _pickedPosition = this.BestMove(inBoardState, inPlayer); /// this should never return null

            return _pickedPosition;
        
        }


        public string PreventLoss(char[,] inBoardState, Player inPlayer)
        {
            // this is just the number where the token should go
            string _pickedPosition = null;

            //  simple - look for opposing player with 2 tokens in a line, 
            char _opposingToken = inPlayer.PlayerToken == 'X' ? 'O' : 'X';

            // get the first occurrance and return or bot is screwed

            // look diagonal first
            if (inBoardState[0, 0] == _opposingToken && inBoardState[2, 2] == _opposingToken)
            {
                return _pickedPosition = "5";
            }
            else if (inBoardState[2, 0] == _opposingToken && inBoardState[0, 2] == _opposingToken)
            {
                return _pickedPosition = "5";
            }
            else if (inBoardState[0, 0] == _opposingToken && inBoardState[1, 1] == _opposingToken)
            {
                return _pickedPosition = "9";
            }
            else if (inBoardState[0, 2] == _opposingToken && inBoardState[1, 1] == _opposingToken)
            {
                return _pickedPosition = "7";
            }
            else if (inBoardState[2, 0] == _opposingToken && inBoardState[1, 1] == _opposingToken)
            {
                return _pickedPosition = "3";
            }
            else if (inBoardState[2, 2] == _opposingToken && inBoardState[1, 1] == _opposingToken) 
            {
                return _pickedPosition = "1";            
            }

            // look horizonal
            else if (inBoardState[0, 0] == _opposingToken && inBoardState[0, 1] == _opposingToken)
            {
                return _pickedPosition = "3";
            }
            else if (inBoardState[0, 0] == _opposingToken && inBoardState[0, 2] == _opposingToken)
            {
                return _pickedPosition = "2";
            }
            else if (inBoardState[0, 1] == _opposingToken && inBoardState[0, 2] == _opposingToken)
            {
                return _pickedPosition =  "1";
            }
            else if (inBoardState[1, 0] == _opposingToken && inBoardState[1, 1] == _opposingToken)
            {
                return _pickedPosition = "6";
            }
            else if (inBoardState[1, 0] == _opposingToken && inBoardState[1, 2] == _opposingToken)
            {
                return _pickedPosition =  "5";
            }
            else if (inBoardState[1, 1] == _opposingToken && inBoardState[1, 2] == _opposingToken)
            {
                return _pickedPosition = "4";
            }
            else if (inBoardState[2, 0] == _opposingToken && inBoardState[2, 1] == _opposingToken)
            {
                return _pickedPosition = "9";
            }
            else if (inBoardState[2, 1] == _opposingToken && inBoardState[2, 2] == _opposingToken) 
            {
                return _pickedPosition = "7";
            }
            else if (inBoardState[2, 0] == _opposingToken && inBoardState[2, 2] == _opposingToken)
            {
                return _pickedPosition = "8";
            }

            // look vertical
            else if (inBoardState[0, 0] == _opposingToken && inBoardState[1, 0] == _opposingToken)
            {
                return _pickedPosition = "7";
            }
            else if (inBoardState[0, 0] == _opposingToken && inBoardState[2, 0] == _opposingToken)
            {
                return _pickedPosition = "4";
            }
            else if (inBoardState[1, 0] == _opposingToken && inBoardState[2, 0] == _opposingToken)
            {
                return _pickedPosition = "1";
            }


            else if (inBoardState[0, 1] == _opposingToken && inBoardState[1, 1] == _opposingToken)
            {
                return _pickedPosition = "8";
            }
            else if (inBoardState[0, 1] == _opposingToken && inBoardState[2, 1] == _opposingToken)
            {
                return _pickedPosition = "5";
            }
            else if (inBoardState[1, 1] == _opposingToken && inBoardState[2, 1] == _opposingToken)
            {
                return _pickedPosition = "2";
            }


            else if (inBoardState[0, 2] == _opposingToken && inBoardState[1, 2] == _opposingToken)
            {
                return _pickedPosition = "9";
            }
            else if (inBoardState[0, 2] == _opposingToken && inBoardState[2, 2] == _opposingToken)
            {
                return _pickedPosition = "6";
            }
            else if (inBoardState[1, 2] == _opposingToken && inBoardState[2, 2] == _opposingToken)
            {
                return _pickedPosition = "3";
            }



            else
            {
                return _pickedPosition; // null
            }
        }


        public string Attack(char[,] inBoardState, Player inPlayer) 
        {

            // this is just the number where the token should go
            string _pickedPosition = null;

            //  simple - look for opposing player with 2 tokens in a line, 
            char _opposingToken = inPlayer.PlayerToken == 'X' ? 'O' : 'X';

            //TODO: logic goes here



            return _pickedPosition;
        }


        public string BestMove(char[,] inBoardState, Player inPlayer)
        {

            // this is just the number where the token should go
            string _pickedPosition = null;

            //  simple - look for opposing player with 2 tokens in a line, 
            char _opposingToken = inPlayer.PlayerToken == 'X' ? 'O' : 'X';

            //TODO: logic goes here





            return _pickedPosition;
        }

    }
}
