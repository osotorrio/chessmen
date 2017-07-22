using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Software64.Chessmen.Contracts;

namespace Software64.Chessmen.UnitTest
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
            ISquare square = new Square(source);
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
