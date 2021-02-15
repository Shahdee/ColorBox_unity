using System;
using UnityEngine;

public class BlockView : MonoBehaviour
{
    public event Action<BlockView> OnBlockHid;
    public event Action<BlockView> OnBlockEaten;
    public IBlockModel BlockModel => _blockModel;
    
    [SerializeField] private SpriteRenderer _blockSprite;

    private static Color DefaltColor = Color.white;
    
    private const float EatTime = 1f;

    private IBlockModel _blockModel;

    private bool _shown = false;

    public void Initialize(IBlockModel model, Sprite objectSprite)
    {
        _blockModel = model;

        _blockModel.OnDestroy += BlockDestroy;

        _blockSprite.color = DefaltColor;
    }

    public void SetParent(Transform parent)
    {
        transform.SetParent(parent);
    } 
    
    public void SetPosition(Vector3 position)
    {
        transform.position = position;
    }

    private void Update()
    {
       
    }

    
    private void BlockDestroy(IBlockModel model)
    {
        _blockModel.OnDestroy -= BlockDestroy;
        OnBlockHid = null;
        OnBlockEaten = null;

        Destroy(gameObject);
    }
}
