using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Views
{
    public class MainWindowView : AbstractWindowView
    {
        public event Action OnPlay;
        
        [SerializeField] private BoxView _box;

        private void Awake()
        {
            _box.OnClick += BoxClick;
        }

        private void BoxClick()
        {
            OnPlay?.Invoke();
        }
    }
}