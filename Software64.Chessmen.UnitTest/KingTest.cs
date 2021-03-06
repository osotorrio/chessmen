﻿using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Software64.Chessmen.Contracts;
using Software64.Chessmen.Enums;

namespace Software64.Chessmen.UnitTest
{
    [TestFixture]
    class KingTest
    {
        [Test]
        public void MoveTo_should_ignore_squares_that_are_not_allowed()
        {
            // Arrange
            const string currentSquare = "f1";
            const string targetSquare = "g8";
            ChessmenBase king = new King(Color.Black, currentSquare);

            // Act
            king.MoveTo(targetSquare);

            // Assert
            Assert.That(king.Square, Is.EqualTo(currentSquare));
        }

        [Test]
        public void MoveTo_should_set_square_to_target_square()
        {
            // Arrange
            const string currentSquare = "f1";
            const string targetSquare = "f2";
            ChessmenBase king = new King(Color.Black, currentSquare);

            // Act
            king.MoveTo(targetSquare);

            // Assert
            Assert.That(king.Square, Is.EqualTo(targetSquare));
        }

        [Test]
        public void CanMoveTo_should_return_true_when_target_square_is_valid()
        {
            // Arrange
            const string currentSquare = "e4";
            const string targetSquare = "e5";
            ChessmenBase king = new King(Color.Black, currentSquare);

            // Act
            var result = king.CanMoveTo(targetSquare);

            // Assert
            Assert.That(result, Is.True);
        }

        [Test]
        public void CanMoveTo_should_return_false_when_target_square_is_not_valid()
        {
            // Arrange
            const string currentSquare = "f1";
            const string targetSquare = "d8";
            ChessmenBase king = new King(Color.Black, currentSquare);

            // Act
            var result = king.CanMoveTo(targetSquare);

            // Assert
            Assert.That(result, Is.False);
        }

        [TestCase("a1", "b1", "b2", "a2")]
        [TestCase("a8", "a7", "b8", "b7")]
        [TestCase("h1", "g1", "g2", "h2")]
        [TestCase("h8", "g7", "g8", "h7")]
        public void King_should_move_to_3_squares_from_corner(string source, string target1, string target2, string target3)
        {
            // Arrange
            ChessmenBase king = new King(Color.White, source);

            // Act
            IEnumerable<string> moves = king.GetPseudoMoves().ToList();

            // Assert
            Assert.That(moves, Has.Count.EqualTo(3));
            Assert.That(moves, Has.Exactly(1).EqualTo(target1));
            Assert.That(moves, Has.Exactly(1).EqualTo(target2));
            Assert.That(moves, Has.Exactly(1).EqualTo(target3));
        }

        [TestCase("d1", "c1", "c2", "d2", "e2", "e1")]
        [TestCase("d8", "c8", "c7", "d7", "e7", "e8")]
        [TestCase("a4", "a5", "b5", "b4", "b3", "a3")]
        [TestCase("h4", "h5", "g5", "g4", "g3", "h3")]
        public void King_should_move_to_5_squares_from_border(string source, string target1, string target2, string target3, string target4, string target5)
        {
            // Arrange
            ChessmenBase king = new King(Color.White, source);

            // Act
            IEnumerable<string> moves = king.GetPseudoMoves().ToList();

            // Assert
            Assert.That(moves, Has.Count.EqualTo(5));
            Assert.That(moves, Has.Exactly(1).EqualTo(target1));
            Assert.That(moves, Has.Exactly(1).EqualTo(target2));
            Assert.That(moves, Has.Exactly(1).EqualTo(target3));
            Assert.That(moves, Has.Exactly(1).EqualTo(target4));
            Assert.That(moves, Has.Exactly(1).EqualTo(target5));
        }

        [Test]
        public void King_should_move_to_5_squares_from_middle()
        {
            // Arrange
            string current = "d4";
            ChessmenBase king = new King(Color.Black, current);

            // Act
            IEnumerable<string> moves = king.GetPseudoMoves().ToList();

            // Assert
            Assert.That(moves, Has.Count.EqualTo(8));
            Assert.That(moves, Has.Exactly(1).EqualTo("c5"));
            Assert.That(moves, Has.Exactly(1).EqualTo("d5"));
            Assert.That(moves, Has.Exactly(1).EqualTo("e5"));
            Assert.That(moves, Has.Exactly(1).EqualTo("e4"));
            Assert.That(moves, Has.Exactly(1).EqualTo("e3"));
            Assert.That(moves, Has.Exactly(1).EqualTo("d3"));
            Assert.That(moves, Has.Exactly(1).EqualTo("c3"));
            Assert.That(moves, Has.Exactly(1).EqualTo("c4"));
        }
    }
}
