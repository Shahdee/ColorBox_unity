using Zenject;

namespace Level
{
    public class LevelInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<LevelView>().FromComponentInHierarchy().AsSingle();
            
            Container.BindInterfacesTo<LevelController>().AsSingle();
            Container.BindInterfacesTo<LevelViewController>().AsSingle();
            Container.BindInterfacesTo<LevelModel>().AsSingle();
            Container.BindInterfacesTo<LevelInputController>().AsSingle();
        }
    }
}