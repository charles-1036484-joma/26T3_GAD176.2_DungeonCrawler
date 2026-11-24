using KarmaSystem;
using UnityEngine;

namespace KarmaSystem
{
    public class Player : CharacterBaseClass
    {
        private Karma playerKarma;

        private KarmaTier playerKarmaTier;

        [SerializeField]
        private int playerJumpHeight;

        [SerializeField]
        private StatsManager statsManager;

        protected Karma.KarmaAlignment type;

        #region Unity specific functions
        void Awake()
        {
            // I do not need these here.
            playerKarma = GetComponent<Karma>();
            playerKarmaTier = GetComponent<KarmaTier>();
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
