using System;
using UnityEngine;

namespace UI
{
    public abstract class AbstractWindow : IWindow
    {
        public event Action<EWindowType> OnClose;
        
        public abstract EWindowType WindowType { get; }

        
        private IWindowView _view;
        private Transform _parent;
        private int _order;
        
        protected AbstractWindow()
        {
        }

        protected void SetView(IWindowView view)
        {
            _view = view;
            
            _view.SetOrder(_order);
            
            if (_parent != null)
                _view.ViewTransform.SetParent(_parent);
        }

        public void SetParent(Transform transform)
        {
            if (_view != null)
                _view.ViewTransform.SetParent(transform);
            else
                _parent = transform;
        }

        public void SetOrder(int order)
        {
            if (_view != null)
                _view.SetOrder(order);
            
            _order = order;
        }

        public void Show()
        {
            OnAssignView();
            OnBeforeShow();
            _view.Show();
            OnAfterShow();
        }

        protected abstract void OnAssignView();
        protected virtual void OnBeforeShow(){}
        protected virtual void OnAfterShow(){}
        protected virtual void OnBeforeHide(){}
        protected virtual void OnAfterHide(){}
     
        public void Hide()
        {
            OnBeforeHide();
            _view.Hide();
            OnAfterHide();

            OnClose?.Invoke(WindowType);
        }
    }
}