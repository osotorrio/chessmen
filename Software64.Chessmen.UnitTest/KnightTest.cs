using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Software64.Chessmen.Contracts;

namespace Software64.Chessmen.UnitTest
{
    [TestFixture]
    class KnightTest
    {
        [TestCase("a1", "b3", "c2")]
        [TestCase("a8", "b6", "c7")]
        [TestCase("h1", "g3", "f2")]
        [TestCase("h8", "g6", "f7")]
        public void Knight_should_move_2_squares_from_corner(string current, string target1, string target2)
        {
            // Arrange
            IChessmen knight = new Knight();

            // Act
            IEnumerable<string> moves = knight.GetPseudoMovesFrom(current).ToList();

            // Assert
            Assert.That(moves, Has.Count.EqualTo(2));
            Assert.That(moves, Has.Exactly(1).EqualTo(target1));
            Assert.That(moves, Has.Exactly(1).EqualTo(target2));
        }

        [TestCase("d1", "b2", "c3", "e3", "f2")]
        [TestCase("e8", "g7", "f6", "d6", "c7")]
        [TestCase("h4", "g2", "f3", "f5", "g6")]
        [TestCase("a5", "b7", "c6", "c4", "b3")]
        public void Knight_should_move_4_squares_from_border(string current, string target1, string target2, string target3, string target4)
        {
            // Arrange
            IChessmen knight = new Knight();

            // Act
            IEnumerable<string> moves = knight.GetPseudoMovesFrom(current).ToList();

            // Assert
            Assert.That(moves, Has.Count.EqualTo(4));
            Assert.That(moves, Has.Exactly(1).EqualTo(target1));
            Assert.That(moves, Has.Exactly(1).EqualTo(target2));
            Assert.That(moves, Has.Exactly(1).EqualTo(target3));
            Assert.That(moves, Has.Exactly(1).EqualTo(target4));
        }
    }
}
