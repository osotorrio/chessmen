using System.Collections.Generic;
using Software64.Chessmen.Enums;

namespace Software64.Chessmen.Contracts
{
    public abstract class ChessmenBase
    {
        public Color Color { get; }

        public ChessmenBase(Color color)
        {
            Color = color;
        }

        public abstract IEnumerable<string> GetPseudoMovesFrom(string square);
    }
}
