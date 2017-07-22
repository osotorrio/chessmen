using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Software64.Chessmen.Contracts;
using Software64.Chessmen.Enums;

namespace Software64.Chessmen.UnitTest
{
    [TestFixture]
    class QueenTest
    {
        [TestCaseSource("CornerCases")]
        [TestCaseSource("BorderCases")]
        [TestCaseSource("CentreCases")]
        public void Queen_should_always_move_21_and_28_squares(string current, IEnumerable<string> expected)
        {
            // Arrange
            ChessmenBase queen = new Queen(Color.Black);

            // Act
            IEnumerable<string> moves = queen.GetPseudoMovesFrom(current).ToList();

            // Assert
            Assert.That(moves.Count, Is.AtLeast(21));
            Assert.That(moves.Count, Is.AtMost(28));
            Assert.That(moves, Is.EquivalentTo(expected));
        }

        static IEnumerable<object[]> CornerCases = new List<object[]>
        {
            new object[] { "a1", new List<string> { "a2", "a3", "a4", "a5", "a6", "a7", "a8", "b1", "c1", "d1", "e1", "f1", "g1", "h1", "b2", "c3", "d4", "e5", "f6", "g7", "h8" }},
            new object[] { "a8", new List<string> { "a7", "a6", "a5", "a4", "a3", "a2", "a1", "b8", "c8", "d8", "e8", "f8", "g8", "h8", "b7", "c6", "d5", "e4", "f3", "g2", "h1" }},
            new object[] { "h1", new List<string> { "h2", "h3", "h4", "h5", "h6", "h7", "h8", "b1", "c1", "d1", "e1", "f1", "g1", "a1", "a8", "b7", "c6", "d5", "e4", "f3", "g2" }},
            new object[] { "h8", new List<string> { "h7", "h6", "h5", "h4", "h3", "h2", "h1", "b8", "c8", "d8", "e8", "f8", "g8", "a8", "a1", "b2", "c3", "d4", "e5", "f6", "g7" }}
        };

        static IEnumerable<object[]> BorderCases = new List<object[]>
        {
            new object[] { "d1", new List<string> { "d2", "d3", "d4", "d5", "d6", "d7", "d8", "a1", "b1", "c1", "e1", "f1", "g1", "h1", "c2", "b3", "a4", "e2", "f3", "g4", "h5" }},
            new object[] { "d8", new List<string> { "d2", "d3", "d4", "d5", "d6", "d7", "d1", "a8", "b8", "c8", "e8", "f8", "g8", "h8", "c7", "b6", "a5", "e7", "f6", "g5", "h4" }},
            new object[] { "a4", new List<string> { "a1", "a2", "a3", "a5", "a6", "a7", "a8", "b4", "c4", "d4", "e4", "f4", "g4", "h4", "b5", "c6", "d7", "e8", "b3", "c2", "d1" }},
            new object[] { "h4", new List<string> { "h1", "h2", "h3", "h5", "h6", "h7", "h8", "b4", "c4", "d4", "e4", "f4", "g4", "a4", "g5", "f6", "e7", "d8", "g3", "f2", "e1" }}
        };

        static IEnumerable<object[]> CentreCases = new List<object[]>
        {
            new object[] { "d4", new List<string> { "d1", "d2", "d3", "d5", "d6", "d7", "d8", "a4", "b4", "c4", "e4", "f4", "g4", "h4", "a1", "b2", "c3", "e5", "f6", "g7", "h8", "g1", "f2", "e3", "c5", "b6", "a7" }}
        };
    }
}
