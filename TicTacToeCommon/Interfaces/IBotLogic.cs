using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeCommon.Interfaces
{
    public interface IBotLogic
    {

        bool IsFirstMove(char[,] inBoardState);

        string Analyze(char[,] inBoardState, Player inPlayer);

        int[,] WeightTheBoard(char[,] inBoardState, Player inCurrentPlayer);

    }
}
