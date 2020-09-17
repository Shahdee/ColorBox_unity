using System;
using Block;
using UnityEngine;

public class BlockView : MonoBehaviour
{
    public event Action<BlockView> OnBlockHid;
    public event Action<BlockView> OnBlockEaten;
    public IBlockModel BlockModel => _blockModel;
    
    [SerializeField] private SpriteRenderer _renderer;

    private static Color DefaltColor = Color.white;
    
    private const float ShowTime = 1f;
    private const float EatTime = 1f;

    private IBlockModel _blockModel;

    private bool _shown = false;
    private float _currentShowTime;
    private float _currentEatTime;
    private EBlockState _blockState;

    public void Initialize(IBlockModel model)
    {
        _blockModel = model;

        _blockModel.OnDestroy += BlockDestroy;
        _blockModel.OnEat += BlockEat;

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

    public bool TryShow(bool show)
    {
        if (_shown && show)
            return false;

        _shown = show;
        _renderer.color = _shown ? _blockModel.BlockColor : DefaltColor;
        _currentShowTime = _shown ? ShowTime : 0;

        _blockState = _shown ? EBlockState.Shown : EBlockState.Hidden;

        return true;
    }

    private void Update()
    {
        switch (_blockState)
        {
            case EBlockState.Shown:
                UpdateShowing();
                break;
            
            case EBlockState.Eaten:
                UpdateEating();
                break;
        }
    }

    private void UpdateShowing()
    {
        if (_currentShowTime > 0)
            _currentShowTime -= Time.deltaTime;
        else
        {
            TryShow(false);
            OnBlockHid?.Invoke(this);
        }
    }

    private void UpdateEating()
    {
        transform.localScale = Vector3.Lerp(Vector3.one, Vector3.zero, 1 - _currentEatTime / EatTime);
        
        if (_currentEatTime > 0)
            _currentEatTime -= Time.deltaTime;
        else
        {
            _blockState = EBlockState.Dead;
            OnBlockEaten?.Invoke(this);
            
            _blockModel.Destroy();
        }
    }

    private void BlockEat(IBlockModel model)
    {
        _blockState = EBlockState.Eaten;
        _currentEatTime = EatTime;
    }

    private void BlockDestroy(IBlockModel model)
    {
        _blockModel.OnDestroy -= BlockDestroy;
        OnBlockHid = null;
        OnBlockEaten = null;

        Destroy(gameObject);
    }
}
