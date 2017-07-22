using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Software64.Chessmen.Contracts;

namespace Software64.Chessmen.UnitTest
{
    [TestFixture]
    class RookTest
    {
        [TestCaseSource(typeof(RockTestFixture), "CornerCases")]
        [TestCaseSource(typeof(RockTestFixture), "BorderCases")]
        [TestCaseSource(typeof(RockTestFixture), "CentreCases")]
        public void Rock_should_always_move_14_squares(string source, IEnumerable<string> expected)
        {
            // Arrange
            ISquare square = new Square(source);
            IChessmen rock = new Rock();

            // Act
            IEnumerable<string> moves = rock.GetPseudoMovesFrom(square).ToList();

            // Assert
            Assert.That(moves.Count, Is.EqualTo(14));
            Assert.That(moves, Is.EquivalentTo(expected));
        }
    }
}
