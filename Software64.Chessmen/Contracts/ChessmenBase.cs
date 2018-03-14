using System.Collections.Generic;
using Software64.Chessmen.Enums;

namespace Software64.Chessmen.Contracts
{
    public abstract class ChessmenBase
    {
        public Color Color { get; }

        public string Square { get; }

        public ChessmenBase(Color color, string square)
        {
            Color = color;
            Square = square;
        }

        public abstract IEnumerable<string> GetPseudoMoves();
    }
}
