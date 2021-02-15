using UnityEngine;
using System;
using UnityEngine.EventSystems;

public class MobileInputController : AbstractInputController
{
    private DateTime _quickTouchCurrTime;
    private Vector2 _touchCurrPosition;
    private Touch _currentTouch;

    public override float GetHorizontalAxis()
    {
        if (!_enabled)
            return 0;

        else
        {
            throw new NotImplementedException();
        }

    }

    public override float GetVerticalAxis()
    {
        if (!_enabled)
            return 0;

        else
        {
            throw new NotImplementedException();
        }
    }

    protected override void UpdateInput()
    {
        if (_touchInProgress && EventSystem.current.IsPointerOverGameObject())
        {
            _touchInProgress = false;
            return;
        }

        if (UnityEngine.Input.touchCount > 0)
        {
            _currentTouch = UnityEngine.Input.GetTouch(0);

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