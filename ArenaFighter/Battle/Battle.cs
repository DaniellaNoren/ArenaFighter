
using ArenaFighter.Character;
using CharacterCreator;
using System;

namespace ArenaFighter
{
    public class Battle
    {

        private readonly PlayerCharacter Enemy;
        private readonly PlayerCharacter Main;
        private bool RoundIsOver { get; set; }

        private readonly Round Round;
        private MenuSystem MenuSystem { get; set; }

        public Battle(PlayerCharacter main, PlayerCharacter enemy)
        {
            this.Main = main;
            this.Enemy = enemy;
            this.Round = new Round(main, enemy);
            this.MenuSystem = new MenuSystem(new MenuObject[]
            {
                new MenuObject("Hit", () => { NewRound();}),
                new MenuObject("Change weapon", () => {ChooseWeapon(); }),
                new MenuObject("Run away", () => {RunAway(); })
            });
        }

        private void RunAway()
        {
            this.RoundIsOver = true;
            Console.WriteLine("You ran away!");
        }
        public BattleResult StartBattle()
        {

            Console.WriteLine($"You met enemy {Enemy.FullName} looking all angry with their {Enemy.DrawnWeapon}");

            do
            {

                PrintBattleMenu();

                int choice = TakeInput();

                Choose(choice);


            } while (!RoundIsOver);


            return GetBattleResult();

        }

        private void Choose(int choice)
        {
            try
            {
                MenuSystem.Choose(choice);
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("Bad choice");
                RoundIsOver = true;
            }

        }
        private BattleResult GetBattleResult()
        {
            bool playerSurvived = Main.Health > 0;
            bool playerWon = Enemy.Health < 1;

            PlayerCharacter winningPlayer = playerWon ? Main : Enemy;

            string resultString = !playerWon && playerSurvived 
                ? $"You ran away from {Enemy.FullName}" 
                : $"{ winningPlayer.FullName} won with { winningPlayer.Health} HP left against {(playerSurvived ? Enemy.FullName : "you")}";
         
            return new BattleResult(playerWon, playerSurvived, resultString);
        }

        private void PrintBattleMenu()
        {
            MenuSystem.PrintMenuSystem();
        }

        private void ChooseWeapon()
        {
            PrintWeapons();
            DrawNewWeapon(TakeInput());
        }

        private void NewRound()
        {
            bool battleIsOver = Round.StartRound();

            Console.WriteLine($"{Main.FullName} health: {Main.Health}");
            Console.WriteLine($"{Enemy.FullName} health: {Enemy.Health}");

            RoundIsOver = !battleIsOver;
        }
        private void PrintWeapons()
        {
            for (int i = 0; i < Main.Weapons.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {Main.Weapons[i]} ");
            }
        }

        private int TakeInput()
        {
            return InputHandler.GetUserInput(3);
        }

        private void DrawNewWeapon(int choice)
        {
            Main.DrawWeapon(choice - 1);
        }


    }

    public class BattleResult
    {
        private bool playerWon;

        public bool PlayerWon { get { return playerWon; } set { playerWon = value; } }
        public bool PlayerSurvived { get; set; }
        private string resultString;

        public string ResultString { get { return resultString; } set { resultString = value; } }

        public BattleResult(bool playerWon, bool PlayerSurvived, string resultString)
        {
            this.PlayerWon = playerWon;
            this.ResultString = resultString;
            this.PlayerSurvived = PlayerSurvived;
        }
    }
}
