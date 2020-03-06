using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToeCommon.Interfaces;

namespace TicTacToeCommon
{
    public class Player : ITicTacToePlayer
    {
        // properties
        public int PlayerID { get; set; }
        public string PlayerFirstName { get; set; }
        public string PlayerLastName { get; set; }
        public DateTime Birthdate { get; set; }
        public char Gender { get; set; }

        public PlayerType PlayerType { get; set; }

        public char PlayerToken { get; set; }

        public int PlayerOrderByPlay { get; set; }

      
        // constructor that takes parameters
        public Player(string inFirstNameInput, string inLastNameInput,
            string inBirthdateInput, string inGenderInput, PlayerType inPlayerType)
        {
            this.PlayerFirstName = inFirstNameInput;
            this.PlayerLastName = inLastNameInput;
            this.PlayerType = inPlayerType;

            // this assume is is it not empty, it's in a acceptable format
            this.Birthdate = string.IsNullOrEmpty(inBirthdateInput) ?
                DateTime.MinValue : DateTime.ParseExact(inBirthdateInput, "MM/dd/yyyy",
                            System.Globalization.CultureInfo.InvariantCulture);
            // ternary example
            //this.Gender = string.IsNullOrEmpty(inGenderInput) || inGenderInput.ToUpper() != "M" 
            //    || inGenderInput.ToUpper() != "F" ? ' ' : Convert.ToChar(inGenderInput);

            if (!string.IsNullOrEmpty(inGenderInput) && (inGenderInput.ToUpper() == "M" ||
                inGenderInput.ToUpper() == "F"))
            {
                // good value
                this.Gender = Convert.ToChar(inGenderInput);
            }
            else
            {
                this.Gender = ' ';
            }

        }


        // empty constructor
        public Player() { }


        // methods
        public string BotMove(char[,] inBoardState)
        {
            BotLogic _botLogic = new BotLogic();
            Random _random = new Random();
            string _position = "";

            //1-5 = 2, 6-10 = 4, 11-15 = 6, 16-20 = 8, 21-100 = center
            // if first by bot, then go on offense
            if (_botLogic.IsFirstMove(inBoardState))
            {
                int _somenumber = _random.Next(1, 101);
                if (_somenumber >= 1 && _somenumber <= 5)
                {
                    _position = "2";
                }
                else if (_somenumber >= 6 && _somenumber <= 10)
                {
                    _position = "4";
                }
                else if (_somenumber >= 11 && _somenumber <= 15)
                {
                    _position = "6";
                }
                else if (_somenumber >= 16 && _somenumber <= 20)
                {
                    _position = "8";
                }
                else
                {
                    _position = "5";
                }
            }
            else
            {
                // analyze board
                _position = _botLogic.Analyze(inBoardState, this);
            }


            return _position;
        }


     
    }
}

