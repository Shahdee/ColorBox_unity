using System;
using Block;
using UnityEngine;

public interface IBlockModel
{
    event Action<IBlockModel> OnDestroy;
    event Action<IBlockModel> OnEat;
    
    EBlockType BlockType { get; }
    
    Color BlockColor { get; }
    Vector2Int Position { get; }
    Vector2Int SiblingPosition { get; }
    void Eat();
    void Destroy();
}