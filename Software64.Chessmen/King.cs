using System.Collections.Generic;
using Software64.Chessmen.Contracts;

namespace Software64.Chessmen
{
    public class King : IChessmen
    {
        public IEnumerable<string> GetPseudoMovesFrom(ISquare square)
        {
            for (int col = -1; col <= 1; col++)
            {
                for (int row = -1; row <= 1; row++)
                {
                    var newSquare = square.New(col, row);

                    if (newSquare != null && newSquare.ToString() != square.ToString())
                    {
                        yield return newSquare.ToString();
                    }
                }
            }
        }
    }
}