using KarmaSystem;
using SAE.GAD176.P1.CBC;
using UnityEngine;
using UnityEngine.UI;

namespace KarmaSystem
{
    public class Player : CharacterBaseClass
    {
        private Karma playerKarma;

        private KarmaTier playerKarmaTier;

        // public Movement playerSpeed; Commenting out for the time being, need to focus on the essentials

        // [SerializeField]
        // private int playerFearFactor;

        [SerializeField]
        private int playerJumpHeight;

        [SerializeField]
        private StatsManager statsManager;

        protected Karma.KarmaStatus type;

        // [SerializeField]
        // private Slider GoodSlider;

        // [SerializeField]
        // private Slider BadSlider;

        #region Unity specific functions
        void Awake()
        {
            // I do not need these here.
            playerKarma = GetComponent<Karma>(); // Get the Karma "Component" that is attached to the object this Script is attached to
            playerKarmaTier = GetComponent<KarmaTier>();
            // playerSpeed = GetComponent<Movement>();
            // statsManager = GetComponent<StatsManager>();
        }

        void Start()
        {
            // Debug.Log(playerKarmaTier.);
        }

        // Update is called once per frame
        void Update()
        {
            // if player touches red cube
            // null check onKarmaChanged
            // invoke RemoveKarma

            /*
                if player touches gold cube
                    null check onKarmaChanged
                    invoke AddKarma
            */
        }

        // private void OnCollisionEnter(Collision collision)
        // {
        //     if (collision.gameObject.tag == "GoodAct")
        //     {
        //         statsManager.UpdateGoodAct(collision);
        //     }
        //     if (collision.gameObject.tag == "BadAct")
        //     {
        //         statsManager.UpdateBadAct(collision);
        //     }
        //     if (collision.gameObject.tag == "BigBadAct")
        //     {
        //         statsManager.UpdateBigBadAct(collision);
        //     }

        //     if (collision.gameObject.tag == "Neutral")
        //     {
        //         return;
        //     }
        // }
        #endregion
    }
}
