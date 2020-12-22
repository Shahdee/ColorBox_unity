using System.Collections.Generic;
using System;
using UnityEngine;

public interface ILevelModel
{
    event Action<IBlockModel> OnBlockPut;
    event Action<IBlockModel> OnBlockDestroy;
    event Action OnAllBlocksDestroy;
    
    int Width { get; }
    int Height { get; }
    int CurrentLevel { get; }

    void Initialize(LevelData levelData);
    void PutBlock(IBlockModel blockModel);
    void DestroyAllBlocks();
    IBlockModel GetBlock(Vector2Int position);
    IBlockModel GetBlock(int x, int y);

    void AdvanceLevel();
}