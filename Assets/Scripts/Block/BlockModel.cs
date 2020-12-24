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
      public Vector2Int SiblingPosition => _siblingPosition;

      private Color _color;
      private Vector2Int _position;
      
      private Vector2Int _siblingPosition; // later we can compare colors directly or pictures

      private EBlockType _blockType;
      
      public BlockModel(Color color,
                        Vector2Int position,
                        Vector2Int siblingPosition)
      {
         _color = color;
         _position = position;
         _siblingPosition = siblingPosition;
      } 
      
      public BlockModel(EBlockType blockType,
                        Vector2Int position,
                        Vector2Int siblingPosition)
      { 
        _blockType = blockType;
        _position = position;
        _siblingPosition = siblingPosition;
      }

      public void Eat()
      {
          OnEat?.Invoke(this);
      }

      public void Destroy()
      {
         OnDestroy?.Invoke(this);
         OnDestroy = null;
      }
}
