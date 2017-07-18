using Chessmen.Core.Board;

namespace Chessmen.Core.Contracts
{
    public interface ISquare
    {
        int Column { get; }

        int Row { get; }

        Square New(int colIncrease, int rowIncrease);
    }
}
