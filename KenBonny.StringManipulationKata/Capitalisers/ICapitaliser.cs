using KenBonny.StringManipulationKata.Commands;

namespace KenBonny.StringManipulationKata.Capitalisers
{
    public interface ICapitaliser
    {
        string Capitalise(Command command);
    }
}