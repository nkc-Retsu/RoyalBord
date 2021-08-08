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
    public class TurnManager : MonoBehaviourPunCallbacks, ITurnChange, IGameSetFlgSettable
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
        [SerializeField] private GameObject enemyTurnUI;
        [SerializeField] private GameObject darkZone;

        private float playerLimitTime = 60.0f;
        private float enemyLimitTime = 60.0f;
        [SerializeField] private Image playerTimeGuage;
        [SerializeField] private Image enemyTimeGuage;
        [SerializeField] private Text timerCountText;

        [SerializeField] private Text playerNameText;
        [SerializeField] private Text enemyNameText;
        [SerializeField] private GameObject playerThinkingIcon;
        [SerializeField] private GameObject enemyThinkingIcon;

        [SerializeField] private GameObject surrenderUI;

        private bool gameSetFlg = false;
        public static bool inputFlg = false;

        void Start()
        {
            playerNameText.text = PhotonNetwork.NickName;
            enemyNameText.text = (Matching.hostFlg) ? PhotonNetwork.PlayerList[1].NickName : PhotonNetwork.PlayerList[0].NickName;

            turnCount = 0;

            if (Matching.hostFlg)
            {
                playerTurn = Matching.playerTurn;
                if (!playerTurn)
                {
                    Instantiate(enemyTurnUI);

                    photonView.RPC(nameof(FirstTurnSwitch), RpcTarget.Others);
                    playerThinkingIcon.SetActive(false);
                    enemyThinkingIcon.SetActive(true);
                    inputFlg = false;
                }
                else
                {
                    Instantiate(yourTurnUI);
                    photonView.RPC(nameof(EnemyTurnUIInstance), RpcTarget.Others);
                }
            }

            Debug.Log(playerTurn);

            if (playerTurn)
            {
                inputFlg = true;
            }
            else
            {
                darkZone.transform.localEulerAngles = new Vector3(0, 0, 180);
            }
        }

        void Update()
        {
            if (gameSetFlg) return;

            if (playerTurn && playerLimitTime > 0)
            {
                playerLimitTime -= Time.deltaTime;
                playerTimeGuage.fillAmount = playerLimitTime / 60f;
                timerCountText.text = ((int)playerLimitTime).ToString();
                if (playerLimitTime < 0)
                {
                    manager.GetComponent<GameSetManager>().GameSet();
                }
            }
            else if (!playerTurn && enemyLimitTime > 0)
            {
                enemyLimitTime -= Time.deltaTime;
                enemyTimeGuage.fillAmount = enemyLimitTime / 60f;
                timerCountText.text = ((int)enemyLimitTime).ToString();
                if (enemyLimitTime < 0)
                {
                    manager.GetComponent<GameSetManager>().GameSet();
                }
            }

            TestInputer();
        }


        public void TurnChange()
        {
            StartCoroutine(TurnChangeDelay());
        }

        IEnumerator TurnChangeDelay()
        {
            inputFlg = false;
            yield return new WaitForSeconds(0.5f);
            photonView.RPC(nameof(TurnChangeRPC), RpcTarget.All);
        }

        [PunRPC]
        private void TurnChangeRPC()
        {
            if (gameSetFlg) return;

            playerTurn = (playerTurn == true) ? false : true;
            if (playerTurn)
            {
                Instantiate(yourTurnUI);
                playerThinkingIcon.SetActive(true);
                enemyThinkingIcon.SetActive(false);
                inputFlg = true;
            }
            else
            {
                Instantiate(enemyTurnUI);
                playerThinkingIcon.SetActive(false);
                enemyThinkingIcon.SetActive(true);
                inputFlg = false;
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
            playerTimeGuage.fillAmount = playerLimitTime / 60f;
            enemyTimeGuage.fillAmount = enemyLimitTime / 60f;
        }

        private void TestInputer()
        {
            if (!debugFlg) return;

            if (Input.GetKeyDown(KeyCode.Z))
            {
                TurnChangeRPC();
            }
        }

        public void SetGameSetFlg()
        {
            gameSetFlg = true;
        }

        public void SurrenderButton()
        {
            surrenderUI.SetActive(true);
        }
        public void SurrenderButtonNo()
        {
            surrenderUI.SetActive(false);
        }

        public void SurrenderButtonYes()
        {
            if (gameSetFlg) return;
            surrenderUI.SetActive(false);
            photonView.RPC(nameof(Surrender), RpcTarget.Others);
            manager.GetComponent<GameSetManager>().GameSetLose();
            SetGameSetFlg();
        }

        [PunRPC]
        private void Surrender()
        {
            manager.GetComponent<GameSetManager>().GameSetWin();
            SetGameSetFlg();
        }

        [PunRPC]
        private void FirstTurnSwitch()
        {
            playerTurn = true;
            Instantiate(yourTurnUI);
            playerThinkingIcon.SetActive(true);
            enemyThinkingIcon.SetActive(false);
            inputFlg = true;
            darkZone.transform.localEulerAngles += new Vector3(0, 0, 180);
        }

        [PunRPC]
        private void EnemyTurnUIInstance()
        {
            Instantiate(enemyTurnUI);
        }
    }
}
