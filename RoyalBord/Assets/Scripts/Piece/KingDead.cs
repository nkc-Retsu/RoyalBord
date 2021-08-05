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
            // �R���[�`���Ăяo��
            StartCoroutine("FadeClear");
        }

        // �����ɂ��鏈��
        IEnumerator FadeClear()
        {
            // �t�F�[�h�ŏ�����
            sr.color = new Color(0f, 0f, 0f, 0.5f);

            // 2�b�҂@(��������ƌ��Ǐ����邩��Ӗ��Ȃ��H)
            yield return new WaitForSeconds(1.5f);

            // GameObject��setActive������
            gameObject.SetActive(false);
        }
    }
}
