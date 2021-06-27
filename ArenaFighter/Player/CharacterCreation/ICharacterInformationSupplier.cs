using ArenaFighter.Items;

namespace CharacterCreator
{
    public interface ICharacterInformationSupplier
    {
        string GetAName();
        string GetALastName();
        int GetAnAge();

        int GetHealth();
        int GetSwiftness();
        Weapon[] GetWeapons();
    }
}
