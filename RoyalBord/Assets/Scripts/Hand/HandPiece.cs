using Bridge;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hand
{
    public class HandPiece : MonoBehaviour, ISendName
    {
        // ��D�ʂ̖��O��ݒ肷�鏈��

        // ��D�̖��O���擾����ϐ�
        [SerializeField] private string name = null;


        // ��D���擾�p�C���^�[�t�F�[�X
        public string SendName()
        {
            return name;
        }
    }

}
