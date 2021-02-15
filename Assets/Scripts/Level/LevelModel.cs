using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;

public class LevelModel : ILevelModel
{
    public event Action<IBlockModel> OnBlockPut;
    public event Action<IBlockModel> OnBlockDestroy;
    public event Action OnAllBlocksDestroy;
    
    public int CurrentLevel => _currentLevel;

    private HashSet<IBlockModel> _blockModels;
    private LevelData _levelData;
    private int _currentLevel; 

    public LevelModel()
    {
        
    }

    public void Initialize(LevelData levelData)
    {
        _levelData = levelData;
        _blockModels = new HashSet<IBlockModel>();
        _currentLevel = _levelData.StartLevel;
    }

    public void AdvanceLevel()
    {
        _currentLevel++;
    }

    public void PutBlock(IBlockModel block)
    {
        _blockModels.Add(block);

        block.OnDestroy += BlockDestroy;
        
        OnBlockPut?.Invoke(block);
    }

    public void DestroyAllBlocks()
    {
        if (_levelData == null)
            return;

        foreach (var block in _blockModels)
        {
            block.Destroy();
        }
        
        _blockModels.Clear();
    }

    public IBlockModel GetBlock(Vector2Int position)
    {
        var block = _blockModels.FirstOrDefault(b => b.Position.x == position.x && b.Position.y == position.y);
        return block;
    } 
    
    public IBlockModel GetBlock(int x, int y)
    {
        var block = _blockModels.FirstOrDefault(b => b.Position.x == x && b.Position.y == y);
        return block;
    }

    private void BlockDestroy(IBlockModel blockModel)
    {
        blockModel.OnDestroy -= BlockDestroy;

        _blockModels.Remove(blockModel);
        
        if (! _blockModels.Any())
            OnAllBlocksDestroy?.Invoke();
    }
}
