using System;
using System.Collections.Generic;
using Software64.Chessmen.Contracts;
using Software64.Chessmen.Enums;

namespace Software64.Chessmen
{
    public class Bishop : ChessmenBase
    {
        public Bishop(Color color, string square) : base(color, square){}

        public override IEnumerable<string> GetPseudoMoves()
        {
            var source = new Square(Square);

            for (int col = -7; col <= 7; col++)
            {
                for (int row = -7; row <= 7; row++)
                {
                    var target = source.New(col, row);

                    if (target != null && target.ToString() != source.ToString() 
                        && (Math.Abs(target.Column - source.Column) == Math.Abs(target.Row - source.Row)))
                    {
                        yield return target.ToString();
                    }
                }
            }
        }
    }
}