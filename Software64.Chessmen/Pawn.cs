using System.Collections.Generic;
using Software64.Chessmen.Contracts;
using Software64.Chessmen.Enums;

namespace Software64.Chessmen
{
    public class Pawn : ChessmenBase
    {
        private readonly int _direction;

        // TODO: Throw exception for white pawn in row 1, and black pawn in row 8
        public Pawn(Color color, string square) : base(color, square)
        {
            _direction = (int)color;
        }

        // TODO: Refactor this ugly code
        public override IEnumerable<string> GetPseudoMoves()
        {
            var source = new Square(Square);

            var targets = new List<string>();

            // White
            if (Color == Color.White
                & (source.Column == (int)Column.B || source.Column == (int)Column.C || source.Column == (int)Column.D || source.Column == (int)Column.E || source.Column == (int)Column.F || source.Column == (int)Column.G)
                & (source.Row == (int)Row.Three || source.Row == (int)Row.Four || source.Row == (int)Row.Five || source.Row == (int)Row.Six || source.Row == (int)Row.Seven))
            {
                targets.Add(source.New(-1, 1).ToString());
                targets.Add(source.New(0, 1).ToString());
                targets.Add(source.New(1, 1).ToString());
            }

            if (Color == Color.White
                & (source.Column == (int)Column.A)
                & (source.Row == (int)Row.Three || source.Row == (int)Row.Four || source.Row == (int)Row.Five || source.Row == (int)Row.Six || source.Row == (int)Row.Seven))
            {
                targets.Add(source.New(0, 1).ToString());
                targets.Add(source.New(1, 1).ToString());
            }

            if (Color == Color.White
                & (source.Column == (int)Column.H)
                & (source.Row == (int)Row.Three || source.Row == (int)Row.Four || source.Row == (int)Row.Five || source.Row == (int)Row.Six || source.Row == (int)Row.Seven))
            {
                targets.Add(source.New(0, 1).ToString());
                targets.Add(source.New(-1, 1).ToString());
            }

            if (Color == Color.White
                & (source.Column == (int)Column.B || source.Column == (int)Column.C || source.Column == (int)Column.D || source.Column == (int)Column.E || source.Column == (int)Column.F || source.Column == (int)Column.G)
                & (source.Row == (int)Row.Two))
            {
                targets.Add(source.New(-1, 1).ToString());
                targets.Add(source.New(0, 1).ToString());
                targets.Add(source.New(1, 1).ToString());
                targets.Add(source.New(0, 2).ToString());
            }

            if (Color == Color.White
                & (source.Column == (int)Column.A)
                & (source.Row == (int)Row.Two))
            {
                targets.Add(source.New(0, 1).ToString());
                targets.Add(source.New(1, 1).ToString());
                targets.Add(source.New(0, 2).ToString());
            }

            if (Color == Color.White
                & (source.Column == (int)Column.H)
                & (source.Row == (int)Row.Two))
            {
                targets.Add(source.New(0, 1).ToString());
                targets.Add(source.New(-1, 1).ToString());
                targets.Add(source.New(0, 2).ToString());
            }

            // Black
            if (Color == Color.Black
                & (source.Column == (int)Column.B || source.Column == (int)Column.C || source.Column == (int)Column.D || source.Column == (int)Column.E || source.Column == (int)Column.F || source.Column == (int)Column.G)
                & (source.Row == (int)Row.Six || source.Row == (int)Row.Five || source.Row == (int)Row.Four || source.Row == (int)Row.Three || source.Row == (int)Row.Two))
            {
                targets.Add(source.New(-1, -1).ToString());
                targets.Add(source.New(0, -1).ToString());
                targets.Add(source.New(1, -1).ToString());
            }

            if (Color == Color.Black
                & (source.Column == (int)Column.A)
                & (source.Row == (int)Row.Six || source.Row == (int)Row.Five || source.Row == (int)Row.Four || source.Row == (int)Row.Three || source.Row == (int)Row.Two))
            {
                targets.Add(source.New(0, -1).ToString());
                targets.Add(source.New(1, -1).ToString());
            }

            if (Color == Color.Black
                & (source.Column == (int)Column.H)
                & (source.Row == (int)Row.Six || source.Row == (int)Row.Five || source.Row == (int)Row.Four || source.Row == (int)Row.Three || source.Row == (int)Row.Two))
            {
                targets.Add(source.New(0, -1).ToString());
                targets.Add(source.New(-1, -1).ToString());
            }

            if (Color == Color.Black
                & (source.Column == (int)Column.B || source.Column == (int)Column.C || source.Column == (int)Column.D || source.Column == (int)Column.E || source.Column == (int)Column.F || source.Column == (int)Column.G)
                & (source.Row == (int)Row.Seven))
            {
                targets.Add(source.New(-1, -1).ToString());
                targets.Add(source.New(0, -1).ToString());
                targets.Add(source.New(1, -1).ToString());
                targets.Add(source.New(0, -2).ToString());
            }

            if (Color == Color.Black
                & (source.Column == (int)Column.A)
                & (source.Row == (int)Row.Seven))
            {
                targets.Add(source.New(0, -1).ToString());
                targets.Add(source.New(1, -1).ToString());
                targets.Add(source.New(0, -2).ToString());
            }

            if (Color == Color.Black
                & (source.Column == (int)Column.H)
                & (source.Row == (int)Row.Seven))
            {
                targets.Add(source.New(0, -1).ToString());
                targets.Add(source.New(-1, -1).ToString());
                targets.Add(source.New(0, -2).ToString());
            }

            return targets;
        }
    }
}