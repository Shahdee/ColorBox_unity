using Zenject;

namespace Input
{
    public class InputInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            
#if UNITY_STANDALONE || UNITY_EDITOR
            Container.BindInterfacesTo<MouseController>().AsSingle();
#else
            Container.BindInterfacesTo<TouchController>().AsSingle();
#endif
        }
    }
}