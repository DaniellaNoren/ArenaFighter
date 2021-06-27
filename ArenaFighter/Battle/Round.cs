using ArenaFighter.Character;

namespace ArenaFighter
{
    public class Round
    {
        private readonly PlayerCharacter p1;
        private readonly PlayerCharacter p2;
        public Round(PlayerCharacter p1, PlayerCharacter p2)
        {
            this.p1 = p1;
            this.p2 = p2;
        }
        public bool StartRound()
        {

            PlayerHittingPlayer(p1, p2);

            if (!Survived(p2))
                return false;

            PlayerHittingPlayer(p2, p1);

            if (!Survived(p1))
                return false;

            return true;
        }

        public void PlayerHittingPlayer(PlayerCharacter hitter, PlayerCharacter toHit)
        {
            hitter.DrawnWeapon.Hit(toHit);
            System.Console.WriteLine($"{hitter.FirstName} hit {toHit.FirstName} with their {hitter.DrawnWeapon} for {hitter.DrawnWeapon.GetDamage()} damage");

        }

        public bool Survived(PlayerCharacter player)
        {
            return player.Health > 0;
        }

    }
}
