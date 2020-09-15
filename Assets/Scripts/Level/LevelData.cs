using System;
using System.Collections.Generic;

public class LevelData
{
    public int Width => _width;
    public int Height => _height;

    private int _width;
    private int _height;
    private List<BlockData> _blockData;
    
    public LevelData(int width, int height, List<BlockData> blockData)
    {
        _width = width;
        _height = height;
        _blockData = blockData;
    }
}