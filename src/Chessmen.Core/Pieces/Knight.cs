using System.Collections.Generic;
using Chessmen.Core.Board;
using Chessmen.Core.Contracts;
using System.Linq;

namespace Chessmen.Core.Pieces
{
    public class Knight : IChessmen
    {
        public IEnumerable<string> GetPseudoMovesFrom(ISquare square)
        {
            var square1 = square.New(1, 2);
            var square2 = square.New(2, 1);
            var square3 = square.New(1, -2);
            var square4 = square.New(2, -1);
            var square5 = square.New(-2, 1);
            var square6 = square.New(-1, 2);
            var square7 = square.New(-2, -1);
            var square8 = square.New(-1, -2);

            var squares = new List<Square> { square1, square2, square3, square4, square5, square6, square7, square8 };
            return squares.Where(s => s != null).Select(s => s.ToString());
        }
    }
}