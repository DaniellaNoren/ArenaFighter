using ArenaFighter.Character;
using ArenaFighter.Utensils;
using Lexicon.CSharp.InfoGenerator;
using System;

namespace CharacterCreator
{
  
    public class CharacterCreator 
    {
        internal static readonly Random Random = RandomWrapper.GetRandomInstance();

        public static PlayerCharacter GetCharacter(ICharacterInformationSupplier characterInformationSupplier)
        {
            return new PlayerCharacter(characterInformationSupplier.GetAName(), 
                characterInformationSupplier.GetALastName(), 
                characterInformationSupplier.GetAnAge(), 
                characterInformationSupplier.GetHealth(), characterInformationSupplier.GetSwiftness(), characterInformationSupplier.GetWeapons());
        }
    }

    
}
