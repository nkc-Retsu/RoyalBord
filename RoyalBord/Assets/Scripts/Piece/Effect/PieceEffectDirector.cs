using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceEffectDirector : MonoBehaviour
{
    // �G�t�F�N�g�𐶐����鏈��

    [Header("�����ɂ���Đ�������G�t�F�N�g���ς���")]
    [SerializeField] private int effectSelectNum;

    // �G�t�F�N�g�I�u�W�F�N�g�p�ϐ�
    [SerializeField,Tooltip("0")] private GameObject KingDamagedEffect;     // �L���O���_���[�W���󂯂����̃G�t�F�N�g
    [SerializeField,Tooltip("1")] private GameObject defaultDamagedEffect;  // �R�}���_���[�W���󂯂����̃G�t�F�N�g
    [SerializeField,Tooltip("2")] private GameObject SheilderDamagedEffect; // �V�[���_�[���_���[�W���󂯂����̃G�t�F�N�g
    [SerializeField,Tooltip("3")] private GameObject WallDamagedEffect;     // �ǂ��_���[�W���󂯂����̃G�t�F�N�g


    // �����ɂ���Đ�������G�t�F�N�g��ύX���鏈��
    public void EffectGenerator()
    {
        switch (effectSelectNum)
        {
            case 0:
                Instantiate(KingDamagedEffect).transform.position = transform.position;
                break;
            case 1:
                Instantiate(defaultDamagedEffect).transform.position = transform.position;
                break;
            case 2:
                Instantiate(SheilderDamagedEffect).transform.position = transform.position;
                break;
            case 3:
                Instantiate(WallDamagedEffect).transform.position = transform.position;
                break;
        }
    }
    
}
