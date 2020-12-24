using System.Collections.Generic;
using UnityEngine;

namespace Block
{
    [CreateAssetMenu(menuName = "SO/Database/BlockSpriteDatabase", fileName = "BlockSpriteDatabase")]
    public class BlockSpriteDatabaseAsset : ScriptableObject
    {
        public IReadOnlyList<BlockSpriteData> BlockSprites => _blockSprites;
        
        [SerializeField] private List<BlockSpriteData> _blockSprites;
    }
}
