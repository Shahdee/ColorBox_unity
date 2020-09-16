using UnityEngine;
using System;

public class LevelModel : ILevelModel
{
    public event Action<IBlockModel> OnBlockPut;
    public event Action<IBlockModel> OnBlockDestroy;
    public int Width => _levelData.Width;
    public int Height => _levelData.Height;

    private IBlockModel[,] _blocks;
    private LevelData _levelData;

    public LevelModel()
    {
        
    }

    public void Initialize(LevelData levelData)
    {
        _levelData = levelData;
        _blocks = new IBlockModel[_levelData.Width, _levelData.Height];
    }

    public void PutBlock(IBlockModel block)
    {
        _blocks[block.Position.x, block.Position.y] = block;
        
        OnBlockPut?.Invoke(block);
    }

    public void DestroyAllBlocks()
    {
        if (_levelData == null)
            return;
        
        for(int i=0; i<_levelData.Width; i++)
            for (int j = 0; j < _levelData.Height; j++)
                _blocks[i,j].Destroy();
    }

    public IBlockModel GetBlock(Vector2Int position)
    {
        if (position.x < 0 || position.x > _levelData.Width)
            return null;
            
        if (position.y < 0 || position.y > _levelData.Height)
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
}
