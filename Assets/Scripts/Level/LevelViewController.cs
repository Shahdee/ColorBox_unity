using System;
using System.Collections.Generic;
using UnityEngine;

public class LevelViewController : ILevelViewController, IDisposable
{
    private readonly ILevelModel _levelModel;
    private readonly LevelView _levelView;
    private readonly IBlockViewFactory _blockViewFactory;
    
    private const int BlockWidth = 1;
    private const int BlockHeight = 1;

    private Dictionary<IBlockModel, BlockView> _blocks;
    
    public LevelViewController(LevelView levelView,
                                IBlockViewFactory blockViewFactory,
                                ILevelModel levelModel)
    {
        _levelModel = levelModel;
        _levelView = levelView;
        _blockViewFactory = blockViewFactory;
        
        _blocks = new Dictionary<IBlockModel, BlockView>();

        _levelModel.OnBlockPut += BlockPut;
        _levelModel.OnBlockDestroy += BlockDestroy;
    }


    
    public Vector2Int TransformPosition(Vector3 worldPosition)
    {
        var localPosition = _levelView.BlockParent.InverseTransformPoint(worldPosition);

        return new Vector2Int()
        {
            x = Mathf.RoundToInt(localPosition.x / BlockWidth),
            y = Mathf.RoundToInt(localPosition.y / BlockHeight)
        };
    }
    
    public Vector3 TransformPosition(Vector2Int position)
    {
        return new Vector3()
        {
            x = position.x * BlockWidth + BlockWidth/2,
            y = position.y * BlockHeight + BlockHeight/2,
        };
    }

    public BlockView GetBlock(IBlockModel block)
    {
        if (_blocks.ContainsKey(block))
            return _blocks[block];

        return null;
    }

    private void BlockPut(IBlockModel blockModel)
    {
        var blockView = _blockViewFactory.CreateBlock(blockModel);
        
        _blocks[blockModel] = blockView;
        blockView.SetParent(_levelView.BlockParent);

        var position = _levelView.BlockParent.TransformPoint(TransformPosition(blockModel.Position));
        
        blockView.SetPosition(position);
    } 
    
    private void BlockDestroy(IBlockModel blockModel)
    {
        if (_blocks.ContainsKey(blockModel))
        {
            var blockView = _blocks[blockModel];
            _blocks.Remove(blockModel);
        }
    }

    public void Dispose()
    {
        _levelModel.OnBlockPut -= BlockPut;
        _levelModel.OnBlockDestroy -= BlockDestroy;
    }
}