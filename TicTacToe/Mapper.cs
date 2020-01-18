using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToeDAL;

namespace TicTacToe
{
    internal static class Mapper
    {

        internal static Player PlayerDALtoPlayer(PlayerDAL inPlayerDAL, int inPosition, char inToken)
        {

            Player _playerReturned = new Player();
            _playerReturned.Name = inPlayerDAL.FirstName + " "  + inPlayerDAL.LastName;
            _playerReturned.Position = inPosition;
            _playerReturned.Token = inToken;
            return _playerReturned;
        }


    }
}
