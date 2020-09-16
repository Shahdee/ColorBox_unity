using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockModelFactory : IBlockModelFactory
{
   public BlockModelFactory()
   {
      
   }

   public IBlockModel CreateBlock(Color color, Vector2Int position, Vector2Int siblingPosition)
   {
      return new BlockModel(color, position, siblingPosition);
   }
   
}
