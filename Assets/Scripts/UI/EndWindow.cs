using UI.Views;
using Zenject;

namespace UI
{
    public class EndWindow : AbstractWindow
    {
        public override EWindowType WindowType => EWindowType.End;
        
        private readonly LazyInject<EndWindowView> _view;
        
        public EndWindow(LazyInject<EndWindowView> view)
        {
            _view = view;
        }
        
        protected override void OnAssignView() => SetView(_view.Value);
    }
}