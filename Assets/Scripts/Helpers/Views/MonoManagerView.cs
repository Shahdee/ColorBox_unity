using System;
using UnityEngine;

namespace Helpers
{
    public class MonoManagerView : MonoBehaviour
    {
        public event Action<float> OnUpdate;
        
        private void Update()
        {
            OnUpdate?.Invoke(Time.deltaTime);
        }
    }
}