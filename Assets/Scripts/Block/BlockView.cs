using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockView : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _renderer;

    private static Color DefaltColor = Color.white;
    
    private const float ShowTime = 2f;

    private IBlockModel _blockModel;

    private bool _shown = false;
    private float _currentShowTime;

    public void Initialize(IBlockModel model)
    {
        _blockModel = model;

        _blockModel.OnDestroy += BlockDestroy;

        _renderer.color = DefaltColor;
    }

    public void SetParent(Transform parent)
    {
        transform.SetParent(parent);
    } 
    
    public void SetPosition(Vector3 position)
    {
        transform.position = position;
    }

    public void Show(bool show)
    {
        if (_shown && show)
            return;

        _shown = show;
        _renderer.color = _shown ? _blockModel.BlockColor : DefaltColor;
        _currentShowTime = ShowTime;
    }

    private void Update()
    {
        if (!_shown)
            return;

        if (_currentShowTime > 0)
            _currentShowTime -= Time.deltaTime;
        else
            Show(false);
    }

    private void BlockDestroy(IBlockModel model)
    {
        _blockModel.OnDestroy -= BlockDestroy;
        
        Destroy(gameObject);
    }
}
