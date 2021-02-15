using System;
using Characters;


public interface ILevelController
{
    event Action OnLevelComplete;

    void GenerateLevel();
    ICharacter GetCurrentCharacter();
    void ChangeCharacter();
}
