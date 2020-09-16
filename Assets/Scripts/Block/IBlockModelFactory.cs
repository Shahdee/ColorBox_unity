using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBlockModelFactory
{
    IBlockModel CreateBlock(Color color, Vector2Int position, Vector2Int siblingPosition);

}
