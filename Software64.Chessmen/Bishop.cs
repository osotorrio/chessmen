using System;
using System.Collections.Generic;
using Software64.Chessmen.Contracts;

namespace Software64.Chessmen
{
    public class Bishop : IChessmen
    {
        public IEnumerable<string> GetPseudoMovesFrom(string square)
        {
            var source = new Square(square);

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