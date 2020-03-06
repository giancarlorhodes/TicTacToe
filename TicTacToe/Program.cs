using System;
using System.Collections.Generic;
using System.Linq;
using TicTacToeCommon;
using TicTacToeCommon.Interfaces;
using TicTacToeDAL;

namespace TicTacToe
{
    class Program
    {

        // fields
        private readonly IUserReader _userReader;

        // properties

        // You’d have to look into whatever injection system you’re using. But do note that 
        // static methods aren’t called by instance so there’s never an object created 
        // nor a constructor called. – Sami Kuhmonen Dec 23 '18 at 8:33

        // constructor dependency injection
        public Program(IUserReader inIUserReader) 
        {
            _userReader = inIUserReader;
        
        }


        static void Main(string[] args)
        {
            // dependency on the ServiceReader class 
            IUserReader _IUserReader = new ServiceReader();
            Program _program = new Program(_IUserReader);

            // Constructor injection in console application
            // https://stackoverflow.com/questions/53902234/constructor-injection-in-console-application
            _program.Invoke();
            

        }



        // the bulk of the desired functionality should be refactored into a 
        // method that will be invoked once the class has been initialized.
        public void Invoke()
        {
           
           
            // declare local variables
            // this will used to determine which DAL method I need to call
            DatabaseAccessLayer _dal = new DatabaseAccessLayer();
            List<Player> _listOfPlayers;

            // Title of game
            Console.WriteLine("Welcome to Tic-Tac-Toe");

            // Creates a new GameBoard
            GameBoard _board = new GameBoard();
            bool IsPlayersNotSelected = true;

            Player _firstPlayer = new Player();
            Player _secondPlayer = new Player();

            while (IsPlayersNotSelected)
            {

                // print out the main menu
                Console.WriteLine("Menu (L) - List all players, (S) Select players for the game, " +
                    "(A) - Add Player, " +
                    "(D) - Delete Player, (U) - Update Player");

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
                        Player _newPlayer = new Player(_firstNameInput, _lastNameInput,
                        _birthdateInput, _genderInput, PlayerType.Human);

                        // pass all value thru the object reference
                        _userReader.AddUser(_newPlayer); 
                        
                        break;

                    case "D":  // delete a player from the db
                        // print out the list for them of they player ids
                        Console.WriteLine("Please enter player id you want to delete for the game.");
                        int _getAllPlayers = 0;
                        _listOfPlayers = _dal.GetAllPlayers(_getAllPlayers);

                        // print out the board
                        _board.PrintPlayers(_listOfPlayers);

                        // the get the player id
                        int _playerId = Convert.ToInt32(Console.ReadLine());

                        //delete the player and their stats
                        _dal.DeletePlayer(_playerId);

                        break;

                    case "L": // list all the players in
                        int _playerIDToGet = 0;
                        _listOfPlayers = _dal.GetAllPlayers(_playerIDToGet);
                        // add the bot player
                        _listOfPlayers.Add(new Player { PlayerFirstName = "Bot", PlayerID = 666, PlayerLastName = "Boy", PlayerType = PlayerType.Bot });

                        // uses the list
                        _board.PrintPlayers(_listOfPlayers);
                        break;


                    case "S":
                        // print out the list for them of they player ids
                        Console.WriteLine("Please look at the list of available players, enter two player ids for the game.");
                        _getAllPlayers = 0;
                        _listOfPlayers = _dal.GetAllPlayers(_getAllPlayers);
                        _listOfPlayers.Add(new Player { PlayerFirstName = "Bot", PlayerID = 666, PlayerLastName = "Boy", PlayerType = PlayerType.Bot });

                        // print out the board
                        _board.PrintPlayers(_listOfPlayers);

                        // get the two players
                        Console.WriteLine("Please enter PlayerID for first player.");
                        int firstPlayerId = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Please enter PlayerID for second player.");
                        int secondPlayerId = Convert.ToInt32(Console.ReadLine());

                        // write some LINQ to get player one and create object for that player
                        Player _firstPlayerDAL = _listOfPlayers.Where(x => x.PlayerID == firstPlayerId).FirstOrDefault();

                        // write some LINQ to get player two and create object for that player
                        Player _secondPlayerDAL = _listOfPlayers.Where(x => x.PlayerID == secondPlayerId).FirstOrDefault();

                        // map these to player objects because that's what game play takes
                        //_firstPlayer = Mapper.PlayerDALtoPlayer(_firstPlayerDAL, 1, 'X');
                        //_secondPlayer = Mapper.PlayerDALtoPlayer(_secondPlayerDAL, 2, '0');
                        _firstPlayer = _firstPlayerDAL;
                        _secondPlayer = _secondPlayerDAL;
                        _firstPlayer.PlayerToken = 'X';
                        _firstPlayer.PlayerOrderByPlay = 1;
                        _secondPlayer.PlayerToken = 'O';
                        _secondPlayer.PlayerOrderByPlay = 2;

                        // drop out of loop
                        IsPlayersNotSelected = false;
                        break;

                    default:
                        break;
                }

            } // while end


