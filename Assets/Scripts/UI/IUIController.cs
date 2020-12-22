namespace UI
{
    public interface IUIController
    {
        void OpenWindow(EWindowType windowType);
        void OpenWindowAndCloseOthers(EWindowType windowType);
    }
}