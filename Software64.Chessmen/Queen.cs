using System;
using System.Collections.Generic;
using System.Linq;
using Software64.Chessmen.Contracts;
using Software64.Chessmen.Enums;

namespace Software64.Chessmen
{
    public class Queen : ChessmenBase
    {
        public Queen(Color color) : base(color){}

        public override IEnumerable<string> GetPseudoMovesFrom(string square)
        {
            var rockMoves = new Rock(Color.White).GetPseudoMovesFrom(square);
            var bishopMoves = new Bishop(Color.White).GetPseudoMovesFrom(square);

            return rockMoves.Concat(bishopMoves);
        }
    }
}