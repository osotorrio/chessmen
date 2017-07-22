# What Chessmen does?
Chessmen is a collection of chess pieces which know where to move on the board. 

They just return pseudo moves or possible moves like if the board were empty. Meaning that Chessmen is not a chess engine, but it could be used to build one. 

Chessmen responses to the following question: **If I have a rock in d1, where could the rock move if the board were empty?**

# How can install Chessmen?
You can install it from Nuget.org: [https://www.nuget.org/packages/Software64.Chessmen/](https://www.nuget.org/packages/Software64.Chessmen/)

Alternatively, you could pull the repository and add the two projects (Software64.Chessmen and Software.Chessmen.UnitTest) to your own solution.

# How can I use Chessmen?

```c#
using Software64.Chessmen;

string currentSquare = "d1";
var rock = new Rock();

IEnumerable<string> pseudoMoves = rock.GetPseudoMovesFrom(currentSquare);

// pseudoMoves = [a1, b1, c1, d2, d3, d4, d5, d6, d7, d8, e1, f1, g1, h1]
```

# Specifications
It targets .NET Framework 4.6.1
