using UnityEngine;
using System;
using UnityEngine.EventSystems;

public class TouchController : AbstractInputController
{
    private DateTime _quickTouchCurrTime;
    private Vector2 _touchCurrPosition;
    private Touch _currentTouch;

    protected override void UpdateInput()
    {
        if (_touchInProgress && EventSystem.current.IsPointerOverGameObject())
        {
            _touchInProgress = false;
            return;
        }

        if (Input.touchCount > 0)
        {
            _currentTouch = Input.GetTouch(0);

            switch (_currentTouch.phase)
            {
                case TouchPhase.Began:
                    _quickTouchCurrTime = DateTime.Now;
                    _touchInProgress = true;
                    break;

                case TouchPhase.Moved:
                   
                    break;

                case TouchPhase.Ended:
                    if (_touchInProgress && (DateTime.Now - _quickTouchCurrTime).Seconds < QuickTouchMaxTimeDelta)
                    {
                        _touchInProgress = false;
                        QuickTouch(_currentTouch.position);
                    }
                    break;
            }
        }
    }
}