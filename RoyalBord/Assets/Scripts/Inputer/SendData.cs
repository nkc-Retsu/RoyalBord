using Bridge;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Inputer
{
    public class SendData : MonoBehaviour
    {
        // �����擾���đ��鏈��

        // �N���X�ϐ�
        private HoldObj     holdObj;
        private SelectField selectField;


        // Start is called before the first frame update
        void Start()
        {
            holdObj     = GetComponent<HoldObj>();
            selectField = GetComponent<SelectField>();
        }

        // Update is called once per frame
        void Update()
        {

        }

        private void Send()
        {
            
        }
    }

}
