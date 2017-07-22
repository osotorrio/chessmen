using System.Collections.Generic;
using Software64.Chessmen.Contracts;
using Software64.Chessmen.Enums;

namespace Software64.Chessmen
{
    public class King : ChessmenBase
    {
        public King(Color color) : base(color){}

        public override IEnumerable<string> GetPseudoMovesFrom(string square)
        {
            var source = new Square(square);

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