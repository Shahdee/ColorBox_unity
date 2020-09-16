using System;
using System.Collections.Generic;

public class LevelData
{
    public int Width => _width;
    public int Height => _height;

    private int _width;
    private int _height;
    
    public LevelData(int width, int height)
    {
        _width = width;
        _height = height;
    }
}