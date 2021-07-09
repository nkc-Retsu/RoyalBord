using Bridge;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Inputer
{
    public class HoldObj : MonoBehaviour, ICanInput
    {
        // ���N���b�N�Ŏ�D�����擾���鏈��


        // �I�u�W�F�N�g�擾�p�ϐ�
        private GameObject clickedObj;
        public GameObject ClickObj
        {
            get
            {
                return clickedObj;
            }
            set
            {
                clickedObj = value;
            }
        }


        // ��D��I�񂾎��Ƀt�B�[���h
        private bool handSelectFlg = false;
        public bool HandSelectFlg
        {
            get
            {
                return handSelectFlg;
            }
            set
            {
                handSelectFlg = value;
            }
        }



        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (!handSelectFlg)
            {
                SelectObj();
            }
        }



        // ���͉\���ǂ������肷�鏈��
        public bool CanInput(bool flg)
        {
            return flg;
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
                    handSelectFlg = true;
                }

                // ���O��\��
                Debug.Log("select1 " + clickedObj);
            }

            
        }

        // ���N���b�N����
        private bool ClickLeft()
        {
            return Input.GetMouseButtonDown(0);
        }

    }

}
