
using ArenaFighter.Character;
using System;

namespace ArenaFighter
{
    public class Battle
    {
       
        private readonly PlayerCharacter Enemy;
        private readonly PlayerCharacter Main;

        private readonly Round Round;


        public Battle(PlayerCharacter main, PlayerCharacter enemy)
        {
            this.Main = main;
            this.Enemy = enemy;
            this.Round = new Round(main, enemy);
        }


        public BattleResult StartBattle()
        {
            bool roundOver;

            Console.WriteLine($"You met enemy {Enemy.FullName} looking all angry with their {Enemy.DrawnWeapon}");

            do
            {

                Menu();
                Int32.TryParse(Console.ReadLine(), out int choice);

                roundOver = Choose(choice);

            } while (!roundOver);

            bool playerWon = Main.Health > 0;
            PlayerCharacter winningPlayer = playerWon ? Main: Enemy;

            BattleResult battleResult = new BattleResult(playerWon, $"{winningPlayer.FullName} won with {winningPlayer.Health}HP left");

            return battleResult;

        }

        public void Menu()
        {
            Console.WriteLine("1. Hit");
            Console.WriteLine("2. Change Weapon");
            Console.WriteLine("3. Run away");

        }

        public bool Choose(int choice)
        {
            switch (choice)
            {
                case 1: return NewRound(); 
                case 2: { PrintWeapons(Main); TakeInput(Main); return false; } 
                case 3: return true;
                default: return true; 
            }
        }

        public bool NewRound()
        {
            bool battleIsOver = Round.StartRound();

            Console.WriteLine($"{Main.FullName} health: {Main.Health}");
            Console.WriteLine($"{Enemy.FullName} health: {Enemy.Health}");

            return battleIsOver;

        }
        public void PrintWeapons(PlayerCharacter character)
        {
           for(int i = 0; i < character.Weapons.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {character.Weapons[i]} ");
            }
        }

        public void TakeInput(PlayerCharacter character)
        {
            int choice = Int32.Parse(Console.ReadLine());
            character.DrawWeapon(choice - 1);
        }


    }

    public class BattleResult
    {
        private bool playerWon;

        public bool PlayerWon { get { return playerWon;  } set { playerWon = value; } }

        private string resultString;

        public string ResultString {  get { return resultString;  } set { resultString = value;  } }

        public BattleResult(bool playerWon, string resultString)
        {
            this.PlayerWon = playerWon;
            this.ResultString = resultString;
        }
    }
}
