using Zenject;

namespace Game
{
    public class GameInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<GameController>().AsSingle().NonLazy();
            Container.BindInterfacesTo<GameModel>().AsSingle().NonLazy();
        }
    }
}