


using System;

public class LevelViewController : ILevelViewController, IDisposable
{
    private readonly ILevelModel _levelModel;

    public LevelViewController(ILevelModel levelModel)
    {
        _levelModel = levelModel;

        _levelModel.OnBlockPut += BlockPut;
    }

    private void BlockPut(IBlockModel blockModel)
    {
        
    }

    public void Dispose()
    {
        _levelModel.OnBlockPut -= BlockPut;
    }
}