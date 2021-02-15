using System;
using UI.Views;
using Zenject;

namespace UI
{
    public class MainWindow : AbstractWindow, IMainWindow, IDisposable
    {
        public event Action OnGamePlay;
        public override EWindowType WindowType => EWindowType.Main;
    
        private readonly LazyInject<MainWindowView> _view;

        public MainWindow(LazyInject<MainWindowView> view)
        {
            _view = view;
        }

        protected override void OnAssignView() => SetView(_view.Value);

        protected override void OnAfterShow()
        {
            // ev + 

            _view.Value.OnPlay += StartGame;
        }

        protected override void OnAfterHide()
        {
            // ev -
        
            _view.Value.OnPlay -= StartGame;
        }

        private void StartGame()
        {
            OnGamePlay?.Invoke();
        }

        public void Dispose()
        {
            if (!_view.Value) return;
        
            _view.Value.OnPlay -= StartGame;
        }
    }
}