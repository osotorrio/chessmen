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
    class BishopTest
    {
        [TestCaseSource(typeof(BishopTestFixture), "CornerCases")]
        [TestCaseSource(typeof(BishopTestFixture), "BorderCases")]
        [TestCaseSource(typeof(BishopTestFixture), "CentreCases")]
        public void Bishop_should_always_move_between_7_and_13_squares(string source, IEnumerable<string> expected)
        {
            // Arrange
            Square square = new Square(source);
            IChessmen bishop = new Bishop();

            // Act
            IEnumerable<string> moves = bishop.GetPseudoMovesFrom(square).ToList();

            // Assert
            Assert.That(moves.Count, Is.AtLeast(7));
            Assert.That(moves.Count, Is.AtMost(13));
            Assert.That(moves, Is.EquivalentTo(expected));
        }
    }
}