            // continuing to game play

            ////Creates a new GameBoard
            //GameBoard board = new GameBoard(first, second);
            _board.SetPlayers(_firstPlayer, _secondPlayer);

            // print instructions to where your choice will go 1- 9
            Console.WriteLine("Players will pick a number between 1 and 9 to determnine where they will play");

            // prints out the rule board
            _board.Print();

            // game play code starting here

            // need a loop to go back and forth between the players
            bool IsContinueGame = true; // will be switched to false on a draw or winner inside the loop
            //string currentPlayer = player1; // used to determine what will be stored in the array
            Player _currentPlayer;
            int _currentPlayerIndex = 0;
            string _position = "";

            while (IsContinueGame)
            {

                _currentPlayer = _board.TwoPlayers[_currentPlayerIndex];
                

                // TODO: only for the screen players
                // need player to pick a location

                if (_currentPlayer.PlayerType == PlayerType.Human)
                {
                    Console.WriteLine(_currentPlayer.PlayerFirstName + " " + _currentPlayer.PlayerLastName + ", please pick a location 1 to 9 that is not already occupied");
                    Console.Write("Location: ");
                    _position = Console.ReadLine();


                    // only humans to things wrong
                    // need validation to make sure is legal spot
                    // checks for valid player input
                    _position = _board.ValidateInput(_position, _currentPlayer.PlayerFirstName + " " + _currentPlayer.PlayerLastName);

                    bool validMove = false;

                    // checks if the player made a valid move
                    while (validMove == false)
                    {

                        validMove = _board.ValidateMove(Convert.ToInt32(_position));

                        if (validMove == false)
                        {
                            Console.WriteLine(_currentPlayer.PlayerFirstName + " " + _currentPlayer.PlayerLastName + 
                                ", please use only the numbers 1 to 9 and a space that is not already occupied");
                            _board.Print();
                            Console.Write("Location: ");
                            _position = Console.ReadLine();
                            _position = _board.ValidateInput(_position, _currentPlayer.PlayerFirstName + " " + _currentPlayer.PlayerLastName);
                        }
                    }


                }
                else  // BOT turn
                {
                    // no validation needed
                   


                    // need the current board state to decide
                    _position = _currentPlayer.BotMove(_board.BoardState);


                    // print the location picked
                    Console.WriteLine(_currentPlayer.PlayerFirstName + " " + _currentPlayer.PlayerLastName +
                                  ", please use only the numbers 1 to 9 and a space that is not already occupied");
  

                }

               

                // place it
                // do we place a X or O?
                char charToPlace;
                charToPlace = _currentPlayer.PlayerToken;



                // this is simply placing the token, all the hard decisions have been made
                _board.Place(charToPlace, Convert.ToInt32(_position));


                // print it
                _board.Print();

                // check if it's a winner or draw, if not flip the player
                string result = _board.CheckForWinnerOrDraw();


                switch (result)
                {
                    case "win":
                        IsContinueGame = false;
                        Console.WriteLine(_currentPlayer.PlayerFirstName + " " + _currentPlayer.PlayerLastName + " wins!!!!!");
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
                else
                {
                    _currentPlayerIndex = 0;
                }

                // ENH: add win loss draw to the database


                // ENH: to they want another game ?


            }  // game loop

            //Stops the program
            Console.WriteLine("Game Over");
            Console.ReadLine();

        }


    }
  
}
