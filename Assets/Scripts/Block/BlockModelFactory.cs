using System.Collections;
using System.Collections.Generic;
using Block;
using UnityEngine;

public class BlockModelFactory : IBlockModelFactory
{
   public BlockModelFactory()
   {
      
   }

   public IBlockModel CreateBlock(Vector2Int position)
   {
      return new BlockModel(position);
   }
}
