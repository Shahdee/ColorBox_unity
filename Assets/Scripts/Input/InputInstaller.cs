using Zenject;

namespace Input
{
    public class InputInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            
#if UNITY_STANDALONE || UNITY_EDITOR || UNITY_WEBGL
            Container.BindInterfacesTo<MouseController>().AsSingle();
#else
            Container.BindInterfacesTo<TouchController>().AsSingle();
#endif
        }
    }
}