using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Bridge;
using Manager;

namespace Piece
{
    public class PieceCore : MonoBehaviour, IShowArea, IGetAttackArea, IGetMoveArea, IGetHP, IDecreaseHP, IGetPos,IGetType,ISetPos,IGameSet
    {
        // ��̊�{����

        
        // ScriptableObject�p�ϐ�
        [SerializeField] private PieceStatus pieceStatus;

        // �N���X�ϐ�
        private PieceAttackArea pieceAttackArea;
        private PieceMoveArea   pieceMoveArea;
        private PieceDead       pieceDead;
        private KingDead        kingDead;


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

        // �R�}�̈ʒu�ϐ�
        private Vector2 piecePos = new Vector2(0f,0f);

        // �R�}�̎�ޕϐ�
        private int pieceType;
        public int PieceType
        {
            get
            {
                return pieceType;
            }
            set
            {
                pieceType = value;
            }
        }



        private void Start()
        {
            // �R���|�[�l���g�擾
            pieceAttackArea = GetComponent<PieceAttackArea>();
            pieceMoveArea   = GetComponent<PieceMoveArea>();
            pieceDead       = GetComponent<PieceDead>();
            kingDead        = GetComponent<KingDead>();

            // ScriptableObject����
            hp = pieceStatus.hp;
            this.pieceType = pieceStatus.pieceType;
        }

        private void Update()
        {
        }




        // ----- HP���� -----

        //  HP�����炷�C���^�[�t�F�[�X
        public bool DecreaseHP()
        {
            hp--;
            if (hp <= 0)
            {
                if (pieceType == 0)
                {
                    kingDead.Dead();
                    GameSetManager.loseCount = 3;
                    Debug.Log("���C�t" + GameSetManager.loseCount);
                }
                else 
                {
                    pieceDead.Dead();
                    GameSetManager.loseCount++;
                    Debug.Log("���C�t" + GameSetManager.loseCount);
                }               

                return true;
            }
            return false;
        }
        // HP��Ԃ��C���^�[�t�F�[�X
        public int GetHP()
        { 
            return hp;
        }        




        // ----- �͈͏��� -----

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




        // �R�}�̈ʒu���𑗂�C���^�[�t�F�[�X
        public Vector2 GetPos()
        {
            return piecePos;
        }

        // �R�}�̎�ރC���^�[�t�F�[�X
        int IGetType.GetType()
        {
            return pieceType;
        }

        // �R�}�̈ʒu��ύX����C���^�[�t�F�[�X
        public void SetPos(Vector2 pos)
        {
            piecePos = pos;
        }


        // �Q�[�����I���������ǂ�����Ԃ��C���^�[�t�F�[�X
        public bool GameSet()
        {
            if (GameSetManager.loseCount >= 3)
            {
                Debug.Log("���O�̕���!!!!");
                return true;
            }
            else
            {
                return false;
            }                             
        }
    }

}
