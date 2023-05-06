using System;
using ConsoleFighting.Characters;

namespace ConsoleFighting.Interfaces
{
    internal interface ISetUpCharacter
    {
        Character Create(string title);
        Character SetUpCharacter(Character character);
    }
}
