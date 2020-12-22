using System;

namespace Initialization
{
    public interface IInitializable
    {
        event Action OnDone;
        void Initialize();
    }
}