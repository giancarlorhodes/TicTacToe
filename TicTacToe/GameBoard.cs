namespace TicTacToe
{

    using System;
    using System.Collections.Generic;
    using TicTacToeDAL;

    public class GameBoard : IGameBoard
    {
        //This is the players for the game
        public List<Player> TwoPlayers { get; set; }

        char[,] BoardState = new char[3, 3];

        //Default empty constructor
        public GameBoard()
        {
            BoardState = new char[3, 3];

            for (int i = 0; i < 3; i++)
            {
                // cells
                for (int j = 0; j < 3; j++)
                {
                    BoardState[i, j] = '_';

                }
            }


            TwoPlayers = new List<Player>();
        }

        //Constructor that takes two players
        public GameBoard(Player inFirstPlayer, Player inSecondPlayer)
        {
            BoardState = new char[3, 3];

            for (int i = 0; i < 3; i++)
            {
                // cells
                for (int j = 0; j < 3; j++)
                {
                    BoardState[i, j] = '_';

                }
            }

            //instantiate TwoPlayer property
            TwoPlayers = new List<Player>();

            //Add players to the list
            TwoPlayers.Add(inFirstPlayer);
            TwoPlayers.Add(inSecondPlayer);
        }

        public string ValidateInput(string inPosition, string inPlayerName)
        {
            bool valid = false;

            // Checks if the loaction chosen by the player is a valid 1-9
            // If not asks for a new proper location
            while (valid == false)
            {
                if (inPosition == "1")
                {
                    valid = true;
                }
                else if (inPosition == "2")
                {
                    valid = true;
                }
                else if (inPosition == "3")
                {
                    valid = true;
                }
                else if (inPosition == "4")
                {
                    valid = true;
                }
                else if (inPosition == "5")
                {
                    valid = true;
                }
                else if (inPosition == "6")
                {
                    valid = true;
                }
                else if (inPosition == "7")
                {
                    valid = true;
                }
                else if (inPosition == "8")
                {
                    valid = true;
                }
                else if (inPosition == "9")
                {
                    valid = true;
                }
                else
                {
                    Console.WriteLine(inPlayerName + ", please use only the numbers 1 to 9");
                    Print();
                    Console.Write("Location: ");
                    inPosition = Console.ReadLine();
                }
            }
            return inPosition;
        }

        // Checks if the location chosen by the player is unoccupied
        public bool ValidateMove(int position)
        {
            bool valid = false;
            switch (position)
            {

                case 1:
                    if (BoardState[0, 0] == '_')
                    {
                        valid = true;
                    }
                    else
                    {
                        valid = false;
                    }
                    return valid;

                case 2:
                    if (BoardState[0, 1] == '_')
                    {
                        valid = true;
                    }
                    else
                    {
                        valid = false;
                    }
                    return valid;

                case 3:
                    if (BoardState[0, 2] == '_')
                    {
                        valid = true;
                    }
                    else
                    {
                        valid = false;
                    }
                    return valid;

                case 4:
                    if (BoardState[1, 0] == '_')
                    {
                        valid = true;
                    }
                    else
                    {
                        valid = false;
                    }
                    return valid;

                case 5:
                    if (BoardState[1, 1] == '_')
                    {
                        valid = true;
                    }
                    else
                    {
                        valid = false;
                    }
                    return valid;

                case 6:
                    if (BoardState[1, 2] == '_')
                    {
                        valid = true;
                    }
                    else
                    {
                        valid = false;
                    }
                    return valid;

                case 7:
                    if (BoardState[2, 0] == '_')
                    {
                        valid = true;
                    }
                    else
                    {
                        valid = false;
                    }
                    return valid;

                case 8:
                    if (BoardState[2, 1] == '_')
                    {
                        valid = true;
                    }
                    else
                    {
                        valid = false;
                    }
                    return valid;

                case 9:
                    if (BoardState[2, 2] == '_')
                    {
                        valid = true;
                    }
                    else
                    {
                        valid = false;
                    }
                    return valid;

                default:
                    return valid;
            }
        }

        internal void SetPlayers(Player inFirstPlayer, Player inSecondPlayer)
        {
            this.TwoPlayers.Add(inFirstPlayer);
            this.TwoPlayers.Add(inSecondPlayer);
        }

        public void Place(char inPiece, int inPosition)
        {

            switch (inPosition)
            {

                case 1:
                    BoardState[0, 0] = inPiece;
                    break;

                case 2:
                    BoardState[0, 1] = inPiece;
                    break;

                case 3:
                    BoardState[0, 2] = inPiece;
                    break;

                case 4:
                    BoardState[1, 0] = inPiece;
                    break;

                case 5:
                    BoardState[1, 1] = inPiece;
                    break;

                case 6:
                    BoardState[1, 2] = inPiece;
                    break;

                case 7:
                    BoardState[2, 0] = inPiece;
                    break;

                case 8:
                    BoardState[2, 1] = inPiece;
                    break;

                case 9:
                    BoardState[2, 2] = inPiece;
                    break;

                default:
                    break;
            }



        }

        //// OLD
        //public void Print() {



        //    //  print out the 3 x 3 array

        //    // rows
        //    for (int i = 0; i < 3; i++)
        //    {
        //        // cells
        //        for (int j = 0; j < 3; j++)
        //        {
        //            Console.Write(BoardState[i,j]);
        //            Console.Write(" ");
        //        }
        //        Console.Write("\n");
        //    }


        //}

        public void Print()
        {
            char cell1 = BoardState[0, 0] == '_' ? '1' : BoardState[0, 0];
            char cell2 = BoardState[0, 1] == '_' ? '2' : BoardState[0, 1];
            char cell3 = BoardState[0, 2] == '_' ? '3' : BoardState[0, 2];
            char cell4 = BoardState[1, 0] == '_' ? '4' : BoardState[1, 0];
            char cell5 = BoardState[1, 1] == '_' ? '5' : BoardState[1, 1];
            char cell6 = BoardState[1, 2] == '_' ? '6' : BoardState[1, 2];
            char cell7 = BoardState[2, 0] == '_' ? '7' : BoardState[2, 0];
            char cell8 = BoardState[2, 1] == '_' ? '8' : BoardState[2, 1];
            char cell9 = BoardState[2, 2] == '_' ? '9' : BoardState[2, 2];

            Console.WriteLine();
            Console.WriteLine("   _________________");
            Console.WriteLine("  |     |     |     |");
            Console.WriteLine("  |  " + cell1 + "  |  " + cell2 + "  |  " + cell3 + "  |");
            Console.WriteLine("  |_____|_____|_____|");
            Console.WriteLine("  |     |     |     |");
            Console.WriteLine("  |  " + cell4 + "  |  " + cell5 + "  |  " + cell6 + "  |");
            Console.WriteLine("  |_____|_____|_____|");
            Console.WriteLine("  |     |     |     |");
            Console.WriteLine("  |  " + cell7 + "  |  " + cell8 + "  |  " + cell9 + "  |");
            Console.WriteLine("  |_____|_____|_____|");
            Console.WriteLine();

        }


        //  _________________
        // |     |     |     |
        // |  1  |  2  |  3  |
        // |_____|_____|_____|
        // |     |     |     |
        // |  4  |  5  |  6  |
        // |_____|_____|_____|    
        // |     |     |     |
        // |  7  |  8  |  9  |
        // |_____|_____|_____|
        // 

        public void PrintNiceRuleBoard()
        {

            Console.WriteLine();
            Console.WriteLine("   _________________");
            Console.WriteLine("  |     |     |     |");
            Console.WriteLine("  |  1  |  2  |  3  |");
            Console.WriteLine("  |_____|_____|_____|");
            Console.WriteLine("  |     |     |     |");
            Console.WriteLine("  |  4  |  5  |  6  |");
            Console.WriteLine("  |_____|_____|_____|");
            Console.WriteLine("  |     |     |     |");
            Console.WriteLine("  |  7  |  8  |  9  |");
            Console.WriteLine("  |_____|_____|_____|");
            Console.WriteLine();



        }

        public void PrintRuleBoard()
        {

            int k = 1;

            //  print out the 3 x 3 array

            // rows
            for (int i = 0; i < 3; i++)
            {
                // cells
                for (int j = 0; j < 3; j++)
                {
                    Console.Write(k);
                    Console.Write(" ");
                    k++;
                }
                Console.Write("\n");
            }


        }

        public string CheckForWinnerOrDraw()
        {
            // row 1 winner
            if ((BoardState[0, 0] == BoardState[0, 1]) && (BoardState[0, 0] == BoardState[0, 2]) && (BoardState[0, 0] != '_'))
            {
                return "win";
            }
            else if ((BoardState[1, 0] == BoardState[1, 1]) && (BoardState[1, 0] == BoardState[1, 2]) && (BoardState[1, 0] != '_'))
            {
                return "win";
            }
            else if ((BoardState[2, 0] == BoardState[2, 1]) && (BoardState[2, 0] == BoardState[2, 2]) && (BoardState[2, 0] != '_'))
            {
                return "win";
            }
            else if ((BoardState[0, 0] == BoardState[1, 0]) && (BoardState[0, 0] == BoardState[2, 0]) && (BoardState[0, 0] != '_'))
            {
                return "win";
            }
            else if ((BoardState[0, 1] == BoardState[1, 1]) && (BoardState[0, 1] == BoardState[2, 1]) && (BoardState[0, 1] != '_'))
            {
                return "win";
            }
            else if ((BoardState[0, 2] == BoardState[1, 2]) && (BoardState[0, 2] == BoardState[2, 2]) && (BoardState[0, 2] != '_'))
            {
                return "win";
            }
            else if ((BoardState[0, 0] == BoardState[1, 1]) && (BoardState[0, 0] == BoardState[2, 2]) && (BoardState[0, 0] != '_'))
            {
                return "win";
            }
            else if ((BoardState[0, 2] == BoardState[1, 1]) && (BoardState[0, 2] == BoardState[2, 0]) && (BoardState[0, 2] != '_'))
            {
                return "win";
            }
            else
            {

                for (int i = 0; i < 3; i++)
                {
                    // cells
                    for (int j = 0; j < 3; j++)
                    {
                        if (BoardState[i, j] == '_')
                        {
                            return "continue";
                        }

                    }
                }
                return "draw";

            }
        }


        public WinDrawContinueEnum CheckForWinnerOrDrawByNumber() 
        {

            if (CalculateCharArraySum(this.BoardState) == 123)
            {
                return WinDrawContinueEnum.Draw;
            }
            else
            {
                return WinDrawContinueEnum.Continue;
            
            }
        
        
        }

        private int CalculateCharArraySum(char[,] inBoardState)
        {
            int _returnValue = 0;
            for (int row = 0; row < 3; row++)
            {
                for (int cell = 0; cell < 3; cell++)
                {
                    _returnValue = _returnValue + (int)inBoardState[row, cell];
                }
            }
            return _returnValue;
        }



        public void PrintPlayers(List<PlayerDAL> inList) 
        {

            Console.WriteLine();

            // print header
            //1-->10 11-->30 31-->50 51-->70

            Console.WriteLine("PlayerID  FirstName           LastName            BirthDate           Gender");


            // print the list of players
            foreach (var _player in inList)
            {
                Console.Write(_player.PlayerID.ToString().PadRight(10) + _player.FirstName.ToString().PadRight(20) + 
                    _player.LastName.ToString().PadRight(20) + _player.Birthdate.ToString("MM/dd/yyyy").PadRight(20) + _player.Gender + "\n");
                              
            }

            Console.WriteLine();
        }
    }
}
