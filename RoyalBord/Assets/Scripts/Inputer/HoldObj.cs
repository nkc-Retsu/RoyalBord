using Hand;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Inputer
{
    public class HoldObj : MonoBehaviour
    {
        // ���N���b�N�Ŏ�D�����擾���鏈��


        // �I�u�W�F�N�g�擾�p�ϐ�
        private GameObject clickedObj;



        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            Click();
        }



        // ��D�����N���b�N�������ɏ����擾���鏈��
        private void Click()
        {
            if (ClickLeft())
            {
                // �N���b�N�����I�u�W�F�N�g���擾����ϐ�
                clickedObj = null;
                HandPiece obj = null;

                // �N���b�N�ŃI�u�W�F�N�g���擾
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit2D hit2d = Physics2D.Raycast((Vector2)ray.origin, (Vector2)ray.direction);

                // �I�u�W�F�N�g���擾������
                if (hit2d)
                {
                    // �N���b�N�����I�u�W�F�N�g�̃N���X���擾
                    clickedObj = hit2d.transform.gameObject;
                    obj = clickedObj.GetComponent<HandPiece>();
                }

                // ���O��\��
                Debug.Log("���O " + obj.SendName());
            }

            
        }

        // ���N���b�N����
        private bool ClickLeft()
        {
            return Input.GetMouseButtonDown(0);
        }
    }

}
