using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Turn;

namespace Manager
{
    public class GameSetManager : MonoBehaviour
    {
        // ƒRƒ}‚ª€‚ñ‚¾”‚ğ‚Á‚Ä‚¢‚é•Ï”
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
