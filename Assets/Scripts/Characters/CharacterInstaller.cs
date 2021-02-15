using UnityEngine;
using Zenject;

namespace Characters
{
    [CreateAssetMenu(fileName = "CharacterInstaller",  menuName = "SO/Installers/CharacterInstaller")]
    public class CharacterInstaller : ScriptableObjectInstaller
    {
        [SerializeField] private CharacterView _characterView;
        
        public override void InstallBindings()
        {
            Container.BindInstance(_characterView);
            Container.BindInterfacesTo<CharacterFactory>().AsSingle();
            Container.BindInterfacesTo<CharacterDatabase>().AsSingle();
        }
    }
}