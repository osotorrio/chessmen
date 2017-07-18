using System.Collections.Generic;
using System.Linq;
using Chessmen.Core.Board;
using Chessmen.Core.Pieces;
using Chessmen.Core.Contracts;
using Chessmen.UnitTest.Fixtures;
using NUnit.Framework;

namespace Chessmen.UnitTest.Pieces
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
            ISquare square = new Square(source);
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
