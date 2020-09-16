using UnityEngine;
using System;
using UnityEngine.EventSystems;

public class MouseController : AbstractInputController 
{
    private DateTime _quickTouchCurrTime;
    private Vector3 _touchCurrPosition;

    protected override void UpdateInput()
    {
        if (_touchInProgress && EventSystem.current.IsPointerOverGameObject())
        {
            _touchInProgress = false;
            return;
        }

        if (Input.GetMouseButtonDown(0))
        {
            _quickTouchCurrTime = DateTime.Now;
            _touchInProgress = true;
        }

        if (! _touchInProgress) return;

        if (Input.GetMouseButton(0))
        {
        }


        if (Input.GetMouseButtonUp(0))
        {
            if ((DateTime.Now - _quickTouchCurrTime).Seconds < QuickTouchMaxTimeDelta)
            {
                _touchInProgress = false;
                QuickTouch(Input.mousePosition);
            }
        }
    }
}