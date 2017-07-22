using System.Collections.Generic;

namespace Software64.Chessmen.Contracts
{
    public interface IChessmen
    {
        IEnumerable<string> GetPseudoMovesFrom(string square);
    }
}