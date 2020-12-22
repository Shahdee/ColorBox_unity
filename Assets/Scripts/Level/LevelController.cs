using System.Collections.Generic;
using UnityEngine;
using System;
using Audio;

public class LevelController : ILevelController, IDisposable
{
    public event Action OnLevelComplete;

    private const int DefaultLevel = 1;

    private readonly LevelView _levelView;
    private readonly IInputController _inputController;
    private readonly IAudioController _audioController;
    private readonly ILevelModel _levelModel;
    
    private IBlockModelFactory _blockFactory;
    private ILevelViewController _levelViewController;

    private LevelData _levelData;
    private List<BlockView> _showingBlocks;

    private bool _initialize = true;
    
    public LevelController(LevelView levelView,
                            ILevelModel levelModel,
                            IInputController inputController,
                            IAudioController audioController)
    {
        _levelView = levelView;
        _levelModel = levelModel;
        _inputController = inputController;
        _audioController = audioController;
        
        // TODO installers 
        _blockFactory = new BlockModelFactory();
        // _levelModel = new LevelModel();
        _levelViewController = new LevelViewController(_levelView, _levelModel);
        _showingBlocks = new List<BlockView>();
        // 
        
        _inputController.OnQuickTouch += QuickTouch;
        _levelModel.OnAllBlocksDestroy += AllBlocksDestroy;
    }

    public void GenerateLevel(int fieldSize)
    {
        // int width = _levelView.Level.origin.x + _levelView.Level.size.x;
        // int height = _ _levelView.Level.origin.x + _levelView.Level.size.x;

        int width = fieldSize;
        int height = fieldSize;
        
        Debug.LogError("width " + width + " / height " + height);
        
        _levelModel.DestroyAllBlocks();

        if (_initialize)
        {
            _initialize = false;
            
            _levelData = new LevelData(width, height, DefaultLevel);
            _levelModel.Initialize(_levelData);
        }
        else
        {
            _levelModel.AdvanceLevel();
        }

        var freeSpots = new List<Vector2Int>();

        for(int i=0; i<width; i++)
        for (int j = 0; j < height; j++)
            freeSpots.Add(new Vector2Int(i,j));

        for(int i=0; i<width; i++)
        for (int j = 0; j < height; j++)
        {
            var block = _levelModel.GetBlock(i, j);
                
            if (block != null)
                continue;
                
            freeSpots.RemoveAt(0);
                
            var red = UnityEngine.Random.Range(0f, 1f);
            var green = UnityEngine.Random.Range(0f, 1f);
            var blue = UnityEngine.Random.Range(0f, 1f);
            var finalColor = new Color(red, green, blue, 1f);
                
            var siblingIndex = UnityEngine.Random.Range(0, freeSpots.Count);
            var siblingPosition = freeSpots[siblingIndex];
                
            freeSpots.RemoveAt(siblingIndex);
                
            var blockModel = _blockFactory.CreateBlock(finalColor, new Vector2Int(i, j), siblingPosition);
            var siblingBlock = _blockFactory.CreateBlock(finalColor, siblingPosition, new Vector2Int(i, j));
            _levelModel.PutBlock(blockModel);
            _levelModel.PutBlock(siblingBlock);
        }
    }

    private void QuickTouch(Vector3 position)
    {
        if (_showingBlocks.Count > 1)
            return;
        
        var worldPosition = Camera.main.ScreenToWorldPoint(UnityEngine.Input.mousePosition);
        var blockPosition = _levelViewController.TransformPosition(worldPosition);

        var block = _levelModel.GetBlock(blockPosition);

        if (block == null)
            return;
        
        var blockView = _levelViewController.GetBlock(block);
        if (blockView == null)
            return;
        
        if (blockView.TryShow(true))
        {
            _audioController.PlaySound(ESoundType.Tap);
            _showingBlocks.Add(blockView);
            blockView.OnBlockHid += BlockHid;
        }

        TryEatBlocks();
    }

    private void TryEatBlocks()
    {
        if (_showingBlocks.Count < 2)
            return;
        
        var currentBlock = _showingBlocks[_showingBlocks.Count - 1];
        
        for (int i = _showingBlocks.Count - 2; i >= 0; i--)
        {
            if (_showingBlocks[i].BlockModel.SiblingPosition.Equals(currentBlock.BlockModel.Position))
            {
                currentBlock.OnBlockHid -= BlockHid;
                _showingBlocks[i].OnBlockHid -= BlockHid;
                
                currentBlock.BlockModel.Eat();
                _showingBlocks[i].BlockModel.Eat();
                
                _showingBlocks.Remove(currentBlock);
                _showingBlocks.RemoveAt(i);
                
                _audioController.PlaySound(ESoundType.Eat);
                
                break;
            }
        }
    }

    private void BlockHid(BlockView blockView)
    {
        blockView.OnBlockHid -= BlockHid;

        if (_showingBlocks.Contains(blockView))
            _showingBlocks.Remove(blockView);
    }

   

    private void AllBlocksDestroy()
    {
        OnLevelComplete?.Invoke();
    }

    public void Dispose()
    {
        _inputController.OnQuickTouch -= QuickTouch;
        _levelModel.OnAllBlocksDestroy -= AllBlocksDestroy;
    }
}
