# What Chessmen does?
Chessmen is a collection of chess pieces which know where to move on the board. 

They just return pseudo moves or possible moves like if the board were empty. Meaning that **Chessmen is not a chess engine**, but it could be used to build one. 

Chessmen responses to the following question: **If I have a rook in d1, where could the rook move if the board were empty?**

# How can you install Chessmen?
You can install it from Nuget.org: [https://www.nuget.org/packages/Software64.Chessmen/](https://www.nuget.org/packages/Software64.Chessmen/)

Alternatively, you could pull the repository and add the two projects (Software64.Chessmen and Software.Chessmen.UnitTest) to your own solution.

# How can you use Chessmen?

```c#
using Software64.Chessmen;
using Software64.Chessmen.Contracts;
using Software64.Chessmen.Enums;

string currentSquare = "d4";
string targetSquare = "d1";

ChessmenBase rook = new Rook(Color.White, currentSquare);

bool canMove = rook.CanMoveTo(targetSquare);

if (canMove)
{
  rook.MoveTo(targetSquare);
}

IEnumerable<string> pseudoMoves = rook.GetPseudoMoves();

// pseudoMoves = [a1, b1, c1, d2, d3, d4, d5, d6, d7, d8, e1, f1, g1, h1]
```
All Chessmen objects (Rook, Queen, Bishop, etc) internally use [Square](https://github.com/osotorrio/chessmen/blob/master/Software64.Chessmen/Square.cs) which validates if the string (currentSquare) passed is valid. 

There is a third namespace **Software64.Chessmen.Enums** where you can find:
* [ColorEnum](https://github.com/osotorrio/chessmen/blob/master/Software64.Chessmen/Enums/ColorEnum.cs)
* [ColumnEnum](https://github.com/osotorrio/chessmen/blob/master/Software64.Chessmen/Enums/ColumnEnum.cs)
* [RowEnum](https://github.com/osotorrio/chessmen/blob/master/Software64.Chessmen/Enums/RowEnum.cs)

# Specifications
It targets .NET Framework 4.6.1
