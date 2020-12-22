using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Views
{
    public class BoxView : MonoBehaviour
    {
        public event Action OnClick;
        
        [SerializeField] private TextMeshProUGUI _size;
        [SerializeField] private Button _button;


        private void Awake()
        {
            _button.onClick.AddListener(()=>OnClick?.Invoke());
        }
    }
}