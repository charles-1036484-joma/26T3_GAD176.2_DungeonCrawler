using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace KarmaSystem
{
    public class Karma : MonoBehaviour
    {
        public enum KarmaStatus
        {
            Good,
            Evil,
        }

        #region KARMA ALIGNMENT - Good or Evil Stat variables

        [Header("Karma Alignment Range Values")]
        [SerializeField]
        private int pureEvilKarmaValue = -1000;

        [SerializeField]
        private int pureGoodKarmaValue = 1000;

        [SerializeField]
        private int currentKarmaValue = 0;

        #endregion


        #region Karma Alignment Thresholds

        [Header("Alignment Thresholds")]
        // <===================Evil Threshold Tiers=================> //

        [SerializeField] // If player is at or below this number they are bad
        private int evilAlignmentThresholdZero = -100;

        [SerializeField] // If player is at or below this number they are evil
        private int evilAlignmentThresholdOne = -200;

        [SerializeField] // If player is at or below this number they are evil
        private int evilAlignmentThresholdTwo = -300;

        [SerializeField] // If player is at or below this number they are evil
        private int evilAlignmentThresholdThree = -400;

        [SerializeField] // If player is at or below this number they are evil
        private int evilAlignmentThresholdFour = -500;

        // <===================Good Threshold Tiers=================> //

        [SerializeField] // Same here ^^^
        private int goodAlignmentThresholdZero = 100;

        [SerializeField] // Same here ^^^
        private int goodAlignmentThresholdOne = 200;

        [SerializeField] // Same here ^^^
        private int goodAlignmentThresholdTwo = 300;

        [SerializeField] // Same here ^^^
        private int goodAlignmentThresholdThree = 400;

        [SerializeField] // Same here ^^^
        private int goodAlignmentThresholdFour = 500;

        #endregion


        #region OnKarmaChanged Event

        public UnityEvent<int, KarmaStatus> onKarmaChanged = new UnityEvent<int, KarmaStatus>(); // I made this protected, in future when i expand this system I may need another class inheriting from Karma

        private void OnEnable()
        {
            // I need a listener with a callback
            // onLevelGenerated.AddListener(A function here that);
        }
        #endregion

        // I WILL NEED TO USE THESE FUNCTIONS LATER WHEN LISTENING TO PROXIMITY, THEY WORK BUT NOT FOR MY PURPOSE ATM
        // #region Event Listener functions
        // public void SubscribeToKarmaListener(UnityAction<int, KarmaStatus> listener)
        // {
        //     onKarmaChanged.AddListener(listener);
        //     Debug.Log("SubscribeToKarmaListener Called");
        // }

        // public void UnsubscribeFromKarmaListener(UnityAction<int, KarmaStatus> listener)
        // {
        //     onKarmaChanged.RemoveListener(listener);
        //     Debug.Log("UnsubscribeFromKarmaListener Called");
        // }

        // #endregion

        #region Functions to allow changing of Karma externally

        // This is the only way to change Karma, positive numbers add and negative subtract
        // // This is then used to determine, bad, neutral or good
        // public void AddGoodKarma(int amount)
        // {
        //     currentGoodKarmaValue += amount;
        //     Debug.Log("Karma has changed by: " + amount);
        //     // Since this changes Karma so we need to call it/invoke it
        //     // onKarmaChanged?.Invoke(currentKarmaValue, CurrentStatus);
        //     Debug.Log("You are Character is: " + CurrentStatus);
        // }

        // public void AddBadKarma(int amount)
        // {
        //     currentBadKarmaValue += amount;
        //     Debug.Log("Karma has changed by: " + amount);
        //     // Since this changes Karma so we need to call it/invoke it
        //     // onKarmaChanged?.Invoke(currentKarmaValue, CurrentStatus);
        //     Debug.Log("You are Character is: " + CurrentStatus);
        // }

        // This is a read-only property, when you use this 'CurrentStatus' it will get and return the result of the if value
        // I only want this script to be able to influence currentStatus
        // public KarmaStatus CurrentStatus
        // {
        //     get
        //     {
        //         // Neutral Cases
        //         if (
        //             currentGoodKarmaValue <= goodThreshold && currentBadKarmaValue < badThreshold
        //             || currentGoodKarmaValue >= goodThreshold && currentBadKarmaValue >= badThreshold
        //         )
        //         {
        //             Debug.Log("Your Character is Neutral");
        //             return KarmaStatus.Neutral;
        //         }
        //         if (currentGoodKarmaValue >= goodThreshold && currentBadKarmaValue <= badThreshold)
        //         {
        //             Debug.Log("Your Character is Good");
        //             return KarmaStatus.Good;
        //         }
        //         if (currentBadKarmaValue >= badThreshold && currentGoodKarmaValue < goodThreshold)
        //         {
        //             Debug.Log("Your Character is Bad");
        //             return KarmaStatus.Bad;
        //         }
        //         Debug.Log("Your Character is Neutral");
        //         return KarmaStatus.Neutral;
        //     }
        // }

        // These are the Getter functions to create accessibility across other scripts, they simply return the respective variables
        public int publicCurrentGoodKarmaValue
        {
            get { return currentGoodKarmaValue; }
        } // the => is shorthand return get method

        // public int CheckKarmaValueAndAddStats
        // {
        //     get {
        //         if(currentGoodKarmaValue > goodThreshold)
        //         {

        //         }

        //      }
        // } //
        public int publicCurrentBadKarmaValue
        {
            get { return currentBadKarmaValue; }
        } // it is pretty much a get function every time it is called it gets the value, recalculating it.
        #endregion
    }
}
