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

        private float time = 0;

        private void Start()
        {
            // �R���|�[�l���g�擾
            sr = GetComponent<SpriteRenderer>();
        }

        private void Update()
        {
            time += Time.deltaTime;
        }


        // ���񂾂Ƃ�����
        public void Dead()
        {
            Debug.Log(gameObject + "������!!!");

            // �R���[�`���Ăяo��
            StartCoroutine("FadeClear");
        }

        // �����ɂ��鏈��
        IEnumerator FadeClear()
        {
            time = 0f;

            // �t�F�[�h�ŏ�����
            if(sr.color.a <= 0f) sr.color -= new Color(0f, 0f, 0f, 0.01f * time);

            // 2�b�҂@(��������ƌ��Ǐ����邩��Ӗ��Ȃ��H)
            yield return new WaitForSeconds(2);

            // GameObject��setActive������
            gameObject.SetActive(false); 
        }
    }
}


