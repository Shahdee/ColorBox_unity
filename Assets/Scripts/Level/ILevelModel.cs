using System.Collections.Generic;
using System;

public interface ILevelModel
{
    event Action<IBlockModel> OnBlockPut;
    
    void Initialize(LevelData levelData);

    void DestroyAllBlocks();
}