using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockFactory : IBlockFactory
{
   private BlockView _prefab;
   
   public BlockFactory(BlockView prefab)
   {
      _prefab = prefab;
   }

   public BlockView CreateBlock(IBlockModel blockModel)
   {
      return null;
   }
   
}
