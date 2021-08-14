using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Piece
{
    public class KingDead : MonoBehaviour
    {
        // �L���O�����񂾂Ƃ�����


        // �N���X�ϐ�
        private SpriteRenderer sr;
        private BoxCollider2D col;

        private void Start()
        {
            // �R���|�[�l���g�擾
            sr  = GetComponent<SpriteRenderer>();
            col = GetComponent<BoxCollider2D>();
        }

        private void Update()
        {
        }

        // ���񂾂Ƃ�����
        public void Dead()
        {
            sr.material.color = sr.material.color - new Color32(0, 0, 0, 0);

            col.enabled = false;

            // �R���[�`���Ăяo��
            StartCoroutine("FadeClear");
        }

        // �����ɂ��鏈��
        IEnumerator FadeClear()
        {

            for (int i = 0; i < 255; ++i)
            {
                sr.material.color = sr.material.color - new Color32(0, 0, 0, 5);

                // 0.01�b�҂�
                yield return new WaitForSeconds(0.00001f);
            }

            // GameObject��setActive������
            gameObject.SetActive(false);
        }
    }
}
