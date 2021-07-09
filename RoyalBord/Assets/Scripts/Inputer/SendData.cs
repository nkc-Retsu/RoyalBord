using Bridge;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Inputer
{
    public class SendData : MonoBehaviour
    {
        // î•ñ‚ğæ“¾‚µ‚Ä‘—‚éˆ—

        // ƒNƒ‰ƒX•Ï”
        private IReceiveData receiveData;

        // Start is called before the first frame update
        void Start()
        {
            receiveData = GetComponent<IReceiveData>();
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void Send(GameObject select1, GameObject select2)
        {
            receiveData.ReceiveData(select1, select2);
        }

    }

}
