using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LevelController : ILevelController, IDisposable
{
    public event Action OnLevelComplete;

    private LevelView _levelView;
    private ILevelModel _levelModel;
    private IBlockFactory _blockFactory;
    private ILevelViewController _levelViewController;
    private IGameController _gameController;

    private List<BlockData> _blockData;
    private LevelData _levelData;
    
    public LevelController(IGameController _gameController, 
                            LevelView levelView)
    {
        _levelView = levelView;
        _blockFactory = new BlockFactory(_levelView.BlockViewPrefab);
        _levelModel = new LevelModel();
        _levelViewController = new LevelViewController(_levelModel);
        
        _blockData = new List<BlockData>();
         
        _gameController.OnGameStateChange += GameStateChanged;
    }

    private void GameStateChanged(EGameState gameState)
    {
        Debug.LogError("gameState " + gameState);

        switch (gameState)
        {
            case EGameState.Play:
                GenerateLevel();
                break;
            
            case EGameState.End:

                break;
        }
    }

    private void GenerateLevel()
    {
        int width = _levelView.Level.origin.x + _levelView.Level.size.x;
        int height = _levelView.Level.origin.y + _levelView.Level.size.y;
        
        Debug.LogError("width " + width + " / height " + height);
        
        _blockData.Clear();
        _levelModel.DestroyAllBlocks();
        
        // check out shader algorythms for color mixing 
        
        
        _levelData = new LevelData(width, height, _blockData);
        _levelModel.Initialize(_levelData);
        
        // _levelView
        // LevelModel
        // _blockFactory
    }


    // level model is created here using algo 
        //  level model contains a list of block models 
    
    // view is filled from model 


    public void Dispose()
    {
        _gameController.OnGameStateChange -= GameStateChanged;
    }
}
