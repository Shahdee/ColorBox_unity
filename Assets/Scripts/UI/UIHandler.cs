using System;

namespace UI
{
    public class UIHandler : IUIHandler, IDisposable
    {
        private readonly IGameController _gameController;
        private readonly IMainWindow _mainWindow;
        private readonly IUIController _uiController;

        public UIHandler(IGameController gameController, 
                        IMainWindow mainWindow,
                        IUIController uiController)
        {
            _gameController = gameController;
            _mainWindow = mainWindow;
            _uiController = uiController;

            _gameController.OnGameStateChange += GameStateChange;
            _mainWindow.OnGamePlay += PlayGame;
        }

        private void PlayGame()
        {
            _gameController.StartGame();
        }

        private void GameStateChange(EGameState state)
        {
            switch (state)
            {
                case EGameState.Start:
                    _uiController.OpenWindowAndCloseOthers(EWindowType.Main);
                    break;
            
                case EGameState.Play:
                    _uiController.OpenWindowAndCloseOthers(EWindowType.Level);
                    break;
            
                case EGameState.End:
                    _uiController.OpenWindowAndCloseOthers(EWindowType.End);
                    break;
            }
        }

        public void Dispose()
        {
            _gameController.OnGameStateChange -= GameStateChange;
            _mainWindow.OnGamePlay -= PlayGame;
        }
    }
}