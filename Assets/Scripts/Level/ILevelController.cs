using System;


public interface ILevelController
{
    event Action OnLevelComplete;

    void GenerateLevel(int fieldSize);
}
