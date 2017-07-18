using System.Collections.Generic;
using AnToLan.Core.Board;
using AnToLan.Core.Contracts;

namespace AnToLan.Core.Pieces
{
    public class King : IChessmen
    {
        public IEnumerable<string> GetPseudoMovesFrom(Square square)
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