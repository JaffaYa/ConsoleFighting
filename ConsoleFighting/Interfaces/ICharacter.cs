using ConsoleFighting.Characters;

namespace ConsoleFighting.Interfaces
{
    internal interface ICharacter
    {
        void TakeAttak(Attack attack);
        void MakeAttak(Character enemy);

    }
}
