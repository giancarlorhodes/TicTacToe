using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeCommon
{
    public class Player
    {
        // properties
        public int PlayerID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthdate { get; set; }
        public char Gender { get; set; }

        // constructor that takes parameters
        public Player(string inFirstNameInput, string inLastNameInput,
            string inBirthdateInput, string inGenderInput)
        {
            this.FirstName = inFirstNameInput;
            this.LastName = inLastNameInput;

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
        public Player()
        {
        }


    }
}

