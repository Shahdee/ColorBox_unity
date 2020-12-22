using System;

namespace UI
{
    public interface IMainWindow
    {
        event Action<int> OnGamePlay;
    }
}