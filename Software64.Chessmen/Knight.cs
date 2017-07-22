using System.Collections.Generic;
using System.Linq;
using Software64.Chessmen.Contracts;
using Software64.Chessmen.Enums;

namespace Software64.Chessmen
{
    public class Knight : ChessmenBase
    {
        public Knight(Color color) : base(color){}

        public override IEnumerable<string> GetPseudoMovesFrom(string square)
        {
            var source = new Square(square);
            var target1 = source.New(1, 2);
            var target2 = source.New(2, 1);
            var target3 = source.New(1, -2);
            var target4 = source.New(2, -1);
            var target5 = source.New(-2, 1);
            var target6 = source.New(-1, 2);
            var target7 = source.New(-2, -1);
            var target8 = source.New(-1, -2);

            var squares = new List<Square> { target1, target2, target3, target4, target5, target6, target7, target8 };
            return squares.Where(s => s != null).Select(s => s.ToString());
        }
    }
}