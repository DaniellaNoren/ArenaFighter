using Lexicon.CSharp.InfoGenerator;
using System;
using System.Collections.Generic;

namespace ArenaFighter.Utensils
{
    public class InformationGeneratorWrapper
    {
        private static InfoGenerator InfoGenerator;

        private InformationGeneratorWrapper() { }

        public static InfoGenerator GetInstance()
        {
            if (InfoGenerator == null)
                InfoGenerator = new InfoGenerator();

            return InfoGenerator;
        }
    }
}
