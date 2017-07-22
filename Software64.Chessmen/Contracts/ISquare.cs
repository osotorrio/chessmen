namespace Software64.Chessmen.Contracts
{
    public interface ISquare
    {
        int Column { get; }

        int Row { get; }

        Square New(int colIncrement, int rowIncrement);
    }
}
