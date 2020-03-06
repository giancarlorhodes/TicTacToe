using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeCommon.Interfaces
{
    interface ITicTacToePlayer
    {

        string PlayerFirstName { get; set; } 

        string PlayerLastName { get; set; }

        int PlayerOrderByPlay { get; set; }

        char PlayerToken { get; set; }

        string BotMove(char[,] inBoardState);

    }
}
