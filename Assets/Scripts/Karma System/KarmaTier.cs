using UnityEngine;

// THIS CLASS SHOULD ONLY DEAL WITH THE KARMA TIERS
// I WANT TO USE PROGRAMMABLE OBJECTS
namespace KarmaSystem
{
    public class KarmaTier : MonoBehaviour
    {
        [SerializeField]
        private int currentKarmaTier = 1;

        [SerializeField]
        private int MaxKarmaTier = 10;

        public Karma karma;

        private void OnEnable()
        {
            karma.onKarmaChanged.AddListener(DisplayKarmaTier);
        }

        private void OnDisable()
        {
            karma.onKarmaChanged.RemoveListener(DisplayKarmaTier);
        }

        public void DisplayKarmaLeaning()
        {
            Debug.Log(karma.GetCurrentKarmaLeaning);
        }

        public void DisplayKarmaTier()
        {
            Debug.Log($"Tier: {karma.GetKarmaTier} {karma.GetCurrentKarmaLeaning} ");
        }

        void Update()
        {
            DisplayKarmaLeaning();
            DisplayKarmaTier();
            if (karma.onKarmaChanged != null) { }
        }
    }
}
