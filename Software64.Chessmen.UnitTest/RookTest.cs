using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Software64.Chessmen.Contracts;
using Software64.Chessmen.Enums;

namespace Software64.Chessmen.UnitTest
{
    [TestFixture]
    class RookTest
    {
        [Test]
        public void MoveTo_should_ignore_squares_that_are_not_allowed()
        {
            // Arrange
            const string currentSquare = "f1";
            const string targetSquare = "g8";
            ChessmenBase rook = new Rook(Color.Black, currentSquare);

            // Act
            rook.MoveTo(targetSquare);

            // Assert
            Assert.That(rook.Square, Is.EqualTo(currentSquare));
        }

        [Test]
        public void MoveTo_should_set_square_to_target_square()
        {
            // Arrange
            const string currentSquare = "f1";
            const string targetSquare = "b1";
            ChessmenBase rook = new Rook(Color.Black, currentSquare);

            // Act
            rook.MoveTo(targetSquare);

            // Assert
            Assert.That(rook.Square, Is.EqualTo(targetSquare));
        }

        [Test]
        public void CanMoveTo_should_return_true_when_target_square_is_valid()
        {
            // Arrange
            const string currentSquare = "f1";
            const string targetSquare = "h1";
            ChessmenBase rook = new Rook(Color.Black, currentSquare);

            // Act
            var result = rook.CanMoveTo(targetSquare);

            // Assert
            Assert.That(result, Is.True);
        }

        [Test]
        public void CanMoveTo_should_return_false_when_target_square_is_not_valid()
        {
            // Arrange
            const string currentSquare = "f1";
            const string targetSquare = "d8";
            ChessmenBase rook = new Rook(Color.Black, currentSquare);

            // Act
            var result = rook.CanMoveTo(targetSquare);

            // Assert
            Assert.That(result, Is.False);
        }

        [TestCaseSource("CornerCases")]
        [TestCaseSource("BorderCases")]
        [TestCaseSource("CentreCases")]
        public void Rock_should_always_move_14_squares(string current, IEnumerable<string> expected)
        {
            // Arrange
            ChessmenBase rook = new Rook(Color.White, current);

            // Act
            IEnumerable<string> moves = rook.GetPseudoMoves().ToList();

            // Assert
            Assert.That(moves.Count, Is.EqualTo(14));
            Assert.That(moves, Is.EquivalentTo(expected));
        }

        static IEnumerable<object[]> CornerCases = new List<object[]>
        {
            new object[] { "a1", new List<string> { "a2", "a3", "a4", "a5", "a6", "a7", "a8", "b1", "c1", "d1", "e1", "f1", "g1", "h1" }},
            new object[] { "a8", new List<string> { "a7", "a6", "a5", "a4", "a3", "a2", "a1", "b8", "c8", "d8", "e8", "f8", "g8", "h8" }},
            new object[] { "h1", new List<string> { "h2", "h3", "h4", "h5", "h6", "h7", "h8", "b1", "c1", "d1", "e1", "f1", "g1", "a1" }},
            new object[] { "h8", new List<string> { "h7", "h6", "h5", "h4", "h3", "h2", "h1", "b8", "c8", "d8", "e8", "f8", "g8", "a8" }}
        };

        static IEnumerable<object[]> BorderCases = new List<object[]>
        {
            new object[] { "d1", new List<string> { "d2", "d3", "d4", "d5", "d6", "d7", "d8", "a1", "b1", "c1", "e1", "f1", "g1", "h1" }},
            new object[] { "d8", new List<string> { "d2", "d3", "d4", "d5", "d6", "d7", "d1", "a8", "b8", "c8", "e8", "f8", "g8", "h8" }},
            new object[] { "a4", new List<string> { "a1", "a2", "a3", "a5", "a6", "a7", "a8", "b4", "c4", "d4", "e4", "f4", "g4", "h4" }},
            new object[] { "h4", new List<string> { "h1", "h2", "h3", "h5", "h6", "h7", "h8", "b4", "c4", "d4", "e4", "f4", "g4", "a4" }}
        };

        static IEnumerable<object[]> CentreCases = new List<object[]>
        {
            new object[] { "d4", new List<string> { "d1", "d2", "d3", "d5", "d6", "d7", "d8", "a4", "b4", "c4", "e4", "f4", "g4", "h4" }}
        };
    }
}
