﻿using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Software64.Chessmen.Contracts;
using Software64.Chessmen.Enums;

namespace Software64.Chessmen.UnitTest
{
    [TestFixture]
    class BishopTest
    {
        [Test]
        public void MoveTo_should_ignore_squares_that_are_not_allowed()
        {
            // Arrange
            const string currentSquare = "f1";
            const string targetSquare = "g8";
            ChessmenBase bishop = new Bishop(Color.Black, currentSquare);

            // Act
            bishop.MoveTo(targetSquare);

            // Assert
            Assert.That(bishop.Square, Is.EqualTo(currentSquare));
        }

        [Test]
        public void MoveTo_should_set_square_to_target_square()
        {
            // Arrange
            const string currentSquare = "f1";
            const string targetSquare = "c4";
            ChessmenBase bishop = new Bishop(Color.Black, currentSquare);

            // Act
            bishop.MoveTo(targetSquare);

            // Assert
            Assert.That(bishop.Square, Is.EqualTo(targetSquare));
        }

        [Test]
        public void CanMoveTo_should_return_true_when_target_square_is_valid()
        {
            // Arrange
            const string currentSquare = "f1";
            const string targetSquare = "b5";
            ChessmenBase bishop = new Bishop(Color.Black, currentSquare);

            // Act
            var result = bishop.CanMoveTo(targetSquare);

            // Assert
            Assert.That(result, Is.True);
        }

        [Test]
        public void CanMoveTo_should_return_false_when_target_square_is_not_valid()
        {
            // Arrange
            const string currentSquare = "f1";
            const string targetSquare = "d8";
            ChessmenBase bishop = new Bishop(Color.Black, currentSquare);

            // Act
            var result = bishop.CanMoveTo(targetSquare);

            // Assert
            Assert.That(result, Is.False);
        }

        [TestCaseSource("CornerCases")]
        [TestCaseSource("BorderCases")]
        [TestCaseSource("CentreCases")]
        public void Bishop_should_always_move_between_7_and_13_squares(string current, IEnumerable<string> expected)
        {
            // Arrange
            ChessmenBase bishop = new Bishop(Color.White, current);

            // Act
            IEnumerable<string> moves = bishop.GetPseudoMoves().ToList();

            // Assert
            Assert.That(moves.Count, Is.AtLeast(7));
            Assert.That(moves.Count, Is.AtMost(13));
            Assert.That(moves, Is.EquivalentTo(expected));
        }

        static IEnumerable<object[]> CornerCases = new List<object[]>
        {
            new object[] { "a1", new List<string> { "b2", "c3", "d4", "e5", "f6", "g7", "h8" }},
            new object[] { "a8", new List<string> { "b7", "c6", "d5", "e4", "f3", "g2", "h1" }},
            new object[] { "h1", new List<string> { "a8", "b7", "c6", "d5", "e4", "f3", "g2" }},
            new object[] { "h8", new List<string> { "a1", "b2", "c3", "d4", "e5", "f6", "g7" }}
        };

        static IEnumerable<object[]> BorderCases = new List<object[]>
        {
            new object[] { "d1", new List<string> { "c2", "b3", "a4", "e2", "f3", "g4", "h5" }},
            new object[] { "d8", new List<string> { "c7", "b6", "a5", "e7", "f6", "g5", "h4" } },
            new object[] { "a4", new List<string> { "b5", "c6", "d7", "e8", "b3", "c2", "d1" }},
            new object[] { "h4", new List<string> { "g5", "f6", "e7", "d8", "g3", "f2", "e1" }}
        };

        static IEnumerable<object[]> CentreCases = new List<object[]>
        {
            new object[] { "d4", new List<string> { "a1", "b2", "c3", "e5", "f6", "g7", "h8", "g1", "f2", "e3", "c5", "b6", "a7" }}
        };
    }
}
