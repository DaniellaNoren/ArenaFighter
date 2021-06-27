using ArenaFighter;
using ArenaFighter.Items;
using System;

namespace CharacterCreator
{
    public class ConsoleNewMainCharacterInformationSupplier : ICharacterInformationSupplier
    {
        public string GetALastName()
        {
            Console.WriteLine("Last name?");
            return Console.ReadLine();
        }

        public int GetAnAge()
        {
            Console.WriteLine("Age?");
            return Int32.Parse(Console.ReadLine());
        }

        public string GetAName()
        {
            Console.WriteLine("First name?");
            return Console.ReadLine();
        }

        public Weapon[] GetWeapons()
        {
            Weapon[] weapons = new Weapon[] { GetDefaultWeapon() };

            return weapons;
        }

        public Weapon GetDefaultWeapon()
        {
            return new Weapon("hairy", "Fists");
        }

        public int GetHealth()
        {
            return 15;
        }

        public int GetSwiftness()
        {
            return 1;
        }
    }
}
