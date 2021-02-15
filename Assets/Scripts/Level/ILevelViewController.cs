using UnityEngine;

public interface ILevelViewController
{
    Vector2Int TransformPosition(Vector3 position);
    Vector3 TransformPosition(Vector2Int position);
    BlockView GetBlock(IBlockModel block);
}