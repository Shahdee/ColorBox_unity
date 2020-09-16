using System.Collections.Generic;
using UnityEngine;
using System;

public class LevelController : ILevelController, IDisposable
{
    public event Action OnLevelComplete;

    private const int LevelWidth = 6; 
    private const int LevelHeight = 6; 

    private LevelView _levelView;
    private readonly IInputController _inputController;
    private ILevelModel _levelModel;
    private IBlockModelFactory _blockFactory;
    private ILevelViewController _levelViewController;
    private IGameController _gameController;

    private LevelData _levelData;
    
    public LevelController(IGameController _gameController, 
                            LevelView levelView,
                            IInputController inputController)
    {
        _levelView = levelView;
        _inputController = inputController;
        _blockFactory = new BlockModelFactory();
        _levelModel = new LevelModel();
        _levelViewController = new LevelViewController(_levelView, _levelModel);
        
        _gameController.OnGameStateChange += GameStateChanged;
        _inputController.OnQuickTouch += QuickTouch;
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

    private void QuickTouch(Vector3 position)
    {
        var worldPosition = Camera.main.ScreenToWorldPoint(UnityEngine.Input.mousePosition);
        var blockPosition = _levelViewController.TransformPosition(worldPosition);

        var block = _levelModel.GetBlock(blockPosition);

        if (block == null)
        {
            Debug.LogError("No block model at " + blockPosition);
            return;
        }

        var blockView = _levelViewController.GetBlock(block);
        if (blockView == null)
        {
            Debug.LogError("No block view at " + blockPosition);
            return;
        }
        
        blockView.Show(true);

        // get block by touch 
        // rotate block for x seconds

        // check if there is another block with same color 
        // remove them if it's true 
    }

    private void GenerateLevel()
    {
        // int width = _levelView.Level.origin.x + _levelView.Level.size.x;
        // int height = _ _levelView.Level.origin.x + _levelView.Level.size.x;

        int width = LevelWidth;
        int height = LevelHeight;
        
        Debug.LogError("width " + width + " / height " + height);
        
        _levelModel.DestroyAllBlocks();
        
        // TODO
        // check out shader algorythms for color mixing
        // compare colors or pictures

        _levelData = new LevelData(width, height);
        _levelModel.Initialize(_levelData);

        var freeSpots = new List<Vector2Int>();

        for(int i=0; i<width; i++)
            for (int j = 0; j < height; j++)
                freeSpots.Add(new Vector2Int(i,j));

        for(int i=0; i<width; i++)
            for (int j = 0; j < height; j++)
            {
                if (freeSpots.Count > 0)
                    freeSpots.RemoveAt(0);
                else
                    break;
                
                var block = _levelModel.GetBlock(i, j);
                
                Debug.Log(" freeSpots.Count= " + freeSpots.Count);
                
                if (block != null)
                    continue;
                
                var red = UnityEngine.Random.Range(0f, 1f);
                var green = UnityEngine.Random.Range(0f, 1f);
                var blue = UnityEngine.Random.Range(0f, 1f);
                var finalColor = new Color(red, green, blue, 1f);
                
                var siblingIndex = UnityEngine.Random.Range(0, freeSpots.Count);
                Debug.Log("idx " + siblingIndex + " / freeSpots.Count " + freeSpots.Count);
                var siblingPosition = freeSpots[siblingIndex];
                
                freeSpots.RemoveAt(siblingIndex);
                
                var blockModel = _blockFactory.CreateBlock(finalColor, new Vector2Int(i, j), siblingPosition);
                var siblingBlock = _blockFactory.CreateBlock(finalColor, siblingPosition, new Vector2Int(i, j));
                _levelModel.PutBlock(blockModel);
                _levelModel.PutBlock(siblingBlock);
            }
    }


    public void Dispose()
    {
        _gameController.OnGameStateChange -= GameStateChanged;
        _inputController.OnQuickTouch -= QuickTouch;
    }
}
