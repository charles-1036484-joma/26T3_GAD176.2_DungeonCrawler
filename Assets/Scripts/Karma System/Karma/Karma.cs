using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace KarmaSystem
{
    public class Karma : MonoBehaviour
    {
        public enum KarmaAlignment
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


        #region KARMA ALIGNMENT THRESHOLDS

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

        #region UNITY SPECIFIC FUNCTIONS

        private void OnEnable()
        {
            // I need a listener with a callback
            // onLevelGenerated.AddListener(A function here that);
        }

        private void Start() { }

        private void Update() { }
        #endregion


        #region UNITY EVENT


        #endregion

        // I WILL NEED TO USE THESE FUNCTIONS LATER WHEN LISTENING TO PROXIMITY, THEY WORK BUT NOT FOR MY PURPOSE ATM
        // #region Event Listener functions
        // public void SubscribeToKarmaListener(UnityAction<int, KarmaAlignment> listener)
        // {
        //     onKarmaChanged.AddListener(listener);
        //     Debug.Log("SubscribeToKarmaListener Called");
        // }

        // public void UnsubscribeFromKarmaListener(UnityAction<int, KarmaAlignment> listener)
        // {
        //     onKarmaChanged.RemoveListener(listener);
        //     Debug.Log("UnsubscribeFromKarmaListener Called");
        // }

        // #endregion

        #region CUSTOM FUNCTIONS


        // I need a function to check if the Karma Tier has changed

        public void AddKarma(KarmaAlignment alignment, int amount)
        {
            // First get the current Tier and current alignment, store them in temps
            int tierBeforeAddingKarma = GetCurrentKarmaTier;
            KarmaAlignment alignmentBeforeAddingKarma = GetCurrentKarmaLeaning;

            if (alignment == KarmaAlignment.Good)
            {
                Debug.Log("This was a good act");
                currentKarmaValue += Mathf.Abs(amount);
            }
            else
            {
                Debug.Log("This was a bad act");
                currentKarmaValue -= Mathf.Abs(amount);
            }

            currentKarmaValue = Mathf.Clamp(
                currentKarmaValue, // the current value
                pureEvilKarmaValue, // The pure evil value
                pureGoodKarmaValue // The pure good value
            ); // Clamp the karma value between -1000 and 1000 to make sure it does not go past either.

            //<======= Comment out later ==========>//
            Debug.Log(
                "Karma is now "
                    + currentKarmaValue
                    + " (Tier "
                    + GetCurrentKarmaTier
                    + " "
                    + GetCurrentKarmaLeaning
                    + ")"
            );

            //<======= Comment out later ==========>//

            // Check if the karma tier has changed
            // Pass the tier before (stored in the temp variable) and the alignmentBeforeAddingKarma as comparisons
            CheckKarmaChange(tierBeforeAddingKarma, alignmentBeforeAddingKarma);
        }

        private void CheckKarmaChange(
            int tierBeforeAddingKarma,
            KarmaAlignment alignmentBeforeAddingKarma
        )
        {
            int tierAfterAddingKarma = GetCurrentKarmaTier; // Karma tier at the time of this call
            KarmaAlignment alignmentAfterAddingKarma = GetCurrentKarmaLeaning; // alignment at the time of this call

            if (tierBeforeAddingKarma != tierAfterAddingKarma)
            {
                GameEvents.onKarmaChange.Invoke(tierAfterAddingKarma, alignmentAfterAddingKarma);
                Debug.Log($"Karma Tier has changed, Character is Tier {tierAfterAddingKarma}");
            }

            if (alignmentBeforeAddingKarma != alignmentAfterAddingKarma)
            {
                // onKarmaChange.Invoke
            }
        }

        #endregion

        #region GETTER FUNCTIONS


        public int GetCurrentKarmaValue
        {
            get { return Mathf.Clamp(currentKarmaValue, pureEvilKarmaValue, pureGoodKarmaValue); }
        }

        public KarmaAlignment GetCurrentKarmaLeaning
        {
            get
            {
                if (GetCurrentKarmaValue < 0) // If Karma value is less than 0
                {
                    return KarmaAlignment.Evil;
                }
                else
                {
                    return KarmaAlignment.Good;
                }
            }
        }

        // Function to Get Current Karma Tier
        public int GetCurrentKarmaTier
        {
            get
            {
                if (GetCurrentKarmaValue < 0)
                {
                    // Tier Checks for Evil Alignment is Karma is in the Negatives
                    if (GetCurrentKarmaValue <= evilAlignmentThresholdFour)
                    {
                        return 5;
                    }
                    else if (GetCurrentKarmaValue <= evilAlignmentThresholdThree)
                    {
                        return 4;
                    }
                    else if (GetCurrentKarmaValue <= evilAlignmentThresholdTwo)
                    {
                        return 3;
                    }
                    else if (GetCurrentKarmaValue <= evilAlignmentThresholdOne)
                    {
                        return 2;
                    }
                    else if (GetCurrentKarmaValue <= evilAlignmentThresholdOne)
                    {
                        return 2;
                    }
                    else if (GetCurrentKarmaValue <= evilAlignmentThresholdZero)
                    {
                        return 1;
                    }
                }
                else if (GetCurrentKarmaValue > 0)
                {
                    // Tier Checks for Good Alignment if Karma is in the Positives
                    if (GetCurrentKarmaValue >= goodAlignmentThresholdFour)
                    {
                        return 5;
                    }
                    else if (GetCurrentKarmaValue >= goodAlignmentThresholdThree)
                    {
                        return 4;
                    }
                    else if (GetCurrentKarmaValue >= goodAlignmentThresholdTwo)
                    {
                        return 3;
                    }
                    else if (GetCurrentKarmaValue >= goodAlignmentThresholdOne)
                    {
                        return 2;
                    }
                    else if (GetCurrentKarmaValue >= goodAlignmentThresholdZero)
                    {
                        return 1;
                    }
                }

                return 0;
            }
        }

        #endregion

        #region TEMPORARY TESTS

        [ContextMenu("Test Good 100")] // Adds a menu item in the Inspector called Test Good 100
        private void TestGood100()
        {
            AddKarma(KarmaAlignment.Good, 100); // Pretend the player did a good act worth 100
        }

        [ContextMenu("Test Evil 100")] // Adds a menu item called Test Evil 100
        private void TestEvil100()
        {
            AddKarma(KarmaAlignment.Evil, 100); // Pretend the player did an evil act worth 100
        }

        [ContextMenu("Test Good 5000")] // Adds a menu item called Test Good 5000
        private void TestGood5000()
        {
            AddKarma(KarmaAlignment.Good, 5000); // A huge good act, to check the limit works
        }

        [ContextMenu("Test Evil 5000")] // Adds a menu item called Test Evil 5000
        private void TestEvil5000()
        {
            AddKarma(KarmaAlignment.Evil, 5000); // A huge evil act, to check the limit works
        }

        #endregion
    }
}
