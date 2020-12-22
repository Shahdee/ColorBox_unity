using System;
using System.Collections.Generic;
using System.Linq;
using Initialization;
using UnityEngine;

namespace UI
{
    public class UIController : IInitializable, IUIController, IDisposable
    {
        public event Action OnDone;
        
        private Stack<IWindow> _stackedWindows;
        private List<IWindow> _allWindows;
        private Transform _windowParent;
        
        public UIController(List<IWindow> allWindows)
        {
            _allWindows = allWindows;
            _stackedWindows = new Stack<IWindow>();
        }

        public void Initialize()
        {
            _windowParent = new GameObject().transform;
            _windowParent.name = "windowParent";

            foreach (var window in _allWindows)
                window.OnClose += WindowClosed;
            
            OnDone?.Invoke();
        }

        public void OpenWindowAndCloseOthers(EWindowType windowType)
        {
            // Debug.LogError("ow and close others " + windowType);
            
            while (_stackedWindows.Count > 0)
            {
                var window = _stackedWindows.Peek();
                window.Hide();
            }
            OpenWindow(windowType);
        }
        
        public void OpenWindow(EWindowType windowType)
        {
            // Debug.LogError("ow " + windowType);
            
            var window = _allWindows.FirstOrDefault(w => w.WindowType == windowType);
            if (window != null)
            {
                _stackedWindows.Push(window);
                var order = _stackedWindows.Count;
                window.SetParent(_windowParent);
                window.SetOrder(order);
                window.Show();
            }
        }
        
        public void HideWindow(EWindowType windowType)
        {
            var window = _allWindows.FirstOrDefault(w => w.WindowType == windowType);
            if (window != null)
            {
                window.Hide();
            }
        }

        private void WindowClosed(EWindowType windowType)
        {
            var window = _stackedWindows.Peek();
            if (window.WindowType == windowType)
            {
                _stackedWindows.Pop();
            }
            else
                Debug.LogError("closed window is not on top " + windowType);
        }
        
        public void Dispose()
        {
            foreach (var window in _allWindows)
                window.OnClose -= WindowClosed;
        }
    }
}
