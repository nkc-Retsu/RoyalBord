using Bridge;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Inputer
{
    public class SendData : MonoBehaviour
    {
        // �����擾���đ��鏈��

        [SerializeField] GameObject manager;
        // �N���X�ϐ�
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
