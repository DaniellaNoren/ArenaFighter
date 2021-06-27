using System;
using System.Collections.Generic;
using System.Text;

namespace ArenaFighter.Utensils
{
    public class RandomWrapper
    {
        private static Random Random;

        private RandomWrapper() { }

        public static Random GetRandomInstance()
        {
            if (Random == null)
                Random = new Random();

            return Random;
        }
    }
}
