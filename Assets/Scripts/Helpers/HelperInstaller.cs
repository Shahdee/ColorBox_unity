using Zenject;

namespace Helpers
{
    public class HelperInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<CoroutineManager>().AsSingle();
            Container.BindInterfacesTo<MonoManager>().AsSingle();
        }
    }
}