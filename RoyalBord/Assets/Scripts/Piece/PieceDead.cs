using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Piece
{
    public class PieceDead : MonoBehaviour
    {
        // �R�}�����񂾂Ƃ�����


        // �N���X�ϐ�
        private SpriteRenderer sr;

        private void Start()
        {
            // �R���|�[�l���g�擾
            sr = GetComponent<SpriteRenderer>();
        }

        private void Update()
        {
        }


        // ���񂾂Ƃ�����
        public void Dead()
        {
            Debug.Log(gameObject + "������!!!");

            sr.material.color = sr.material.color - new Color32(0,0,0,0);

            // �R���[�`���Ăяo��
            StartCoroutine("FadeClear");
        }

        // �����ɂ��鏈��
        IEnumerator FadeClear()
        {
            for(int i = 0; i < 255; ++i)
            {
                sr.material.color = sr.material.color - new Color32(0,0,0,1);
                
                // 0.01�b�҂�
                yield return new WaitForSeconds(0.0001f);
            }

            // GameObject��setActive������
            gameObject.SetActive(false);
        }
    }
}


