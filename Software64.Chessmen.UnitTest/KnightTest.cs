using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Software64.Chessmen.Contracts;
using Software64.Chessmen.Enums;

namespace Software64.Chessmen.UnitTest
{
    [TestFixture]
    class KnightTest
    {
        [Test]
        public void MoveTo_should_ignore_squares_that_are_not_allowed()
        {
            // Arrange
            const string currentSquare = "f1";
            const string targetSquare = "g8";
            ChessmenBase knight = new Knight(Color.Black, currentSquare);

            // Act
            knight.MoveTo(targetSquare);

            // Assert
            Assert.That(knight.Square, Is.EqualTo(currentSquare));
        }

        [Test]
        public void MoveTo_should_set_square_to_target_square()
        {
            // Arrange
            const string currentSquare = "f3";
            const string targetSquare = "g5";
            ChessmenBase knight = new Knight(Color.Black, currentSquare);

            // Act
            knight.MoveTo(targetSquare);

            // Assert
            Assert.That(knight.Square, Is.EqualTo(targetSquare));
        }

        [Test]
        public void CanMoveTo_should_return_true_when_target_square_is_valid()
        {
            // Arrange
            const string currentSquare = "g1";
            const string targetSquare = "f3";
            ChessmenBase knight = new Knight(Color.Black, currentSquare);

            // Act
            var result = knight.CanMoveTo(targetSquare);

            // Assert
            Assert.That(result, Is.True);
        }

        [Test]
        public void CanMoveTo_should_return_false_when_target_square_is_not_valid()
        {
            // Arrange
            const string currentSquare = "f1";
            const string targetSquare = "d8";
            ChessmenBase knight = new Knight(Color.Black, currentSquare);

            // Act
            var result = knight.CanMoveTo(targetSquare);

            // Assert
            Assert.That(result, Is.False);
        }

        [TestCase("a1", "b3", "c2")]
        [TestCase("a8", "b6", "c7")]
        [TestCase("h1", "g3", "f2")]
        [TestCase("h8", "g6", "f7")]
        public void Knight_should_move_2_squares_from_corner(string current, string target1, string target2)
        {
            // Arrange
            ChessmenBase knight = new Knight(Color.White, current);

            // Act
            IEnumerable<string> moves = knight.GetPseudoMoves().ToList();

            // Assert
            Assert.That(moves, Has.Count.EqualTo(2));
            Assert.That(moves, Has.Exactly(1).EqualTo(target1));
            Assert.That(moves, Has.Exactly(1).EqualTo(target2));
        }

        [TestCase("d1", "b2", "c3", "e3", "f2")]
        [TestCase("e8", "g7", "f6", "d6", "c7")]
        [TestCase("h4", "g2", "f3", "f5", "g6")]
        [TestCase("a5", "b7", "c6", "c4", "b3")]
        public void Knight_should_move_4_squares_from_border(string current, string target1, string target2, string target3, string target4)
        {
            // Arrange
            ChessmenBase knight = new Knight(Color.Black, current);

            // Act
            IEnumerable<string> moves = knight.GetPseudoMoves().ToList();

            // Assert
            Assert.That(moves, Has.Count.EqualTo(4));
            Assert.That(moves, Has.Exactly(1).EqualTo(target1));
            Assert.That(moves, Has.Exactly(1).EqualTo(target2));
            Assert.That(moves, Has.Exactly(1).EqualTo(target3));
            Assert.That(moves, Has.Exactly(1).EqualTo(target4));
        }
    }
}
