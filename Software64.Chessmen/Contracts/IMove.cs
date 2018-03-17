using Software64.Chessmen.Enums;
using System.Collections.Generic;

namespace Software64.Chessmen.Contracts
{
    public interface IMove
    {
        bool CanMoveTo(string square);

        void MoveTo(string square);

        IEnumerable<string> GetPseudoMoves();
    }
}
