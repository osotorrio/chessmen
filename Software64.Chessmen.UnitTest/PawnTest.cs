using System.Collections.Generic;
using NUnit.Framework;
using Software64.Chessmen.Contracts;
using Software64.Chessmen.Enums;

namespace Software64.Chessmen.UnitTest
{
    [TestFixture]
    class PawnTest
    {
        [Test]
        public void MoveTo_should_ignore_squares_that_are_not_allowed()
        {
            // Arrange
            const string currentSquare = "e4";
            const string targetSquare = "g8";
            ChessmenBase pawn = new Pawn(Color.Black, currentSquare);

            // Act
            pawn.MoveTo(targetSquare);

            // Assert
            Assert.That(pawn.Square, Is.EqualTo(currentSquare));
        }

        [Test]
        public void MoveTo_should_set_square_to_target_square()
        {
            // Arrange
            const string currentSquare = "e5";
            const string targetSquare = "f4";
            ChessmenBase pawn = new Pawn(Color.Black, currentSquare);

            // Act
            pawn.MoveTo(targetSquare);

            // Assert
            Assert.That(pawn.Square, Is.EqualTo(targetSquare));
        }

        [Test]
        public void CanMoveTo_should_return_true_when_target_square_is_valid()
        {
            // Arrange
            const string currentSquare = "d3";
            const string targetSquare = "d2";
            ChessmenBase pawn = new Pawn(Color.Black, currentSquare);

            // Act
            var result = pawn.CanMoveTo(targetSquare);

            // Assert
            Assert.That(result, Is.True);
        }

        [Test]
        public void CanMoveTo_should_return_false_when_target_square_is_not_valid()
        {
            // Arrange
            const string currentSquare = "g6";
            const string targetSquare = "d8";
            ChessmenBase pawn = new Pawn(Color.Black, currentSquare);

            // Act
            var result = pawn.CanMoveTo(targetSquare);

            // Assert
            Assert.That(result, Is.False);
        }

        [TestCase("b3", "a4", "b4", "c4")]
        [TestCase("b4", "a5", "b5", "c5")]
        [TestCase("b5", "a6", "b6", "c6")]
        [TestCase("b6", "a7", "b7", "c7")]
        [TestCase("b7", "a8", "b8", "c8")]
        [TestCase("c3", "b4", "c4", "d4")]
        [TestCase("c4", "b5", "c5", "d5")]
        [TestCase("c5", "b6", "c6", "d6")]
        [TestCase("c6", "b7", "c7", "d7")]
        [TestCase("c7", "b8", "c8", "d8")]
        [TestCase("d3", "c4", "d4", "e4")]
        [TestCase("d4", "c5", "d5", "e5")]
        [TestCase("d5", "c6", "d6", "e6")]
        [TestCase("d6", "c7", "d7", "e7")]
        [TestCase("d7", "c8", "d8", "e8")]
        [TestCase("e3", "d4", "e4", "f4")]
        [TestCase("e4", "d5", "e5", "f5")]
        [TestCase("e5", "d6", "e6", "f6")]
        [TestCase("e6", "d7", "e7", "f7")]
        [TestCase("e7", "d8", "e8", "f8")]
        [TestCase("f3", "e4", "f4", "g4")]
        [TestCase("f4", "e5", "f5", "g5")]
        [TestCase("f5", "e6", "f6", "g6")]
        [TestCase("f6", "e7", "f7", "g7")]
        [TestCase("f7", "e8", "f8", "g8")]
        [TestCase("g3", "f4", "g4", "h4")]
        [TestCase("g4", "f5", "g5", "h5")]
        [TestCase("g5", "f6", "g6", "h6")]
        [TestCase("g6", "f7", "g7", "h7")]
        [TestCase("g7", "f8", "g8", "h8")]
        public void White_Pawn_can_move_3_squares_from_columns_B_to_G_and_rows_3_to_7(string current, string target1, string target2, string target3)
        {
            AssertThreeSquares(Color.White, current, target1, target2, target3);
        }

