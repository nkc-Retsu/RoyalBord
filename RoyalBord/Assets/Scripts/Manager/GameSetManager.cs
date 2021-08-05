using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Turn;

namespace Manager
{
    public class GameSetManager : MonoBehaviour
    {
        // コマが死んだ数を持っている変数(味方)
        public static int playerLoseCount;

        // コマが死んだ数を持っている変数(敵)
        public static int enemyLoseCount;


        [SerializeField] GameObject gameSetWin;
        [SerializeField] GameObject gameSetLose;

        public void GameSet()
        {
            if (enemyLoseCount >= 3)
            {
                Instantiate(gameSetWin);
                Debug.Log("勝ち!!!!!");
            }
            else if (playerLoseCount >= 3)
            {
                Instantiate(gameSetLose);
                Debug.Log("負け!!!!!");
            }
            else
            {
                if(TurnManager.playerTurn)
                {
                    Instantiate(gameSetLose);
                    Debug.Log("負け!!!!!");
                }
                else
                {
                    Instantiate(gameSetWin);
                    Debug.Log("勝ち!!!!!");
                }
            }
        }
    }

}
