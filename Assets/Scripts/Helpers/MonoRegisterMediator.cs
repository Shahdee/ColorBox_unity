using System.Collections.Generic;

namespace Helpers
{
    public class MonoRegisterMediator : IUpdatable, IMonoRegisterMediator
    {
        private readonly HashSet<IUpdatable> _updatables;


        public MonoRegisterMediator()
        {
            _updatables = new HashSet<IUpdatable>();
        }

        public void Register(IUpdatable updatable)
        {
            if (!_updatables.Contains(updatable))
                _updatables.Add(updatable);
        }

        public void CustomUpdate(float deltaTime)
        {
            foreach (var updatable in _updatables)
            {
                updatable.CustomUpdate(deltaTime);
            }
        }
    }
}