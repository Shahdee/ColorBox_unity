using System.Collections;
using System.Collections.Generic;
using Block;
using UnityEngine;

public interface IBlockModelFactory
{
    IBlockModel CreateBlock(Vector2Int position);
}
