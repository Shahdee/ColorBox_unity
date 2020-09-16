
using UnityEngine;

public class BlockViewFactory : IBlockViewFactory
{
    private BlockView _prefab;
    
    public BlockViewFactory(BlockView prefab)
    {
        _prefab = prefab;
    }

    public BlockView CreateBlock(IBlockModel blockModel)
    {
        var block = Object.Instantiate(_prefab);
        block.Initialize(blockModel);
        
        return block;
    }
}