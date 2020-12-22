using System;

namespace Initialization
{
    public interface IInitializeMediator
    {
        event Action OnDone;
    }
}