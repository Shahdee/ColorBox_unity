namespace Characters
{
    public interface ICharacterFactory
    {
        ICharacter CreateCharacter(ECharacterType characterType);
    }
}