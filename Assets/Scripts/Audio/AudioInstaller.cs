using UnityEngine;
using Zenject;

namespace Audio
{
    public class AudioInstaller : MonoInstaller
    {
        [SerializeField] private AudioDatabase _audioDatabase;

        public override void InstallBindings()
        {
            Container.Bind<AudioDatabase>().FromComponentInNewPrefab(_audioDatabase).AsSingle();

            Container.BindInterfacesTo<AudioController>().AsSingle();
        }
    }
}