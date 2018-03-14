using System.Collections.Generic;
using NUnit.Framework;
using Software64.Chessmen.Contracts;
using Software64.Chessmen.Enums;

namespace Software64.Chessmen.UnitTest
{
    [TestFixture]
    class PawnTest
    {
        [TestCase("a3", Color.White, "a4", "b4")]
        [TestCase("h3", Color.White, "h4", "g4")]
        [TestCase("a6", Color.Black, "a5", "b5")]
        [TestCase("h6", Color.Black, "h5", "g5")]
        public void Paw_should_move_2_squares_from(string current, Color color, string target1, string target2)
        {
            // Arrange
            ChessmenBase paw = new Pawn(color, current);

            // Act
            IEnumerable<string> moves = paw.GetPseudoMoves();

            // Assert
            Assert.That(moves, Has.Count.EqualTo(2));
            Assert.That(moves, Has.Exactly(1).EqualTo(target1));
            Assert.That(moves, Has.Exactly(1).EqualTo(target2));
        }

        [TestCase("a2", Color.White, "a3", "a4", "b3")]
        [TestCase("h2", Color.White, "h3", "h4", "g3")]
        [TestCase("d3", Color.White, "c4", "d4", "e4")]
        [TestCase("a7", Color.Black, "a6", "a5", "b6")]
        [TestCase("h7", Color.Black, "h6", "h5", "g6")]
        [TestCase("d6", Color.Black, "c5", "d5", "e5")]
        public void Paw_should_move_3_squares_from(string current, Color color, string target1, string target2, string target3)
        {
            // Arrange
            ChessmenBase paw = new Pawn(color, current);

            // Act
            IEnumerable<string> moves = paw.GetPseudoMoves();

            // Assert
            Assert.That(moves, Has.Count.EqualTo(3));
            Assert.That(moves, Has.Exactly(1).EqualTo(target1));
            Assert.That(moves, Has.Exactly(1).EqualTo(target2));
            Assert.That(moves, Has.Exactly(1).EqualTo(target3));
        }

        [TestCase("d2", Color.White, "d3", "d4", "c3", "e3")]
        [TestCase("d7", Color.Black, "d6", "d5", "c6", "e6")]
        public void Paw_should_move_4_squares_from(string current, Color color, string target1, string target2, string target3, string target4)
        {
            // Arrange
            ChessmenBase paw = new Pawn(color, current);

            // Act
            IEnumerable<string> moves = paw.GetPseudoMoves();

            // Assert
            Assert.That(moves, Has.Count.EqualTo(4));
            Assert.That(moves, Has.Exactly(1).EqualTo(target1));
            Assert.That(moves, Has.Exactly(1).EqualTo(target2));
            Assert.That(moves, Has.Exactly(1).EqualTo(target3));
            Assert.That(moves, Has.Exactly(1).EqualTo(target4));
        }
    }
}
