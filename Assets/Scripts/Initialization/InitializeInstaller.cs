using Zenject;

namespace Initialization
{
    public class InitializeInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<InitializeMediator>().AsSingle();
        }
    }
}