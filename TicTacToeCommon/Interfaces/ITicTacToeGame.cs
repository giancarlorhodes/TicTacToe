using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeCommon.Interfaces
{

    interface ITicTacToeGame 
    {

        string GameName { get; }

        ITicTacToePlayer Player { get; }

        char[][] BoardState { get; set; } 



    }
}
