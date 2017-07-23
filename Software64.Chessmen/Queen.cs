﻿using System;
using System.Collections.Generic;
using System.Linq;
using Software64.Chessmen.Contracts;
using Software64.Chessmen.Enums;

namespace Software64.Chessmen
{
    public class Queen : ChessmenBase
    {
        public Queen(Color color) : base(color){}

        public override IEnumerable<string> GetPseudoMovesFrom(string square)
        {
            var source = new Square(square);

            for (int col = -7; col <= 7; col++)
            {
                for (int row = -7; row <= 7; row++)
                {
                    var target = source.New(col, row);

                    if (target != null && target.ToString() != square.ToString()
                        && 
                        ((target.Column == source.Column || target.Row == source.Row) 
                            || (Math.Abs(target.Column - source.Column) == Math.Abs(target.Row - source.Row))))
                    {
                        yield return target.ToString();
                    }
                }
            }
        }
    }
}