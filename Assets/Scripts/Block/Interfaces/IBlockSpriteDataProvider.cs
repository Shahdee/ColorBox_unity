using UnityEngine;

namespace Block
{
    public interface IBlockSpriteDataProvider
    {
        Sprite GetSprite(EBlockType blockType);
    }
}