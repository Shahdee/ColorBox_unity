using System.Collections.Generic;


namespace Characters
{
    public class CharacterDatabase : ICharacterDatabase
    {

        private readonly Dictionary<ECharacterType, ICharacter> _allCharacters;

        public CharacterDatabase()
        {
            _allCharacters = new Dictionary<ECharacterType, ICharacter>();
        }
        
        public ICharacter Get(ECharacterType characterType)
        {
            if (_allCharacters.ContainsKey(characterType))
                return _allCharacters[characterType];

            return null;
        }

        public void Add(ICharacter character)
        {
            _allCharacters.Add(character.CharacterType, character);
        }

        public void Remove(ICharacter character)
        {
            if (_allCharacters.ContainsKey(character.CharacterType))
                _allCharacters.Remove(character.CharacterType);
        }
    }
}