        [TestCase("b6", "a5", "b5", "c5")]
        [TestCase("b5", "a4", "b4", "c4")]
        [TestCase("b4", "a3", "b3", "c3")]
        [TestCase("b3", "a2", "b2", "c2")]
        [TestCase("b2", "a1", "b1", "c1")]
        [TestCase("c6", "b5", "c5", "d5")]
        [TestCase("c5", "b4", "c4", "d4")]
        [TestCase("c4", "b3", "c3", "d3")]
        [TestCase("c3", "b2", "c2", "d2")]
        [TestCase("c2", "b1", "c1", "d1")]
        [TestCase("d6", "c5", "d5", "e5")]
        [TestCase("d5", "c4", "d4", "e4")]
        [TestCase("d4", "c3", "d3", "e3")]
        [TestCase("d3", "c2", "d2", "e2")]
        [TestCase("d2", "c1", "d1", "e1")]
        [TestCase("e6", "d5", "e5", "f5")]
        [TestCase("e5", "d4", "e4", "f4")]
        [TestCase("e4", "d3", "e3", "f3")]
        [TestCase("e3", "d2", "e2", "f2")]
        [TestCase("e2", "d1", "e1", "f1")]
        [TestCase("f6", "e5", "f5", "g5")]
        [TestCase("f5", "e4", "f4", "g4")]
        [TestCase("f4", "e3", "f3", "g3")]
        [TestCase("f3", "e2", "f2", "g2")]
        [TestCase("f2", "e1", "f1", "g1")]
        [TestCase("g6", "f5", "g5", "h5")]
        [TestCase("g5", "f4", "g4", "h4")]
        [TestCase("g4", "f3", "g3", "h3")]
        [TestCase("g3", "f2", "g2", "h2")]
        [TestCase("g2", "f1", "g1", "h1")]
        public void Black_Pawn_can_move_3_squares_from_columns_B_to_G_and_rows_6_to_2(string current, string target1, string target2, string target3)
        {
            AssertThreeSquares(Color.Black, current, target1, target2, target3);
        }

        [TestCase("a3", "a4", "b4")]
        [TestCase("a4", "a5", "b5")]
        [TestCase("a5", "a6", "b6")]
        [TestCase("a6", "a7", "b7")]
        [TestCase("a7", "a8", "b8")]
        [TestCase("h3", "h4", "g4")]
        [TestCase("h4", "h5", "g5")]
        [TestCase("h5", "h6", "g6")]
        [TestCase("h6", "h7", "g7")]
        [TestCase("h7", "h8", "g8")]
        public void White_Pawn_can_move_2_squares_in_columns_A_and_H_and_rows_3_to_7(string current, string target1, string target2)
        {
            AssertTwoSquares(Color.White, current, target1, target2);
        }

        [TestCase("a6", "a5", "b5")]
        [TestCase("a5", "a4", "b4")]
        [TestCase("a4", "a3", "b3")]
        [TestCase("a3", "a2", "b2")]
        [TestCase("a2", "a1", "b1")]
        [TestCase("h6", "h5", "g5")]
        [TestCase("h5", "h4", "g4")]
        [TestCase("h4", "h3", "g3")]
        [TestCase("h3", "h2", "g2")]
        [TestCase("h2", "h1", "g1")]
        public void Black_Pawn_can_move_2_squares_in_columns_A_and_H_and_rows_6_to_2(string current, string target1, string target2)
        {
            AssertTwoSquares(Color.Black, current, target1, target2);
        }

        [TestCase("b2", "a3", "b3", "c3", "b4")]
        [TestCase("c2", "b3", "c3", "d3", "c4")]
        [TestCase("d2", "c3", "d3", "e3", "d4")]
        [TestCase("e2", "d3", "e3", "f3", "e4")]
        [TestCase("f2", "e3", "f3", "g3", "f4")]
        [TestCase("g2", "f3", "g3", "h3", "g4")]
        public void White_Pawn_can_move_4_squares_from_columns_b_to_g_and_row_2(string current, string target1, string target2, string target3, string target4)
        {
            AssertFourSquares(Color.White, current, target1, target2, target3, target4);
        }

