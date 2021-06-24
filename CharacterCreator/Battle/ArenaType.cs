using System;
using System.Collections.Generic;
using System.Text;

namespace ArenaFighter
{
    public interface ArenaType
    {
    }

    public class WaterArena : ArenaType
    {
        // Gives you bonus if you have fins lol
    }

    public class ForestArena : ArenaType
    {
        //Gives fighters with idk swords a bonus?
    }

    public class FireArena : ArenaType
    {

    }

    public enum ArenaTypeEnum
    {
        Water, Forest, Fire
    }
}
