using UI.Views;
using UnityEngine;
using Zenject;

namespace UI
{
    [CreateAssetMenu(fileName = "UIInstaller",  menuName = "SO/Installers/UIInstaller")]
    public class UIInstaller : ScriptableObjectInstaller
    {
        [SerializeField] private MainWindowView _mainView;
        [SerializeField] private EndWindowView _endWindowView;
        [SerializeField] private LevelWindowView _levelWindowView;
        
        public override void InstallBindings()
        {
            Container.Bind<MainWindowView>().FromComponentInNewPrefab(_mainView).AsSingle();
            Container.Bind<LevelWindowView>().FromComponentInNewPrefab(_levelWindowView).AsSingle();
            Container.Bind<EndWindowView>().FromComponentInNewPrefab(_endWindowView).AsSingle();
            
            Container.BindInterfacesTo<UIController>().AsSingle();
            Container.BindInterfacesTo<UIHandler>().AsSingle();
            
            Container.BindInterfacesTo<MainWindow>().AsSingle();
            Container.BindInterfacesTo<LevelWindow>().AsSingle();
            Container.BindInterfacesTo<EndWindow>().AsSingle();
        }
    }
}