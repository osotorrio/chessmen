using System.Collections.Generic;
using Software64.Chessmen.Contracts;
using Software64.Chessmen.Enums;

namespace Software64.Chessmen
{
    public class Rock : ChessmenBase
    {
        public Rock(Color color) : base(color){}

        public override IEnumerable<string> GetPseudoMovesFrom(string square)
        {
            var source = new Square(square);

            for (int col = -7; col <= 7; col++)
            {
                for (int row = -7; row <= 7; row++)
                {
                    var target = source.New(col, row);

                    if (target != null && target.ToString() != square.ToString() 
                        && (target.Column == source.Column || target.Row == source.Row))
                    {
                        yield return target.ToString();
                    }
                }
            }
        }
    }
}