using Zenject;

namespace Helpers
{
    public class HelperInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<CoroutineManager>().AsSingle();
            Container.BindInterfacesTo<MonoMediator>().AsSingle();
            Container.BindInterfacesTo<MonoRegisterMediator>().AsSingle();
        }
    }
}