using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBlockFactory
{
    BlockView CreateBlock(IBlockModel blockModel);

}
