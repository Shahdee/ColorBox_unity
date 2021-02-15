using System;
using System.Collections;
using Helpers;
using Initialization;
using UnityEngine;


public class GameController : IGameController, IDisposable
{
    public event Action<EGameState> OnGameStateChange;

    private const float LevelDelay = 2f;
    
    private readonly ILevelController _levelController;
    private readonly IInputController _inputController;
    private readonly IInitializeMediator _initializeMediator;
    private readonly ICoroutineManager _coroutineManager;

    private EGameState _gameState;

    public GameController(IInputController inputController,
                        IInitializeMediator initializeMediator,
                        ICoroutineManager coroutineManager,
                        ILevelController levelController)
    {
        _inputController = inputController;
        _initializeMediator = initializeMediator;
        _coroutineManager = coroutineManager;
        _levelController = levelController;
        
        _levelController.OnLevelComplete += LevelComplete;
        _initializeMediator.OnDone += InitDone;
    }

    public void StartGame()
    {
        SetGameState(EGameState.Play);
    }
    
    private void InitDone()
    {
        SetGameState(EGameState.Start);
    }

    private void LevelComplete()
    {
        SetGameState(EGameState.End);
        
        _coroutineManager.StartCoroutine(ContinueGame());
    }

    private IEnumerator ContinueGame()
    {
        yield return new WaitForSeconds(LevelDelay);
        
        SetGameState(EGameState.Play);
    }

    private void SetGameState(EGameState state)
    {
        _gameState = state;
        OnGameStateChange?.Invoke(_gameState);
        
        switch (_gameState)
        {
            case EGameState.Start:
                _inputController.SetEnabled(false);
            break;
            
            case EGameState.Play:
                _inputController.SetEnabled(true);
                _levelController.GenerateLevel();
                break;
            
            case EGameState.End:
                _inputController.SetEnabled(false);
                break;
        }
    }

    public void Dispose()
    {
        _levelController.OnLevelComplete -= LevelComplete;
    }

   
}
