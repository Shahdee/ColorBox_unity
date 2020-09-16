using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.EventSystems;

public abstract class AbstractInputController : IInputController
{
    public event Action<Vector3> OnQuickTouch;
    public bool Enabled => _enabled;
    protected const float QuickTouchMaxTimeDelta = 0.5f;
    protected bool _enabled;
    protected bool _touchInProgress;

    public void Tick()
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

    public void SetEnabled(bool enabled)
    {
        _enabled = enabled;
    }

    protected abstract void UpdateInput();

    protected void QuickTouch(Vector2 position)
    {
        OnQuickTouch?.Invoke(position);
    }
}
