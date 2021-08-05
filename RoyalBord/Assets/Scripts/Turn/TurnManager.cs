using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Bridge;
using Photon.Pun;
using Photon.Realtime;
using Manager;

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

        [SerializeField] private GameObject manager;

        [SerializeField] private bool debugFlg = false;
        [SerializeField] private GameObject yourTurnUI;
        [SerializeField] private GameObject darkZone;

        private float playerLimitTime = 60.0f;
        private float enemyLimitTime = 60.0f;
        [SerializeField] Image playerTimeGuage;
        [SerializeField] Image enemyTimeGuage;

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
            if(playerTurn && playerLimitTime>0)
            {
                playerLimitTime -= Time.deltaTime;
                playerTimeGuage.fillAmount = playerLimitTime / 60f;
                if(playerLimitTime<0)
                {
                    manager.GetComponent<GameSetManager>().GameSet();
                }
            }
            else if(!playerTurn && enemyLimitTime>0)
            {
                enemyLimitTime -= Time.deltaTime;
                enemyTimeGuage.fillAmount = enemyLimitTime / 60f;
                if (enemyLimitTime < 0)
                {
                    manager.GetComponent<GameSetManager>().GameSet();
                }
            }

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

            playerLimitTime = 60.0f;
            enemyLimitTime = 60.0f;
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
