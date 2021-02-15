using UnityEngine;
using System;

public interface IInputController
{
    event Action<Vector3> OnQuickTouch;
    event Action<Vector2> OnAxisDown;
    event Action<Vector2> OnAxisUp;
    
    bool Enabled {get;}
    void SetEnabled(bool enabled);

    float GetHorizontalAxis();
    float GetVerticalAxis();
}