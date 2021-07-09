using Bridge;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Inputer
{
    public class SelectField : MonoBehaviour
    {
        // �t�B�[���h�����擾���鏈��


        // �I�u�W�F�N�g�擾�p�ϐ�
        private GameObject clickedObj;


        // �N���X�ϐ�
        private HoldObj holdObj;
        private SendData sendData;


        // Start is called before the first frame update
        void Start()
        {
            holdObj  = GetComponent<HoldObj>();
            sendData = GetComponent<SendData>();
        }

        // Update is called once per frame
        void Update()
        {
            // 1��ڂ̑I��������Ă��鎞
            if (holdObj.HandSelectFlg)
            {
                SelectObj();
            }
        }



        // ��D�����N���b�N�������ɏ����擾���鏈��
        private void SelectObj()
        {
            if (ClickLeft())
            {
                // �N���b�N�����I�u�W�F�N�g���擾����ϐ�
                clickedObj = null;

                // �N���b�N�ŃI�u�W�F�N�g���擾
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit2D hit2d = Physics2D.Raycast((Vector2)ray.origin, (Vector2)ray.direction);

                // �I�u�W�F�N�g���擾������
                if (hit2d)
                {
                    // �N���b�N�����I�u�W�F�N�g�̃N���X���擾
                    clickedObj = hit2d.transform.gameObject;

                    // 2��ڂ̑I�����\�ɂ���
                    holdObj.HandSelectFlg = false;

                    sendData.Send(holdObj.ClickObj, clickedObj);
                }

                // ���O��\��
                Debug.Log("select2 " + clickedObj);
            }


        }

        // ���N���b�N����
        private bool ClickLeft()
        {
            return Input.GetMouseButtonDown(0);
        } 
    }

}
