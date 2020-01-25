using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeCommon.Interfaces
{
    public interface IUserReader
    {

        List<Player> GetAllUsers(int inPlayerId);

        void DeleteUser(int inPlayerId);

        void AddUser(Player inPlayerDAL);

    }
}
