using UnityEngine;

// THIS CLASS SHOULD ONLY DEAL WITH THE KARMA TIERS
// I WANT TO USE PROGRAMMABLE OBJECTS
namespace KarmaSystem
{
    public class KarmaTier : MonoBehaviour
    {
        public Karma karma;

        private void OnEnable()
        {
            GameEvents.OnKarmaChange += KarmaTierChangedCallback;
        }

        private void OnDisable()
        {
            GameEvents.OnKarmaChange -= KarmaTierChangedCallback;
        }

        public void KarmaTierChangedCallback(int tier, Karma.KarmaAlignment alignment)
        {
            Debug.Log(
                "KarmaTierChangedCallback: Karma tier changed. Tier " + tier + " " + alignment
            );
        }

        public void DisplayKarmaLeaning()
        {
            Debug.Log(karma.GetCurrentKarmaLeaning);
        }

        public void DisplayKarmaTier()
        {
            Debug.Log($"Tier: {karma.GetCurrentKarmaTier} {karma.GetCurrentKarmaLeaning} ");
        }

        void Update()
        {
            // DisplayKarmaLeaning();
            // DisplayKarmaTier();
            // if (karma.onKarmaChange != null) { }
        }
    }
}
