using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Turn
{
    public class TurnManager : MonoBehaviour,ITurnChange
    {
        private bool playerTurn = false;
        void Start()
        {

        }

        void Update()
        {
            if(Input.GetKeyDown(KeyCode.Return))
            {
                TurnChange();
            }
        }

        public void TurnChange()
        {

        }
    }
}
