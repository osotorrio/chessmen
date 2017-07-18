using System.Collections.Generic;

namespace Chessmen.UnitTest.Fixtures
{
    class BishopTestFixture
    {
        static IEnumerable<object[]> CornerCases = new List<object[]>
        {
            new object[] { "a1", new List<string> { "b2", "c3", "d4", "e5", "f6", "g7", "h8" }},
            new object[] { "a8", new List<string> { "b7", "c6", "d5", "e4", "f3", "g2", "h1" }},
            new object[] { "h1", new List<string> { "a8", "b7", "c6", "d5", "e4", "f3", "g2" }},
            new object[] { "h8", new List<string> { "a1", "b2", "c3", "d4", "e5", "f6", "g7" }}
        };

        static IEnumerable<object[]> BorderCases = new List<object[]>
        {
            new object[] { "d1", new List<string> { "c2", "b3", "a4", "e2", "f3", "g4", "h5" }},
            new object[] { "d8", new List<string> { "c7", "b6", "a5", "e7", "f6", "g5", "h4" } },
            new object[] { "a4", new List<string> { "b5", "c6", "d7", "e8", "b3", "c2", "d1" }},
            new object[] { "h4", new List<string> { "g5", "f6", "e7", "d8", "g3", "f2", "e1" }}
        };

        static IEnumerable<object[]> CentreCases = new List<object[]>
        {
            new object[] { "d4", new List<string> { "a1", "b2", "c3", "e5", "f6", "g7", "h8", "g1", "f2", "e3", "c5", "b6", "a7" }}
        };
    }
}