        [TestCase("b7", "a6", "b6", "c6", "b5")]
        [TestCase("g7", "f6", "g6", "h6", "g5")]
        [TestCase("c7", "b6", "c6", "d6", "c5")]
        [TestCase("d7", "c6", "d6", "e6", "d5")]
        [TestCase("e7", "d6", "e6", "f6", "e5")]
        [TestCase("f7", "e6", "f6", "g6", "f5")]
        public void Black_Pawn_can_move_4_squares_from_columns_B_to_G_and_row_7(string current, string target1, string target2, string target3, string target4)
        {
            AssertFourSquares(Color.Black, current, target1, target2, target3, target4);
        }

        [TestCase("a2", "a3", "b3", "a4")]
        [TestCase("h2", "h3", "g3", "h4")]
        public void White_Pawn_can_move_3_squares_in_columns_A_and_H_and_row_2(string current, string target1, string target2, string target3)
        {
            AssertThreeSquares(Color.White, current, target1, target2, target3);
        }

        [TestCase("a7", "a6", "b6", "a5")]
        [TestCase("h7", "h6", "g6", "h5")]
        public void Black_Pawn_can_move_3_squares_in_columns_A_and_H_and_row_7(string current, string target1, string target2, string target3)
        {
            AssertThreeSquares(Color.Black, current, target1, target2, target3);
        }

        [TestCase("a8")]
        [TestCase("b8")]
        [TestCase("c8")]
        [TestCase("d8")]
        [TestCase("e8")]
        [TestCase("f8")]
        [TestCase("g8")]
        [TestCase("h8")]
        public void White_Pawn_cannot_move_from_row_8(string current)
        {
            // Arrange
            ChessmenBase paw = new Pawn(Color.White, current);

            // Act
            IEnumerable<string> moves = paw.GetPseudoMoves();

            // Assert
            Assert.That(moves, Has.Count.EqualTo(0));
        }

        [TestCase("a1")]
        [TestCase("b1")]
        [TestCase("c1")]
        [TestCase("d1")]
        [TestCase("e1")]
        [TestCase("f1")]
        [TestCase("g1")]
        [TestCase("h1")]
        public void Black_Pawn_cannot_move_from_row_1(string current)
        {
            // Arrange
            ChessmenBase paw = new Pawn(Color.Black, current);

            // Act
            IEnumerable<string> moves = paw.GetPseudoMoves();

            // Assert
            Assert.That(moves, Has.Count.EqualTo(0));
        }

        private static void AssertTwoSquares(Color color, string current, string target1, string target2)
        {
            // Arrange
            ChessmenBase paw = new Pawn(color, current);

            // Act
            IEnumerable<string> moves = paw.GetPseudoMoves();

            // Assert
            Assert.That(moves, Has.Count.EqualTo(2));
            Assert.That(moves, Has.Exactly(1).EqualTo(target1));
            Assert.That(moves, Has.Exactly(1).EqualTo(target2));
        }

        private static void AssertThreeSquares(Color color, string current, string target1, string target2, string target3)
        {
            // Arrange
            ChessmenBase paw = new Pawn(color, current);

            // Act
            IEnumerable<string> moves = paw.GetPseudoMoves();

            // Assert
            Assert.That(moves, Has.Count.EqualTo(3));
            Assert.That(moves, Has.Exactly(1).EqualTo(target1));
            Assert.That(moves, Has.Exactly(1).EqualTo(target2));
            Assert.That(moves, Has.Exactly(1).EqualTo(target3));
        }

        private static void AssertFourSquares(Color color, string current, string target1, string target2, string target3, string target4)
        {
            // Arrange
            ChessmenBase paw = new Pawn(color, current);

            // Act
            IEnumerable<string> moves = paw.GetPseudoMoves();

            // Assert
            Assert.That(moves, Has.Count.EqualTo(4));
            Assert.That(moves, Has.Exactly(1).EqualTo(target1));
            Assert.That(moves, Has.Exactly(1).EqualTo(target2));
            Assert.That(moves, Has.Exactly(1).EqualTo(target3));
            Assert.That(moves, Has.Exactly(1).EqualTo(target4));
        }
    }
}