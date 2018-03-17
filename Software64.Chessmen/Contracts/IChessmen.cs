using Software64.Chessmen.Enums;

namespace Software64.Chessmen.Contracts
{
    public interface IChessmen
    {
        Color Color { get; }

        string Square { get; }
    }
}
