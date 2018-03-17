using System.Collections.Generic;
using Software64.Chessmen.Enums;
using System.Linq;

namespace Software64.Chessmen.Contracts
{
    public abstract class ChessmenBase : IChessmen, IMove
    {
        public Color Color { get; }

        public string Square { get; private set; }

        public ChessmenBase(Color color, string square)
        {
            Color = color;
            Square = square;
        }
        
        public bool CanMoveTo(string square)
        {
            return GetPseudoMoves().Contains(square);
        }
        
        public void MoveTo(string square)
        {
            if (CanMoveTo(square))
            {
                Square = square;
            }
        }

        public abstract IEnumerable<string> GetPseudoMoves();
    }
}
