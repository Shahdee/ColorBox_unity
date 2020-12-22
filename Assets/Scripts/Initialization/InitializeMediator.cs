using System;
using System.Collections.Generic;
using UnityEngine;

namespace Initialization
{
    public class InitializeMediator : Zenject.IInitializable, IInitializeMediator, IDisposable
    {
        public event Action OnDone;
        
        private readonly List<IInitializable> _initializables;

        private int _waiting;

        public InitializeMediator(List<IInitializable> initializables)
        {
            _initializables = initializables;

            foreach (var toInit in _initializables)
                toInit.OnDone += InitDone;
        }
        
        public void Initialize()
        {
            _waiting = _initializables.Count;
            
            foreach (var toInit in _initializables)
                toInit.Initialize();
        }

        private void InitDone()
        {
            _waiting--;

            if (_waiting == 0)
                OnDone?.Invoke();
        }

        public void Dispose()
        {
            foreach (var toInit in _initializables)
                toInit.OnDone -= InitDone;
        }
    }
}