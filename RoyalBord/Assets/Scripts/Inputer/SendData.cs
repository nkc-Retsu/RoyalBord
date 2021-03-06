using Bridge;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Inputer
{
    public class SendData : MonoBehaviour
    {
        // 情報を取得して送る処理

        [SerializeField] GameObject manager;

        // クラス変数
        private IReceiveData receiveData;

        // Start is called before the first frame update
        void Start()
        {
            receiveData = manager.GetComponent<IReceiveData>();
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
