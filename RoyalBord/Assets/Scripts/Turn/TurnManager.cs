using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Bridge;
using Photon.Pun;
using Photon.Realtime;

namespace Turn
{
    public class TurnManager : MonoBehaviourPunCallbacks,ITurnChange
    {
        enum STATE
        {
            PLACEMENT,
            GAME,
        }

        public static bool playerTurn = false;
        public static int turnCount = 0;

        [SerializeField] private bool debugFlg = false;
        [SerializeField] private GameObject yourTurnUI;
        [SerializeField] private GameObject darkZone;

        //[SerializeField] private GameObject startSummonArea;

        void Start()
        {
            turnCount = 0;

            if(Matching.hostFlg)
            {
                playerTurn = Matching.playerTurn;
                if(!playerTurn)
                {
                    photonView.RPC(nameof(TurnChangeRPC), RpcTarget.Others);
                }
            }

            Debug.Log(playerTurn);

            if (playerTurn) Instantiate(yourTurnUI);
            else darkZone.transform.localEulerAngles = new Vector3(0, 0, 180);
        }

        void Update()
        {
            TestInputer();
        }


        public void TurnChange()
        {
            photonView.RPC(nameof(TurnChangeRPC), RpcTarget.All);
        }

        [PunRPC]
        private void TurnChangeRPC()
        {
            playerTurn = (playerTurn == true) ? false : true;
            if (playerTurn)
            {
                Instantiate(yourTurnUI);
            }
            turnCount++;
            Debug.Log(turnCount + "É^Å[Éìñ⁄");

            darkZone.transform.localEulerAngles += new Vector3(0, 0, 180);

            if (turnCount == 2)
            {
                darkZone.SetActive(false);
            }
        }


        private void StateChange()
        {

        }

        private void TestInputer()
        {
            if (!debugFlg) return;

            if (Input.GetKeyDown(KeyCode.Z))
            {
                TurnChangeRPC();
            }
        }


    }
}
