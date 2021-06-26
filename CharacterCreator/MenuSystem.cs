using System;
using static ArenaFighter.MenuSystem;

namespace ArenaFighter
{
    public class MenuObject
    {
        public string MenuText { get; set; }
        public DoSomething MenuAction { get; set; }

        public MenuObject(string menuText, DoSomething menuAction)
        {
            this.MenuText = menuText;
            this.MenuAction = menuAction;
        }
    }
    public class MenuSystem
    {
        public delegate void DoSomething();

        private MenuObject[] menuChoices;
        public MenuObject[] MenuChoices { get { return menuChoices; } set { menuChoices = value; } }

        public MenuObject this[int i]
        {
            get { return MenuChoices[i]; }
            set { MenuChoices[i] = value; }
        }

        public MenuSystem(MenuObject[] menuChoices)
        {
            this.MenuChoices = menuChoices;
        }

        public void PrintMenuSystem()
        {
            for (int i = 0; i < MenuChoices.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {this[i].MenuText}");
            }
        }

        public void Choose(int i)
        {
            if (i - 1 < MenuChoices.Length || i - 1 > 0)
                this[i - 1].MenuAction();
            else
                throw new IndexOutOfRangeException("Choice is out of bounds");
        }
    }

   
}
