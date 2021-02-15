namespace Characters
{
    public interface ICharacterDatabase
    {
        ICharacter Get(ECharacterType characterType);

        void Add(ICharacter character);
        void Remove(ICharacter character);
    }
}