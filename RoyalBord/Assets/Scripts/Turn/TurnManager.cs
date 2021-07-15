using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Bridge;

namespace Turn
{
    public class TurnManager : MonoBehaviour,ITurnChange
    {
        enum STATE
        {
            PLACEMENT,
            GAME,
        }

        public static bool playerTurn=false;
        private int stateNum = 0;
        void Start()
        {

        }

        void Update()
        {
            
        }

        public void TurnChange()
        {
            playerTurn = (playerTurn) ? false : true;
        }
    }
}
