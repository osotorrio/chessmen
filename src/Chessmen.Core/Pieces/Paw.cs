﻿using System.Collections.Generic;
using Chessmen.Core.Contracts;
using Chessmen.Core.Enums;

namespace Chessmen.Core.Pieces
{
    public class Paw : IChessmen
    {
        private readonly int _direction;

        public Paw(Color color)
        {
            _direction = (int)color;   
        }

        public IEnumerable<string> GetPseudoMovesFrom(ISquare square)
        {
            var moves = new List<string> { square.New(0, _direction).ToString() };
            
            if (square.Column == (int)Column.A)
            {
                moves.Add(square.New(1, _direction).ToString());
                
                if (square.Row == (int)Row.Two || square.Row == (int)Row.Seven)
                {
                    moves.Add(square.New(0, _direction*2).ToString());
                }
            }

            if (square.Column == (int)Column.H)
            {
                moves.Add(square.New(-1, _direction).ToString());
                
                if (square.Row == (int)Row.Two || square.Row == (int)Row.Seven)
                {
                    moves.Add(square.New(0, _direction*2).ToString());
                }
            }

            if (square.Column != (int)Column.A && square.Column != (int)Column.H)
            {
                moves.Add(square.New(-1, _direction).ToString());
                moves.Add(square.New(1, _direction).ToString());

                if (square.Row == (int)Row.Two || square.Row == (int)Row.Seven)
                {
                    moves.Add(square.New(0, _direction*2).ToString());
                }
            }

            return moves;
        }
    }
}