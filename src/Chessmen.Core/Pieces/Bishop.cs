using System;
using System.Collections.Generic;
using AnToLan.Core.Board;
using AnToLan.Core.Contracts;

namespace AnToLan.Core.Pieces
{
    public class Bishop : IChessmen
    {
        public IEnumerable<string> GetPseudoMovesFrom(Square square)
        {
            for (int col = -7; col <= 7; col++)
            {
                for (int row = -7; row <= 7; row++)
                {
                    var newSquare = square.New(col, row);

                    if (newSquare != null && newSquare.ToString() != square.ToString() 
                        && (Math.Abs(newSquare.Column - square.Column) == Math.Abs(newSquare.Row - square.Row)))
                    {
                        yield return newSquare.ToString();
                    }
                }
            }
        }
    }
}