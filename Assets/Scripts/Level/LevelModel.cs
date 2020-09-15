using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LevelModel : ILevelModel
{
    public event Action<IBlockModel> OnBlockPut;
    public event Action<IBlockModel> OnBlockDestroy;
    
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
        
        
        OnBlockPut?.Invoke(block);
    }

    public void DestroyAllBlocks()
    {
        // TOOD 
        // destroy all models 
        
        // OnBlockDestroy
    }


   
}
