using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Turn;

namespace Manager
{
    public class GameSetManager : MonoBehaviour
    {
        // コマが死んだ数を持っている変数
        public static int loseCount;

        [SerializeField] GameObject gameSetWin;
        [SerializeField] GameObject gameSetLose;

        public void GameSet()
        {
            if (TurnManager.playerTurn)
            {
                Instantiate(gameSetWin);
            }
            else
            {
                Instantiate(gameSetLose);
            }
        }
    }

}
