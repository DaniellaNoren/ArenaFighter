using ArenaFighter;
using ArenaFighter.Items;
using ArenaFighter.Character;
using Lexicon.CSharp.InfoGenerator;
using System;
using System.Collections.Generic;

namespace CharacterCreator
{
    class ArenaSimulator
    {
        private PlayerCharacter playerCharacter;
        private List<BattleResult> Results = new List<BattleResult>();
        private static readonly RandomCharacterInformationSupplier RandomInformationSupplier = new RandomCharacterInformationSupplier();
        static void Main(string[] args)
        {
            ArenaSimulator arenaSimulator = new ArenaSimulator();

            PrintOpening();

            arenaSimulator.playerCharacter = CharacterCreator.GetCharacter(new ConsoleNewMainCharacterInformationSupplier());

            arenaSimulator.GameLoop();

        }

        public static void PrintOpening()
        {
            ChangeColor(ConsoleColor.Green);
            Console.WriteLine("Welcome to Arena Fighter");
            Console.WriteLine("-------------\nTime to create your character!");
            ChangeColor(ConsoleColor.Gray);
        }

        public static void PrintMenu()
        {
            Console.WriteLine("What do you want to do?\n");
            Console.WriteLine("1. Fight");
            Console.WriteLine("2. Look for items");
            Console.WriteLine("3. Go to Närhälsan Krokslätt");
            Console.WriteLine("4. Go for a superfun jog!");
            Console.WriteLine("5. Retire");
        }

        public void GameLoop()
        {
            bool continueGame = true;

            while (continueGame)
            {
                Console.WriteLine(playerCharacter);
                PrintMenu();
                int choice = Int32.Parse(Console.ReadLine());
                continueGame = Choose(choice);
            }

            PrintResults();
        }

        public bool Choose(int choice)
        {
            switch (choice)
            {
                case 1: return StartBattle();
                case 2: LookForItems(); return true; 
                case 3: GoToHospital(); return true;
                case 4: Excercise(); return true;
                case 5: Console.WriteLine("Goodbye forever!"); return false;
                default: return false;  
            }
        }

        public void LookForItems()
        {
            Random r = new Random();
            int ran = r.Next(0, 101);

            if (ran < 51)
                Console.WriteLine("Nothing found");
            else
            {
                Console.WriteLine("You found something");
                Weapon w = RandomWeaponGenerator.GetRandomWeapon();
                Console.WriteLine("You found a " + w);
                playerCharacter.AddWeapon(w);
            }
        }

        public void Excercise()
        {
            Random r = new Random();
            int ran = r.Next(0, 101);

            if (ran < 51)
                Console.WriteLine("You did not excercise enough");
            else
            {
                Console.WriteLine("You gained 1 Base-HP");
                playerCharacter.BaseHealth++;
            }
        }

        public void GoToHospital()
        {
            Console.WriteLine("You healed up!");
            playerCharacter.Heal(playerCharacter.BaseHealth - playerCharacter.Health);
        }

        public static PlayerCharacter MakeRandomEnemy()
        {
            PlayerCharacter enemy = CharacterCreator.GetCharacter(RandomInformationSupplier);

            return enemy;
        }

        public void PrintResults()
        {
            foreach (BattleResult result in Results)
            {
                Console.WriteLine(result.ResultString);
            }
        }

        public bool StartBattle()
        {
            PlayerCharacter enemy = MakeRandomEnemy();
            Battle b = new Battle(this.playerCharacter, enemy);

            BattleResult br = b.StartBattle();

            Console.WriteLine(br.ResultString);
            Results.Add(br);

            return br.PlayerWon;
        }

        public static void ChangeColor(ConsoleColor color)
        {
            Console.ForegroundColor = color;
        }


        
    }
}
