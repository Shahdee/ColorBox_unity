using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour, IGameController, IDisposable
{
    public event Action<EGameState> OnGameStateChange;
    
    [SerializeField] private LevelView _levelView;
    [SerializeField] private AudioDatabase _audioDatabase;

    private ILevelController _levelController;
    private IAudioController _audioController;
    private IInputController _inputController;
    private EGameState _gameState;
    
    private void Awake()
    {
        
#if UNITY_STANDALONE || UNITY_EDITOR
        _inputController = new MouseController();
#else
         _inputController = new TouchController();
#endif
        
        _audioController = new AudioController(_audioDatabase);
        
        _levelController = new LevelController(this,
                                                _levelView,
                                                _inputController,
                                                _audioController);

        _levelController.OnLevelComplete += LevelComplete;
        
        SetGameState(EGameState.Play);
    }

    private void LevelComplete()
    {
        // TODO 
        // pause to show level over screen or whatever 
        
        SetGameState(EGameState.Play);
    }

    private void SetGameState(EGameState state)
    {
        _gameState = state;
        OnGameStateChange?.Invoke(_gameState);

        switch (_gameState)
        {
            case EGameState.Play:
                _inputController.SetEnabled(true);
                break;
            
            case EGameState.End:
                _inputController.SetEnabled(false);
                break;
        }
    }

    private void Update()
    {
        _inputController.Tick();
    }

    public void Dispose()
    {
        _levelController.OnLevelComplete -= LevelComplete;
    }
}
