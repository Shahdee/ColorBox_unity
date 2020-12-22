using UnityEngine;
using System;

public class LevelModel : ILevelModel
{
    public event Action<IBlockModel> OnBlockPut;
    public event Action<IBlockModel> OnBlockDestroy;
    public event Action OnAllBlocksDestroy;
    
    public int Width => _levelData.Width;
    public int Height => _levelData.Height;
    public int CurrentLevel => _currentLevel;

    private IBlockModel[,] _blocks;
    private LevelData _levelData;
    private int _currentLevel; 

    public LevelModel()
    {
        
    }

    public void Initialize(LevelData levelData)
    {
        _levelData = levelData;
        _blocks = new IBlockModel[_levelData.Width, _levelData.Height];
        _currentLevel = _levelData.StartLevel;
    }

    public void AdvanceLevel()
    {
        _currentLevel++;
    }

    public void PutBlock(IBlockModel block)
    {
        _blocks[block.Position.x, block.Position.y] = block;

        block.OnDestroy += BlockDestroy;
        
        OnBlockPut?.Invoke(block);
    }

    public void DestroyAllBlocks()
    {
        if (_levelData == null)
            return;
        
        for(int i=0; i<_levelData.Width; i++)
            for (int j = 0; j < _levelData.Height; j++)
            {
                if (_blocks[i,j] != null)
                    _blocks[i,j].Destroy();
            }
    }

    public IBlockModel GetBlock(Vector2Int position)
    {
        if (position.x < 0 || position.x >= _levelData.Width)
            return null;
            
        if (position.y < 0 || position.y >= _levelData.Height)
            return null;

        return _blocks[position.x, position.y];
    } 
    
    public IBlockModel GetBlock(int x, int y)
    {
        if (x < 0 || x > _levelData.Width)
            return null;
            
        if (y < 0 || y > _levelData.Height)
            return null;

        return _blocks[x, y];
    }

    private bool HasBlocks()
    {
        for (int i=0; i<_levelData.Width; i++)
            for (int j = 0; j < _levelData.Height; j++)
            {
                if (_blocks[i, j] != null)
                    return true;
            }

        return false;
    }

    private void BlockDestroy(IBlockModel blockModel)
    {
        blockModel.OnDestroy -= BlockDestroy;
        
        _blocks[blockModel.Position.x, blockModel.Position.y] = null;
        
        if (! HasBlocks())
            OnAllBlocksDestroy?.Invoke();
    }
}
