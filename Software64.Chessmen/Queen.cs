using System.Collections.Generic;
using System.Linq;
using Software64.Chessmen.Contracts;

namespace Software64.Chessmen
{
    public class Queen : IChessmen
    {
        public IEnumerable<string> GetPseudoMovesFrom(string square)
        {
            var rockMoves = new Rock().GetPseudoMovesFrom(square);
            var bishopMoves = new Bishop().GetPseudoMovesFrom(square);

            return rockMoves.Concat(bishopMoves);
        }
    }
}