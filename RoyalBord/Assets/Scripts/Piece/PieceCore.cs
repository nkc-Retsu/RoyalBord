using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Bridge;

namespace Piece
{
    public class PieceCore : MonoBehaviour, IShowArea, IGetAttackArea, IGetMoveArea, IGetHP, IDecreaseHP
    {
        // ��̊�{����


        // ScriptableObject�p�ϐ�
        [SerializeField] private PieceStatus pieceStatus;

        // �ύX�pHP�ϐ�
        private int hp;
        // �v���p�e�B
        public int HP
        {
            get
            {
                return hp;
            }
            set
            {
                hp = value;
            }
        }


        private void Start()
        {
            hp = pieceStatus.hp;
        }

        private void Update()
        {
        }



        //HP����

        //  HP�����炷�C���^�[�t�F�[�X
        public int DecreaseHP(int dec)
        {
            return this.hp -= dec;
        }
        // HP��Ԃ��C���^�[�t�F�[�X
        public int GetHP()
        { 
            return hp;
        }        




        // �͈͏���

        // �U���͈̓C���^�[�t�F�[�X
        public Vector2 GetAttackArea()
        {
            return pieceStatus.attackArea;
        }

        // �ړ��͈̓C���^�[�t�F�[�X
        public Vector2 GetMoveArea()
        {
            return pieceStatus.moveArea;
        }

        // �ړ��͈̓C���^�[�t�F�[�X(Inputer�ɓn���p)
        public Vector2 ShowArea()
        {
            return pieceStatus.moveArea;
        }
    }

}
