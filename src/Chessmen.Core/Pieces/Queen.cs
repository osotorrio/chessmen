using System.Collections.Generic;
using AnToLan.Core.Board;
using AnToLan.Core.Contracts;
using System.Linq;

namespace AnToLan.Core.Pieces
{
    public class Queen : IChessmen
    {
        public IEnumerable<string> GetPseudoMovesFrom(Square square)
        {
            var rockMoves = new Rock().GetPseudoMovesFrom(square);
            var bishopMoves = new Bishop().GetPseudoMovesFrom(square);

            return rockMoves.Concat(bishopMoves);
        }
    }
}