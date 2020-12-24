
using Block;
using UnityEngine;

public class BlockViewFactory : IBlockViewFactory
{
    private readonly BlockView _prefab;
    private readonly IBlockSpriteDataProvider _dataProvider;

    public BlockViewFactory(BlockView prefab, IBlockSpriteDataProvider dataProvider)
    {
        _prefab = prefab;
        _dataProvider = dataProvider;
    }

    public BlockView CreateBlock(IBlockModel blockModel)
    {
        var block = Object.Instantiate(_prefab);

        var objectSprite = _dataProvider.GetSprite(blockModel.BlockType);
        
        block.Initialize(blockModel, objectSprite);
        
        return block;
    }
}