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
        private int turnNum = 0;

        [SerializeField] bool debugFlg = false;
        [SerializeField] GameObject yourTurnUI;

        void Start()
        {
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
        }

        void Update()
        {
            TestInputer();
            Debug.Log(playerTurn);
        }


        public void TurnChange()
        {
            photonView.RPC(nameof(TurnChangeRPC), RpcTarget.All);
        }

        [PunRPC]
        private void TurnChangeRPC()
        {
            playerTurn = (playerTurn == true) ? false : true;
            if (playerTurn) Instantiate(yourTurnUI);
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
