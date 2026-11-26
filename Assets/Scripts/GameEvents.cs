using System;

namespace KarmaSystem
{
    public static class GameEvents
    {
        // Takes two Parameters, an int and a KarmaAlignment (enum: { Evil , Good })
        // Don't need this in the inspector so can be static
        public static Action<int, Karma.KarmaAlignment> OnKarmaChange;
        // Enemy Spawner needs to use this and add to the list. Must meet have an int and a Karma.KarmaAlignment parameters
    }
}
