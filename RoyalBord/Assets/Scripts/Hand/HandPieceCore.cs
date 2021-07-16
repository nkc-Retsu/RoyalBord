using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hand
{
    public class HandPieceCore : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }


        public void LostHand(bool flg)
        {
            gameObject.SetActive(flg);
        }
    }

}
