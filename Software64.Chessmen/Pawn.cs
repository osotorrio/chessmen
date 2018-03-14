using System.Collections.Generic;
using Software64.Chessmen.Contracts;
using Software64.Chessmen.Enums;

namespace Software64.Chessmen
{
    public class Pawn : ChessmenBase
    {
        private readonly int _direction;

        public Pawn(Color color, string square) : base(color, square)
        {
            _direction = (int)color;   
        }

        public override IEnumerable<string> GetPseudoMoves()
        {
            var source = new Square(Square);

            var targets = new List<string> { source.New(0, _direction).ToString() };
            
            if (source.Column == (int)Column.A)
            {
                targets.Add(source.New(1, _direction).ToString());
                
                if (source.Row == (int)Row.Two || source.Row == (int)Row.Seven)
                {
                    targets.Add(source.New(0, _direction*2).ToString());
                }
            }

            if (source.Column == (int)Column.H)
            {
                targets.Add(source.New(-1, _direction).ToString());
                
                if (source.Row == (int)Row.Two || source.Row == (int)Row.Seven)
                {
                    targets.Add(source.New(0, _direction*2).ToString());
                }
            }

            if (source.Column != (int)Column.A && source.Column != (int)Column.H)
            {
                targets.Add(source.New(-1, _direction).ToString());
                targets.Add(source.New(1, _direction).ToString());

                if (source.Row == (int)Row.Two || source.Row == (int)Row.Seven)
                {
                    targets.Add(source.New(0, _direction*2).ToString());
                }
            }

            return targets;
        }
    }
}