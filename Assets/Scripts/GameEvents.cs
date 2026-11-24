using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

namespace KarmaSystem
{
    public static class GameEvents
    {
        public static UnityEvent<int, Karma.KarmaAlignment> onKarmaChange =
            new UnityEvent<int, Karma.KarmaAlignment>();
    }
}
