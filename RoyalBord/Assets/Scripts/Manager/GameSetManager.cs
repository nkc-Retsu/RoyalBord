using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Turn;
using Bridge;

namespace Manager
{
    public class GameSetManager : MonoBehaviour
    {
        // コマが死んだ数を持っている変数(味方)
        public static int playerLoseCount;

        // コマが死んだ数を持っている変数(敵)
        public static int enemyLoseCount;

        [SerializeField] private TurnManager turnManager;
        [SerializeField] private GameObject gameSetWin;
        [SerializeField] private GameObject gameSetLose;

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
            Debug.Log("勝ち!!!!!");
        }

        public void GameSetLose()
        {
            turnManager.GetComponent<IGameSetFlgSettable>().SetGameSetFlg();
            Instantiate(gameSetLose);
            Debug.Log("負け!!!!!");
        }
    }

}
