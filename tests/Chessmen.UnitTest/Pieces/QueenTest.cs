using System.Collections.Generic;
using System.Linq;
using AnToLan.Core.Board;
using AnToLan.Core.Pieces;
using AnToLan.Core.Contracts;
using AnToLan.UnitTest.Fixtures;
using NUnit.Framework;

namespace AnToLan.UnitTest.Pieces
{
    [TestFixture]
    class QueenTest
    {
        [TestCaseSource(typeof(QueenTestFixture), "CornerCases")]
        [TestCaseSource(typeof(QueenTestFixture), "BorderCases")]
        [TestCaseSource(typeof(QueenTestFixture), "CentreCases")]
        public void Queen_should_always_move_21_and_28_squares(string source, IEnumerable<string> expected)
        {
            // Arrange
            Square square = new Square(source);
            IChessmen queen = new Queen();

            // Act
            IEnumerable<string> moves = queen.GetPseudoMovesFrom(square).ToList();

            // Assert
            Assert.That(moves.Count, Is.AtLeast(21));
            Assert.That(moves.Count, Is.AtMost(28));
            Assert.That(moves, Is.EquivalentTo(expected));
        }
    }
}
