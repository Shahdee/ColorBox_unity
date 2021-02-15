using System.Collections.Generic;
using UnityEngine;

namespace Helpers
{
    public class MonoMediator : Zenject.IInitializable
    {
        private readonly List<IUpdatable> _updatables;
        
        private MonoManagerView _view;
        
        
        public MonoMediator(List<IUpdatable> updatables)
        {
            _updatables = updatables;
        }

        public void Initialize()
        {
            var gameObject = new GameObject("MonoManager");
            _view = gameObject.AddComponent<MonoManagerView>();

            _view.OnUpdate += PerformUpdate;
        }

        private void PerformUpdate(float deltaTime)
        {
            foreach (var updatable in _updatables)
            {
                updatable.CustomUpdate(deltaTime);
            }
        }
    }
}