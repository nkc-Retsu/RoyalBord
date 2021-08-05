using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Turn;
using Bridge;

namespace Manager
{
    public class GameSetManager : MonoBehaviour
    {
        // �R�}�����񂾐��������Ă���ϐ�(����)
        public static int playerLoseCount;

        // �R�}�����񂾐��������Ă���ϐ�(�G)
        public static int enemyLoseCount;

        [SerializeField] private TurnManager turnManager;
        [SerializeField] private GameObject gameSetWin;
        [SerializeField] private GameObject gameSetLose;
        [SerializeField] private GameObject returnButton;

        [SerializeField] private GameObject fadeCloud;

        public void GameSet()
        {
            if (enemyLoseCount >= 3)
            {
                GameSetWin();
            }
            else if (playerLoseCount >= 3)
            {
                GameSetLose();
            }
            else
            {
                if(TurnManager.playerTurn)
                {
                    GameSetLose();
                }
                else
                {
                    GameSetWin();
                }
            }
        }

        public void GameSetWin()
        {
            turnManager.GetComponent<IGameSetFlgSettable>().SetGameSetFlg();
            Instantiate(gameSetWin);
            returnButton.SetActive(true);
            Debug.Log("����!!!!!");
        }

        public void GameSetLose()
        {
            turnManager.GetComponent<IGameSetFlgSettable>().SetGameSetFlg();
            Instantiate(gameSetLose);
            returnButton.SetActive(true);
            Debug.Log("����!!!!!");
        }

        public void OnReturnButton()
        {
            fadeCloud.SetActive(true);
        }
    }

}
