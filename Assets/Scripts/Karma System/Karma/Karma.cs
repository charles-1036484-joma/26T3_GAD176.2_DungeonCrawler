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


        #region UNITY EVENT

        public UnityEvent<int, KarmaAlignment> onKarmaChanged =
            new UnityEvent<int, KarmaAlignment>();

        private void OnEnable()
        {
            // I need a listener with a callback
            // onLevelGenerated.AddListener(A function here that);
        }
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

        public void AddKarma(KarmaAlignment alignment, int amount)
        {
            if (alignment == KarmaAlignment.Good)
            {
                Debug.Log("This was a good act");
                currentKarmaValue += Mathf.Abs(amount);
            }
            else
            {
                Debug.Log("This was a bad act");
                currentKarmaValue -= Math.Abs(amount);
            }

            currentKarmaValue = Mathf.Clamp(
                currentKarmaValue,
                pureEvilKarmaValue,
                pureGoodKarmaValue
            );

            Debug.Log(
                "Karma is now "
                    + currentKarmaValue
                    + " (Tier "
                    + GetKarmaTier
                    + " "
                    + GetCurrentKarmaLeaning
                    + ")"
            );
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
                if (GetCurrentKarmaValue < 0)
                {
                    return KarmaAlignment.Evil;
                }
                else
                {
                    return KarmaAlignment.Good;
                }
            }
        }

        public int GetKarmaTier
        {
            get
            {
                if (GetCurrentKarmaValue < 0)
                {
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
                    else if (GetCurrentKarmaValue <= evilAlignmentThresholdZero)
                    {
                        return 1;
                    }
                }
                else if (GetCurrentKarmaValue > 0)
                {
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
    }
}
