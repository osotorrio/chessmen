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
    class RookTest
    {
        [TestCaseSource(typeof(RockTestFixture), "CornerCases")]
        [TestCaseSource(typeof(RockTestFixture), "BorderCases")]
        [TestCaseSource(typeof(RockTestFixture), "CentreCases")]
        public void Rock_should_always_move_14_squares(string source, IEnumerable<string> expected)
        {
            // Arrange
            Square square = new Square(source);
            IChessmen rock = new Rock();

            // Act
            IEnumerable<string> moves = rock.GetPseudoMovesFrom(square).ToList();

            // Assert
            Assert.That(moves.Count, Is.EqualTo(14));
            Assert.That(moves, Is.EquivalentTo(expected));
        }
    }
}
