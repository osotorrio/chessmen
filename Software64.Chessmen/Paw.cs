using System.Collections.Generic;
using Software64.Chessmen.Contracts;
using Software64.Chessmen.Enums;

namespace Software64.Chessmen
{
    public class Paw : ChessmenBase
    {
        private readonly int _direction;

        public Paw(Color color) : base(color)
        {
            _direction = (int)color;   
        }

        public override IEnumerable<string> GetPseudoMovesFrom(string square)
        {
            var source = new Square(square);

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