using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Bridge;

namespace Piece
{
    public class PieceCore : MonoBehaviour, IShowArea, IGetAttackArea, IGetMoveArea, IGetHP, IDecreaseHP, IGetPos
    {
        // ��̊�{����


        // ScriptableObject�p�ϐ�
        [SerializeField] private PieceStatus pieceStatus;

        // �N���X�ϐ�
        private PieceAttackArea pieceAttackArea;
        private PieceMoveArea   pieceMoveArea;

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

        private Vector2 piecePos = new Vector2(0f,0f) ;

        private void Start()
        {
            pieceAttackArea = GetComponent<PieceAttackArea>();
            pieceMoveArea   = GetComponent<PieceMoveArea>();

            hp = pieceStatus.hp;
        }
        private void Update()
        {
        }



        //HP����

        //  HP�����炷�C���^�[�t�F�[�X
        public bool DecreaseHP()
        {
            hp--;
            if (hp <= 0)
            {
                Debug.Log("���ʃ��\�b�h�Ăяo��");
                return true;
            }
            return false;
        }
        // HP��Ԃ��C���^�[�t�F�[�X
        public int GetHP()
        { 
            return hp;
        }        




        // �͈͏���

        // �U���͈̓C���^�[�t�F�[�X
        public int[,] GetAttackArea()
        {
            switch (pieceStatus.attackArea)
            {
                case 1:
                    return pieceAttackArea.AttackAreaDefault;

                case 2:
                    return pieceAttackArea.AttackAreaArcher;

                case 3:
                    return pieceAttackArea.AttackAreaKnight;
                default:
                    return null;
            }
        }

        // �ړ��͈̓C���^�[�t�F�[�X
        public int[,] GetMoveArea()
        {
            switch (pieceStatus.moveArea)
            {
                case 1:
                    return pieceMoveArea.MoveAreaDefault;

                case 2:
                    return pieceMoveArea.MoveAreaKing;

                default:
                    return null;
            }
        }


        // �ړ��͈̓C���^�[�t�F�[�X(Inputer�ɓn���p)
        public int[,] ShowArea()
        {
            return null;
        }

        public Vector2 GetPos()
        {
            return piecePos;
        }
    }

}
