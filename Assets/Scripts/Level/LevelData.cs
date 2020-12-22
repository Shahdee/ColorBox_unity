using System;
using System.Collections.Generic;

public class LevelData
{
    public int Width => _width;
    public int Height => _height;
    public int StartLevel => _startLevel;

    private int _width;
    private int _height;
    private int _startLevel;
    
    public LevelData(int width, int height, int startLevel)
    {
        _width = width;
        _height = height;
        _startLevel = startLevel;
    }
}