using UnityEngine;
using System;
using UnityEngine.EventSystems;


public class PCInputController : AbstractInputController
{
    private const string Vertical = "Vertical";
    private const string Horizontal = "Horizontal";
    
    private DateTime _quickTouchCurrTime;
    private Vector3 _touchCurrPosition;

    private bool _horizontalInProgress;
    private bool _verticalInProgress;
    private Vector2 _arrowDirection = new Vector2(); 

    public override float GetHorizontalAxis()
    {
        if (!_enabled)
            return 0;
        
        return UnityEngine.Input.GetAxis("Horizontal");

    }

    public override float GetVerticalAxis()
    {
        if (!_enabled)
            return 0;
        
        return UnityEngine.Input.GetAxis("Vertical");
    }

    protected override void UpdateInput()
    {
        UpdateKeyboard();
        
        UpdateMouse();
    }

    private void UpdateMouse()
    {
        if (_touchInProgress && EventSystem.current.IsPointerOverGameObject())
        {
            _touchInProgress = false;
            return;
        }

        if (UnityEngine.Input.GetMouseButtonDown(0))
        {
            _quickTouchCurrTime = DateTime.Now;
            _touchInProgress = true;
        }

        if (! _touchInProgress) return;

        if (UnityEngine.Input.GetMouseButton(0))
        {
        }


        if (UnityEngine.Input.GetMouseButtonUp(0))
        {
            if ((DateTime.Now - _quickTouchCurrTime).Seconds < QuickTouchMaxTimeDelta)
            {
                _touchInProgress = false;
                QuickTouch(UnityEngine.Input.mousePosition);
            }
        }
    }

    private void UpdateKeyboard()
    {
        if (UnityEngine.Input.GetButton("Horizontal"))
        {
            if (!_horizontalInProgress)
            {
                _horizontalInProgress = true;
                Debug.Log("Horizontal down");

                _arrowDirection.x = UnityEngine.Input.GetAxis("Horizontal");
                
                ArrowDown(_arrowDirection);
            }
        }
        else
        {
            if (_horizontalInProgress)
            {
                Debug.Log("Horizontal up");
                _horizontalInProgress = false;

                
                ArrowUp(_arrowDirection);
            }
        }
    }
}