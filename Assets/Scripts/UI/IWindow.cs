using System;
using UnityEngine;

namespace UI
{
    public interface IWindow
    {
        event Action<EWindowType> OnClose;
        EWindowType WindowType { get; }

        void SetParent(Transform transform);
        void SetOrder(int order);

        void Show();
        void Hide();
    }
}