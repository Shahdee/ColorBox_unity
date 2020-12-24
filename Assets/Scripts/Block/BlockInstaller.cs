using UnityEngine;
using Zenject;

namespace Block
{
    [CreateAssetMenu(fileName = "BlockInstaller",  menuName = "SO/Installers/BlockInstaller")]
    public class BlockInstaller : ScriptableObjectInstaller
    {
        [SerializeField] private BlockView _blockView;
        [SerializeField] private BlockSpriteDatabaseAsset _blockSpriteDatabase;
        
        public override void InstallBindings()
        {
            Container.BindInstance(_blockView);
            Container.BindInstance(_blockSpriteDatabase);
            
            Container.BindInterfacesTo<BlockModelFactory>().AsSingle();
            Container.BindInterfacesTo<BlockViewFactory>().AsSingle();
            Container.BindInterfacesTo<BlockSpriteDataProvider>().AsSingle();
        }
    }
}