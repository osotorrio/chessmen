using System.Collections.Generic;
using System.Linq;
using Chessmen.Core.Contracts;

namespace Chessmen.Core.Pieces
{
    public class Queen : IChessmen
    {
        public IEnumerable<string> GetPseudoMovesFrom(ISquare square)
        {
            var rockMoves = new Rock().GetPseudoMovesFrom(square);
            var bishopMoves = new Bishop().GetPseudoMovesFrom(square);

            return rockMoves.Concat(bishopMoves);
        }
    }
}