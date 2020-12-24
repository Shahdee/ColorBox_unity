using System.Collections;
using System.Collections.Generic;
using Block;
using UnityEngine;

public interface IBlockModelFactory
{
    IBlockModel CreateBlock(Color color, Vector2Int position, Vector2Int siblingPosition);
    IBlockModel CreateBlock(EBlockType blockType, Vector2Int position, Vector2Int siblingPosition);

}
