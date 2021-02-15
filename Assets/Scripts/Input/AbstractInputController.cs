using UnityEngine;
using System;
using Helpers;
using UnityEngine.EventSystems;

public abstract class AbstractInputController : IUpdatable, IInputController
{
    public event Action<Vector3> OnQuickTouch;
    public event Action<Vector2> OnAxisDown;
    public event Action<Vector2> OnAxisUp;
    public bool Enabled => _enabled;
    protected const float QuickTouchMaxTimeDelta = 0.5f;
    protected bool _enabled;
    protected bool _touchInProgress;

    public void SetEnabled(bool enabled)
    {
        _enabled = enabled;
    }
    
    public abstract float GetHorizontalAxis();
    
    public abstract float GetVerticalAxis();
    
    public void CustomUpdate(float deltaTime)
    {
        if (!_enabled)
            return;
        
        if (_touchInProgress && EventSystem.current.IsPointerOverGameObject())
        {
            _touchInProgress = false;
            return;
        }
        
        UpdateInput();
    }
    
    protected abstract void UpdateInput();

    protected void QuickTouch(Vector2 position)
    {
        OnQuickTouch?.Invoke(position);
    }

    protected void ArrowDown(Vector2 direction) => OnAxisDown?.Invoke(direction);
    
    protected void ArrowUp(Vector2 direction) => OnAxisUp?.Invoke(direction);
}
