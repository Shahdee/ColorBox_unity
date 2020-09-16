using UnityEngine;

public interface ILevelViewController
{
    Vector2Int TransformPosition(Vector3 position);
    BlockView GetBlock(IBlockModel block);
}