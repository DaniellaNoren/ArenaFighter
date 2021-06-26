using ArenaFighter;
using ArenaFighter.Items;
using ArenaFighter.Character;
using System;
using System.Collections.Generic;
using ArenaFighter.Utensils;
using System.Text.RegularExpressions;

namespace CharacterCreator
{
    class ArenaSimulator
    {
        static void Main(string[] args)
        {
            ArenaSimulator arenaSimulator = new ArenaSimulator();
            arenaSimulator.GameLoop();
        }

        private MenuSystem menuSystem;
        public MenuSystem MenuSystem { get { return menuSystem; } set { menuSystem = value; } }

        private bool GameIsRunning { get; set; }

        private PlayerCharacter playerCharacter;
        public PlayerCharacter PlayerCharacter { get { return playerCharacter; } set { this.playerCharacter = value; } }

        private List<BattleResult> results = new List<BattleResult>();
        public List<BattleResult> Results { get { return results; } set { this.results = value; } }

        private static readonly RandomCharacterInformationSupplier RandomInformationSupplier = new RandomCharacterInformationSupplier();
        private static readonly Random Random = RandomWrapper.GetRandomInstance();

        public void GameLoop()
        {
            CreateMenuSystem();
            PrintOpening();
            CreateCharacter();
            int menuLength = MenuSystem.MenuChoices.Length;
            GameIsRunning = true;

            Console.WriteLine(playerCharacter);
            
            while (GameIsRunning)
            {
                Console.WriteLine($"Health: {playerCharacter.Health}, XP: {playerCharacter.ExperiencePoints}");
                MenuSystem.PrintMenuSystem();

                int choice = InputHandler.GetUserInput(menuLength);
                MenuSystem.Choose(choice);

            }

            PrintResults();
        }


        private void CreateMenuSystem()
        {
            MenuObject[] menuObjects = new MenuObject[]
            {
                new MenuObject("Fight", () => { StartBattle(); }),
                new MenuObject("Look for items", () => { LookForItems(); }),
                new MenuObject("Go to Närhälsan Krokslätt", () => { GoToHospital(); }),
                new MenuObject("Go for a superfun jog!", () => { Excercise(); }),
                new MenuObject("Retire", () => {Retire(); })
            };

            MenuSystem = new MenuSystem(menuObjects);

        }

        private void Retire()
        {
            Console.WriteLine("Goodbye forever!");
            GameIsRunning = false;
        }



        private void PrintOpening()
        {
            ChangeColor(ConsoleColor.Green);
            Console.WriteLine("Welcome to Arena Fighter");
            Console.WriteLine("-------------\nTime to create your character!");
            ChangeColor(ConsoleColor.Gray);
        }

        private void CreateCharacter()
        {
            PlayerCharacter = CharacterCreator.GetCharacter(new ConsoleNewMainCharacterInformationSupplier());
        }


        public void LookForItems()
        {
            int ran = Random.Next(0, 101);

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
            int ran = Random.Next(0, 101);

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

        private static PlayerCharacter MakeRandomEnemy()
        {
            PlayerCharacter enemy = CharacterCreator.GetCharacter(RandomInformationSupplier);

            return enemy;
        }

        private void PrintResults()
        {
            Console.WriteLine("--------------------\nResults:");

            foreach (BattleResult result in Results)
            {
                Console.WriteLine('\n' + result.ResultString);
            }
        }
        private void PrintResult(BattleResult battleResult)
        {
            Console.WriteLine(battleResult.ResultString);
        }

        private bool StartBattle()
        {
            PlayerCharacter enemy = MakeRandomEnemy();
            Battle b = new Battle(this.playerCharacter, enemy);

            BattleResult br = b.StartBattle();
            return CheckResult(br);
        }

        private bool CheckResult(BattleResult br)
        {
            PrintResult(br);
            Results.Add(br);

            if (br.PlayerSurvived && br.PlayerWon)
            {

                Console.WriteLine("You gained 1XP!");
                PlayerCharacter.ExperiencePoints++;

            }
            else if(!br.PlayerSurvived)
            {
                Console.WriteLine("You died :(\nMaybe be better next time.");
                GameIsRunning = false;
            }

            return br.PlayerWon;
        }

        public static void ChangeColor(ConsoleColor color)
        {
            Console.ForegroundColor = color;
        }

    }

    public class InputHandler
    {
        private static bool CheckForValidInput(string input)
        {
            return Regex.IsMatch(input, @"^\d+$");
        }
        public static int GetUserInput(int maxValue, int minValue = 0)
        {
            bool incorrectInput;
            int number = 0;

            do
            {
                string input = Console.ReadLine();
                incorrectInput = !CheckForValidInput(input);

                if (!incorrectInput)
                {
                    number = Int32.Parse(input);
                    if (number <= maxValue || number >= minValue)
                        incorrectInput = false;
                    else
                        Console.WriteLine("Invalid choice.");
                }
                else
                {
                    Console.WriteLine("Incorrect input, try again!");
                }

            } while (incorrectInput);

            return number;
        }
    }

}
