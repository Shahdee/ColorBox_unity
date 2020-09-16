using UnityEngine;
using System;

public class BlockModel : IBlockModel
{
      public event Action<IBlockModel> OnDestroy;
    
      public Color BlockColor => _color;
      public Vector2Int Position => _position;

      private Color _color;
      private Vector2Int _position;
      private Vector2Int _siblingPosition; // later we can compare colors directly or pictures
      
      public BlockModel(Color color,
                        Vector2Int position,
                        Vector2Int siblingPosition)
      {
         _color = color;
         _position = position;
         _siblingPosition = siblingPosition;
      }

      public void Destroy()
      {
         OnDestroy?.Invoke(this);
         OnDestroy = null;
      }
}
