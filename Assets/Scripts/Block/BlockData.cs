using UnityEngine;

public class BlockData
{
    private Color _color;
    private Vector2Int _position;
    
    public BlockData(Color color, Vector2Int position)
    {
        _color = color;
        _position = position;
    }
}
