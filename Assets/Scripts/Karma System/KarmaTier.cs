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
            karma.onKarmaTierChanged.AddListener(KarmaTierChangedCallback);
        }

        private void OnDisable()
        {
            karma.onKarmaTierChanged.RemoveListener(KarmaTierChangedCallback);
        }

        public void KarmaTierChangedCallback(int tier, Karma.KarmaAlignment alignment)
        {
            Debug.Log("Karma tier changed. Tier " + tier + " " + alignment);
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
            // DisplayKarmaLeaning();
            // DisplayKarmaTier();
            // if (karma.onKarmaTierChanged != null) { }
        }
    }
}
