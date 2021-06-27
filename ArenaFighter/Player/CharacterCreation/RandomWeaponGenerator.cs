using ArenaFighter;
using ArenaFighter.Items;
using ArenaFighter.Utensils;
using Lexicon.CSharp.InfoGenerator;
using System;

namespace CharacterCreator
{
    public class RandomWeaponGenerator : Random
    {

        private static InfoGenerator InfoGenerator = InformationGeneratorWrapper.GetInstance();
        private static Random Random = RandomWrapper.GetRandomInstance();
        public static Weapon GetRandomWeapon()
        {
            string Type = InfoGenerator.NextItem();
            string Description = InfoGenerator.NextPersonality();
            int BaseDamage = Random.Next(1, 6);
            int DamageBuff = Random.Next(0, 4);

            return new Weapon(Description, Type, BaseDamage: BaseDamage, DamageBuff: DamageBuff);
        }

     
    }
}
