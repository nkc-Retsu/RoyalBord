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

        public static bool playerTurn = false;
        private int turnNum = 0;

        void Start()
        {

        }

        void Update()
        {
            TestInputer();
        }


        public void TurnChange()
        {
            playerTurn = (playerTurn) ? false : true;
        }


        private void StateChange()
        {
            if(turnNum == 0)
            {
                
            }
            else if(turnNum % 2 == 1)
            {
                TurnChange();
            }
            else if(turnNum % 2 == 0)
            {
                TurnChange();
            }
        }

        private void TestInputer()
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                turnNum++;
                StateChange();

                Debug.Log("playerTurn=" + playerTurn);
            }
        }


    }
}
