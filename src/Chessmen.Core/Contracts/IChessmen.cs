using System.Collections.Generic;

namespace Chessmen.Core.Contracts
{
    public interface IChessmen
    {
        IEnumerable<string> GetPseudoMovesFrom(ISquare square);
    }
}