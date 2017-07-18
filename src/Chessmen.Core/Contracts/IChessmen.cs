using System.Collections.Generic;
using AnToLan.Core.Board;

namespace AnToLan.Core.Contracts
{
    public interface IChessmen
    {
        IEnumerable<string> GetPseudoMovesFrom(Square square);
    }
}