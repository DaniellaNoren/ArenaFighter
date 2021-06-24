using ArenaFighter.Character;
using CharacterCreator;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArenaFighter.Items
{
    public interface IHittable
    {
        void GetHit(Weapon weapon);
        void AttemptToChangeStatus(Weapon weapon);
    }

    public class Weapon
    {
        public string Type { get; set; } 
        public int DamageBuff { get; set; }
        public string Description { get; set; }
        public int BaseDamage { get; }

        public CharacterStatus StatusChanger { get; set; }

        public Weapon() { }
        public Weapon(string Description, string Type, CharacterStatus StatusChanger = CharacterStatus.Normal,
            int BaseDamage = 1, int DamageBuff = 0)
        {
            this.Description = Description;
            this.Type = Type;
            this.StatusChanger = StatusChanger;
            this.BaseDamage = BaseDamage;
            this.DamageBuff = DamageBuff;
        }


        public int GetDamage()
        {
            return this.BaseDamage + this.DamageBuff;
        }

        public void Hit(IHittable hittable)
        {
            hittable.GetHit(this);
            hittable.AttemptToChangeStatus(this);
        }

        public override string ToString()
        {
            return $"{Description} {Type} | Damage: {BaseDamage}, Bonus: {DamageBuff}";
        }
    }

   
}
