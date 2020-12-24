using System.Linq;
using UnityEngine;

namespace Block
{
    public class BlockSpriteDataProvider : IBlockSpriteDataProvider
    {
        private readonly BlockSpriteDatabaseAsset _databaseAsset;

        public BlockSpriteDataProvider(BlockSpriteDatabaseAsset databaseAsset)
        {
            _databaseAsset = databaseAsset;
        }
        
        public Sprite GetSprite(EBlockType blockType)
        {
            var blockSprite = _databaseAsset.BlockSprites.FirstOrDefault(bs => bs.BlockType == blockType);
            return blockSprite != null ? blockSprite.Sprite : null;
        }
    }
}