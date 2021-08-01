using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Turn;

namespace Manager
{
    public class GameSetManager : MonoBehaviour
    {
        // �R�}�����񂾐��������Ă���ϐ�(����)
        public static int playerLoseCount;

        // �R�}�����񂾐��������Ă���ϐ�(�G)
        public static int enemyLoseCount;


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
