using System;
using Block;
using UnityEngine;

public interface IBlockModel
{
    event Action<IBlockModel> OnDestroy;
    EBlockType BlockType { get; }
    
    Color BlockColor { get; }
    Vector2Int Position { get; }
    void Destroy();
}