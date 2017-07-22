using System;
using System.Linq;
using Software64.Chessmen.Contracts;
using Software64.Chessmen.Enums;

namespace Software64.Chessmen
{
    public class Square : ISquare
    {
        public int Column { get; private set; }

        public int Row { get; private set; }

        public Square(string square)
        {
            ValidateParam(square);
            ValidateColumn(square.First().ToString());
            ValidateRow(square.Last().ToString());
        }

        public Square New(int colIncrement, int rowIncrement)
        {
            var col = Column + colIncrement;
            var row = Row + rowIncrement;
            
            if ((row < 1 || row > 8) || (col < 1 || col > 8))
            {
                return null;
            }

            return new Square(ToString(col, row));
        }

        public override string ToString()
        {
            return ToString(Column, Row);
        }

        private string ToString(int col, int row)
        {
            return $"{((Column)(col)).ToString().ToLower()}{row}";
        }

        private static void ValidateParam(string square)
        {
            if (string.IsNullOrWhiteSpace(square) || square.Length != 2)
            {
                throw new ArgumentException("Square no valid!!");
            }
        }

        private void ValidateRow(string row)
        {
            int result;
            var success = int.TryParse(row, out result);

            if (!success || result < 1 || result > 8)
            {
                throw new ArgumentException("Unknown row Id");
            }

            Row = result;
        }

        private void ValidateColumn(string column)
        {
            // TODO: Can avoid use switch!?
            switch (column)
            {
                case "a":
                    Column = 1;
                    break;
                case "b":
                    Column = 2;
                    break;
                case "c":
                    Column = 3;
                    break;
                case "d":
                    Column = 4;
                    break;
                case "e":
                    Column = 5;
                    break;
                case "f":
                    Column = 6;
                    break;
                case "g":
                    Column = 7;
                    break;
                case "h":
                    Column = 8;
                    break;
                default:
                    throw new ArgumentException("Unknown column Id");
            }
        }
    }
}