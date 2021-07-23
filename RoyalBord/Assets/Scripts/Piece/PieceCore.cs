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

        // HandWall�ϐ�
        private GameObject handWall;
        private Transform handWall_Child;

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

            // ��D�̕ǂ��擾
            handWall = GameObject.Find("Hand_Wall");
            handWall_Child = handWall.gameObject.transform.GetChild(0);


            // ScriptableObject����
            hp = pieceStatus.hp;
            this.pieceType = pieceStatus.pieceType;

            // �R�}�̖��O���擾����ϐ�
            string objName = null;

            // �擾�����R�}�̃^�O
            switch (gameObject.tag)
            {
                // �����̃R�}�̏ꍇ
                case "PlayerPiece":
                    switch (pieceType)
                    {
                        // �����̎�D
                        case 1:
                            objName = "HandPiece_Knight";
                            break;
                        case 2:
                            objName = "HandPiece_Shielder";
                            break;
                        case 3:
                            objName = "HandPiece_Archer";
                            break;
                    }
                    break;

                // �G�̃R�}�̏ꍇ
                case "EnemyPiece":
                    switch (pieceType)
                    {
                        // �G�̎�D
                        case 1:
                            objName = "Enemy_HandPiece_Knight";
                            break;
                        case 2:
                            objName = "Enemy_HandPiece_Shielder";
                            break;
                        case 3:
                            objName = "Enemy_HandPiece_Archer";
                            break;
                    }

                    break;

                // �����̕�
                case "PlayerWall":

                    break;

                // �G�̕�
                case "EnemyWall":
                    break;

                // ����ȊO
                default:
                    break;
            }

            // ����̃Q�[���I�u�W�F�N�g���擾
            GameObject obj = GameObject.Find(objName);
            Debug.Log(obj);

            // �I�������R�}������
            Destroy(obj);


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
                // �v���C���[�̃R�}�̏ꍇ
                if (gameObject.tag == "PlayerPiece")
                {
                    // �R�}�̃^�C�v���L���O�������ꍇ
                    if (pieceType == 0)
                    {
                        // �L���O�����ʏ����Ăяo��
                        kingDead.Dead();

                        // ���s�ɕK�v�ȕϐ�(���̕ϐ���3�ɂȂ����畉����)
                        GameSetManager.loseCount = 3;

                        // �Q�[���Z�b�g�����Ăяo��
                        GameSet();

                        Debug.Log("���C�t" + GameSetManager.loseCount);
                    }
                    // �R�}�̃^�C�v���ǂ̏ꍇ
                    else if (pieceType == 4)
                    {
                        Debug.Log("�ǂ͕ǂ𐶐����Ȃ���");
                    }
                    // ����ȊO
                    else
                    {
                        // ��D�̕ǂ��g����悤�ɂ���
                        ActiveWall(GameSetManager.loseCount);

                        // �R�}�����ʂƂ������Ăяo��
                        pieceDead.Dead();

                        // ���s�ɕK�v�ȕϐ�(���̕ϐ���3�ɂȂ����畉����)
                        GameSetManager.loseCount++;

                        // �Q�[���Z�b�g�����Ăяo��
                        GameSet();

                        Debug.Log("���C�t" + GameSetManager.loseCount);
                    }
                }
                // �R�}�����񂾂���Ԃ�
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
            // �R�}�ɂ���čU���ł���͈͂�ς���
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
                // �R�}�ɂ���Ĉړ��ł���͈͂�ς���
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
            // �R�}��I���������ɖ����o���p
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
                // �}�l�[�W���[���擾����
                GameObject manager = GameObject.Find("Manager");

                // �R���|�[�l���g�擾
                manager.GetComponent<GameSetManager>().GameSet();

                // �Q�[�����I���������Ƃ�Ԃ�
                return true;
            }
            else
            {
                // �܂��Q�[�����I�����Ă��Ȃ����Ƃ�Ԃ�
                return false;
            }                             
        }


        // ��D�̕ǂ��g����悤�ɂ��鏈��
        private void ActiveWall(int n)
        {
            handWall_Child = handWall.gameObject.transform.GetChild(n);
            handWall_Child.gameObject.SetActive(true);
        }
    }

}
