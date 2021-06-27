using ArenaFighter.Items;
using ArenaFighter.Utensils;
using Lexicon.CSharp.InfoGenerator;
using System;

namespace CharacterCreator
{
    public class RandomCharacterInformationSupplier : ICharacterInformationSupplier
    {
        private readonly InfoGenerator InfoGenerator = InformationGeneratorWrapper.GetInstance();
        private readonly Random Random = RandomWrapper.GetRandomInstance();
        public string GetALastName()
        {
            return InfoGenerator.NextLastName();
        }

        public int GetAnAge()
        {
            return Random.Next(20, 101);
        }

        public string GetAName()
        {
            return InfoGenerator.NextFirstName();
        }

        public int GetHealth()
        {
            return Random.Next(5, 16);
        }

        public int GetSwiftness()
        {
            return Random.Next(0, 6);

        }

        public Weapon[] GetWeapons()
        {
            Weapon[] weapons = 
                new Weapon[] { RandomWeaponGenerator.GetRandomWeapon() };

            return weapons;
        }
    }
}
