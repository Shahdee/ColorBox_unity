using System;

public interface IGameController
{
    event Action<EGameState> OnGameStateChange;
    void StartGame();
}