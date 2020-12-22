using System;
using UI.Views;
using UnityEngine;

namespace UI
{
    public class AbstractWindowView : MonoBehaviour, IWindowView
    {
        public Transform ViewTransform => transform;

        [SerializeField] private Canvas _canvas;

        public void Show() => gameObject.SetActive(true);
        public void Hide() => gameObject.SetActive(false);
        public void SetOrder(int order) => _canvas.sortingOrder = order;

        private void OnEnable()
        {
            
        }

        private void OnDisable()
        {
            
        }
    }
}