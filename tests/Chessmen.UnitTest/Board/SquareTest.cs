using System;
using NUnit.Framework;
using Chessmen.Core.Board;
using Chessmen.Core.Contracts;

namespace Chessmen.UnitTest.Board
{
    [TestFixture]
    public class SquareTest
    {
        [TestCase(null)]
        [TestCase("")]
        [TestCase("  ")]
        [TestCase("a")]
        [TestCase("abc")]
        public void Square_should_throw_exception_when_param_is_not_valid(string square)
        {
            // Assert
            Assert.Throws<ArgumentException>(() => new Square(square));
        }

        [TestCase("a0")]
        [TestCase("a9")]
        [TestCase("aa")]
        public void Square_should_throw_exception_when_row_is_not_valid(string square)
        {
            // Assert
            Assert.Throws<ArgumentException>(() => new Square(square));
        }
        
        [Test]
        public void Square_should_throw_exception_when_column_is_not_valid()
        {
            // Assert
            Assert.Throws<ArgumentException>(() => new Square("w3"));
        }

        [Test]
        public void ToString_should_return_same_square()
        {
            // Arrange
            string expectedSquare = "e4";
            ISquare square = new Square(expectedSquare);

            // Act
            string actualSquare = square.ToString();

            // Assert
            Assert.That(actualSquare, Is.EqualTo(expectedSquare));
        }

        [TestCase("a1", 7, 7, "h8")]
        [TestCase("a1", 0, 0, "a1")]
        [TestCase("a1", 1, 0, "b1")]
        [TestCase("a1", 0, 1, "a2")]
        public void New_should_create_new_square(string source, int columIncrease, int rowIncrease, string target)
        {
            // Arrange
            ISquare square = new Square(source);

            // Act
            ISquare newSquare = square.New(columIncrease, rowIncrease);
            string actual = newSquare.ToString();

            // Assert
            Assert.That(actual, Is.EqualTo(target));
        }

        [TestCase(1, -100)]
        [TestCase(-100, 1)]
        [TestCase(-100, -100)]
        public void New_should_return_null_when_it_is_out_of_board(int col, int row)
        {
            // Arrange
            ISquare square = new Square("a1");

            // Act
            ISquare newSquare = square.New(col, row);

            // Assert
            Assert.That(newSquare, Is.Null);
        }
    }
}
