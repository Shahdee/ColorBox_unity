using System;
using UnityEngine;

public interface IBlockModel
{
    event Action<IBlockModel> OnDestroy;
    
    Color BlockColor { get; }
    Vector2Int Position { get; }
    void Destroy();
}