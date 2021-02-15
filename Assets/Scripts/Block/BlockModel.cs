using UnityEngine;
using System;
using Block;

public class BlockModel : IBlockModel
{
      public event Action<IBlockModel> OnDestroy;
      public event Action<IBlockModel> OnEat;

      public EBlockType BlockType => _blockType;
      public Color BlockColor => _color;
      public Vector2Int Position => _position;
      private Color _color;
      private Vector2Int _position;
      
      private EBlockType _blockType;
      
      public BlockModel(Vector2Int position)
      {
         _position = position;
      } 
      
      public BlockModel(EBlockType blockType,
                        Vector2Int position)
      { 
        _blockType = blockType;
        _position = position;
      }

      public void Destroy()
      {
         OnDestroy?.Invoke(this);
         OnDestroy = null;
      }
}
