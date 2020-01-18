﻿using System;
using System.Collections.Generic;
using System.Linq;
using TicTacToeDAL;

namespace TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            //Title of game
            Console.WriteLine("Welcome to Tic-Tac-Toe");

            // this will used to determine which DAL method I need to call
            DatabaseAccessLayer _dal = new DatabaseAccessLayer();
            List<PlayerDAL> _listOfPlayers;

            //Creates a new GameBoard
            GameBoard board = new GameBoard();
            bool IsPlayersNotSeelected = true;

            Player _firstPlayer = new Player();
            Player _secondPlayer = new Player();

            while (IsPlayersNotSeelected) 
            {

                // print out the main menu
                Console.WriteLine("Menu (L) - List all players, (S) Select players for the game, (A) - Add Player, (D) - Delete Player, (U) - Update Player");
                string _menuItemPicked = Console.ReadLine();

                // what does the user want to do
                switch (_menuItemPicked.ToUpper())
                {

                    case "A":     // add user               
                        // collect all the information from the user
                        Console.WriteLine("Enter first name (required): ");
                        string _firstNameInput = Console.ReadLine();
                        Console.WriteLine("Enter last name (required): ");
                        string _lastNameInput = Console.ReadLine();
                        Console.WriteLine("Enter birthdate MM/DD/YYYY (optional): ");
                        string _birthdateInput = Console.ReadLine();
                        Console.WriteLine("Enter gender M or F (optional): ");
                        string _genderInput = Console.ReadLine();

                        // constructor
                        PlayerDAL _newPlayer = new PlayerDAL(_firstNameInput, _lastNameInput,
                            _birthdateInput, _genderInput);

                        // pass all value thru the object reference
                        _dal.AddPlayer(_newPlayer);
                        break;

                    case "L": // list all the players in
                        int _playerIDToGet = 0;
                        _listOfPlayers = _dal.GetAllPlayers(_playerIDToGet);
                        board.PrintPlayers(_listOfPlayers);
                        break;


                    case "S":
                        // print out the list for them of they player ids
                        Console.WriteLine("Please look at the list of available players, enter two player ids for the game.");
                        int _getAllPlayers = 0;
                        _listOfPlayers = _dal.GetAllPlayers(_getAllPlayers);

                        // print out the board
                        board.PrintPlayers(_listOfPlayers);

                        // get the two players
                        Console.WriteLine("Please enter PlayerID for first player.");
                        int firstPlayerId = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Please enter PlayerID for second player.");
                        int secondPlayerId = Convert.ToInt32(Console.ReadLine());

                        // write some LINQ to get player one and create object for that player
                        PlayerDAL _firstPlayerDAL = _listOfPlayers.Where(x => x.PlayerID == firstPlayerId).FirstOrDefault();

                        // write some LINQ to get player two and create object for that player
                        PlayerDAL _secondPlayerDAL = _listOfPlayers.Where(x => x.PlayerID == secondPlayerId).FirstOrDefault();

                        // map these to player objects because that's what game play takes
                        _firstPlayer = Mapper.PlayerDALtoPlayer(_firstPlayerDAL, 1, 'X');
                        _secondPlayer = Mapper.PlayerDALtoPlayer(_secondPlayerDAL, 2, '0');

                        // drop out of loop
                        IsPlayersNotSeelected = false;
                        break;

                    default:
                        break;
                }

            } // while end
    

            // continuing to game play


            // OLD CODE
            ////Gets the name of the first player
            //Console.WriteLine("Player 1 will be X's and goes first");
            //Console.Write("Player 1 enter name: ");
            //string player1 = Console.ReadLine();

            ////Gets the name of the second player
            //Console.WriteLine("Player 2 will be O's and goes second");
            //Console.Write("Player 1 enter name: ");
            //string player2 = Console.ReadLine();

          

            ////Creates a new GameBoard
            //GameBoard board = new GameBoard(first, second);
            board.SetPlayers(_firstPlayer, _secondPlayer);

            // print instructions to where your choice will go 1- 9
            Console.WriteLine("Players will pick a number between 1 and 9 to determnine where they will play");

            // prints out the rule board
            //board.PrintRuleBoard();
            //board.PrintNiceRuleBoard();
            board.Print();

            // print out the empty board
            // board.Print();

            // game play

            // need a loop to go back and forth between the players
            bool IsContinueGame = true; // will be switched to false on a draw or winner inside the loop
            //string currentPlayer = player1; // used to determine what will be stored in the array
            Player _currentPlayer;
            int _currentPlayerIndex = 0;
            while (IsContinueGame) 
            {

                _currentPlayer = board.TwoPlayers[_currentPlayerIndex];
                // need player to pick a location
                Console.WriteLine(_currentPlayer.Name + ", please pick a location 1 to 9 that is not already occupied");
                board.Print();
                Console.Write("Location: ");
                string position = Console.ReadLine();

                // need validation to make sure is legal spot
                // checks for valid player input
                position = board.ValidateInput(position, _currentPlayer.Name);

                bool validMove = false;
                
                // checks if the player made a valid move
                while (validMove == false)
                {

                    validMove = board.ValidateMove(Convert.ToInt32(position));

                    if (validMove == false)
                    {
                        Console.WriteLine(_currentPlayer.Name + ", please use only the numbers 1 to 9 and a space that is not already occupied");
                        board.Print();
                        Console.Write("Location: ");
                        position = Console.ReadLine();
                        position = board.ValidateInput(position, _currentPlayer.Name);
                    }
                }

                // place it
                // do we place a X or O?
                char charToPlace;
                charToPlace = _currentPlayer.Token;
             
                board.Place(charToPlace, Convert.ToInt32(position));



                // check if it's a winner or draw, if not flip the player
                string result =  board.CheckForWinnerOrDraw();


                switch (result)
                {
                    case "win":
                        IsContinueGame = false;
                        Console.WriteLine(_currentPlayer.Name + " wins!!!!!");
                        Console.WriteLine();
                        break;
                    case "draw":
                        IsContinueGame = false;
                        Console.WriteLine("Game is a draw !!!!");
                        Console.WriteLine();
                        break;
                    default:
                        break;

                }

                // flip the player
                if (_currentPlayerIndex == 0)
                {
                    _currentPlayerIndex = 1;
                }
                else {
                    _currentPlayerIndex = 0;
                }



                // add win loss draw to the database


                // to they want another game


            }  // game loop





            //Stops the program
            Console.WriteLine("Game Over");
            Console.ReadLine();
        }
    }

  
}
