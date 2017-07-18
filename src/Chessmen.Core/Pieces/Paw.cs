using System.Collections.Generic;
using AnToLan.Core.Board;
using AnToLan.Core.Contracts;
using AnToLan.Core.Enums;

namespace AnToLan.Core.Pieces
{
    public class Paw : IChessmen
    {
        private readonly int _direction;

        public Paw(Color color)
        {
            _direction = (int)color;   
        }

        public IEnumerable<string> GetPseudoMovesFrom(Square square)
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