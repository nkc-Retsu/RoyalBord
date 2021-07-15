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

         private STATE state;

        void Start()
        {
            state = GetComponent<STATE>(); 
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
                state = STATE.PLACEMENT;
            }
            else if(turnNum % 2 == 1)
            {
                Debug.Log("�Q�[���J�n");
                Debug.Log("��s�^�[��");
                TurnChange();
            }
            else if(turnNum % 2 == 0)
            {
                Debug.Log("��U�^�[��");
                TurnChange();
            }
        }

        private void TestInputer()
        {
            if (Input.GetKeyDown(KeyCode.Return)) turnNum++;
        }


    }
}
