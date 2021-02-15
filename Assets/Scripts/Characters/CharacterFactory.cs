using Helpers;
using UnityEngine;

// TODO get characterType prefabs from asset database 

namespace Characters
{
    public class CharacterFactory : ICharacterFactory
    {
        private readonly IMonoRegisterMediator _monoRegisterMediator;
        private readonly CharacterView _characterView;

        private Transform _characterParent;

        public CharacterFactory(IMonoRegisterMediator monoRegisterMediator,
                                CharacterView characterView)
        {
            _monoRegisterMediator = monoRegisterMediator;
            _characterView = characterView;
            
            _characterParent = new GameObject().transform;
            _characterParent.name = "CharacterParent";
        }
        
        public ICharacter CreateCharacter(ECharacterType characterType)
        {
            var view = Object.Instantiate(_characterView);
            view.SetParent(_characterParent);
            var character = new CharacterController(characterType, view);
            
            _monoRegisterMediator.Register(character);

            return character;
        }
    }
}