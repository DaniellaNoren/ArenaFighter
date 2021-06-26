
using ArenaFighter.Items;
using CharacterCreator;
using System;
using System.Text;

namespace ArenaFighter.Character
{

    public class PlayerCharacter : IHittable
    {

        private string firstName;
        public string FirstName { get { return firstName; } set { firstName = value; } }

        private string lastName;
        public string LastName { get { return lastName; } set { lastName = value; } }

        public string FullName { get { return FirstName + " " + LastName; } }

        private int level;
        public int Level {  get { return level;  } set { level += value; } }

        private int baseHealth;
        public int BaseHealth { get { return baseHealth; } set { baseHealth = value * level; } }

        private int age;
        public int Age
        {
            get { return age; }
            set
            {
                if (value <= 0 && value <= 140)
                    throw new Exception();
                age = value;
            }
        }

        private int health;
        public int Health { get { return health; } set { health = value; } }

       

        private int experiencePoints;

        public int ExperiencePoints {  get { return experiencePoints;  } set { experiencePoints = value; } }

        private int swiftness;
        public int Swiftness { get { return swiftness; } set { swiftness = value * level; } }

        private Weapon[] weapons;
        public Weapon[] Weapons { get { if (weapons == null) throw new Exception(); return weapons; } set { weapons = value; } }

        private Weapon drawnWeapon;
        public Weapon DrawnWeapon { 
            get { 
                if (weapons == null || weapons.Length == 0)
                {
                    weapons = new Weapon[] { RandomWeaponGenerator.GetRandomWeapon() };
                    return weapons[0];
                }
                return drawnWeapon;
            } 
            set { drawnWeapon = value; } 
        }

        public void AddWeapon(Weapon weapon)
        {
            Array.Resize(ref weapons, Weapons.Length + 1);
            weapons[^1] = weapon;

        }

        public void LevelUp(int levels)
        {
            this.level += levels;
        }

        public CharacterStatus CharacterStatus { get; set; }

        public PlayerCharacter(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.lastName = lastName;
        }
        public PlayerCharacter(string firstName, string lastName, int age, int health, int swiftness,
            Weapon[] Weapons, CharacterStatus characterStatus = CharacterStatus.Normal, int level = 1) : this(firstName, lastName)
        {
            this.Age = age;
            this.Health = health;
            this.Swiftness = swiftness;
            this.Weapons = Weapons;
            this.CharacterStatus = characterStatus;
            DrawWeapon(0);
            this.Level = level;
            this.BaseHealth = health;

        }

        public void DrawWeapon(int index)
        {
            this.DrawnWeapon = Weapons[index];
        }

        public override string ToString()
        {
            StringBuilder s = new StringBuilder();
            s.Append("Name=").Append(FirstName).Append(" ").Append(LastName)
                .Append(",Age=").Append(Age).Append(",Health=").Append(Health)
            .Append(",Swiftness=").Append(Swiftness).Append(",Weapons=");

            foreach (Weapon w in Weapons)
            {
                s.Append(w).Append("|");
            }

            return s.ToString();
        }

        public void TakeDamage(int damage)
        {
            this.Health -= damage;
        }

        public void Heal(int health)
        {
            this.Health += health;
        }

        public void GetHit(Weapon weapon)
        {
            TakeDamage(weapon.GetDamage());
        }

        public void AttemptToChangeStatus(Weapon weapon)
        {
            Console.WriteLine("Inside AttemptToChangeStatus");
        }
    }

}
