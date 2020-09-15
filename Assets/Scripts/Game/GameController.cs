using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour, IGameController
{
    public event Action<EGameState> OnGameStateChange;
    
    [SerializeField] private LevelView _levelView;

    private ILevelController _levelController;
    private EGameState _gameState;
    
    private void Awake()
    {
        _levelController = new LevelController(this, _levelView);

        SetGameState(EGameState.Play);
    }


    private void SetGameState(EGameState state)
    {
        _gameState = state;
        OnGameStateChange?.Invoke(_gameState);
    }

}
