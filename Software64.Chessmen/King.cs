using System.Collections.Generic;
using Software64.Chessmen.Contracts;
using Software64.Chessmen.Enums;

namespace Software64.Chessmen
{
    public class King : ChessmenBase
    {
        public King(Color color, string square) : base(color, square){}

        public override IEnumerable<string> GetPseudoMoves()
        {
            var source = new Square(Square);

            for (int col = -1; col <= 1; col++)
            {
                for (int row = -1; row <= 1; row++)
                {
                    var target = source.New(col, row);

                    if (target != null && target.ToString() != source.ToString())
                    {
                        yield return target.ToString();
                    }
                }
            }
        }
    }
}