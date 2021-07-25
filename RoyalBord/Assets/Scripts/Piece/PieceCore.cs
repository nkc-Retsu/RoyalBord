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


            // ��D�̕ǎ擾
            handWall = GameObject.Find("Hand_Wall");
            handWall_Child = handWall.gameObject.transform.GetChild(0);


            // ScriptableObject����
            hp = pieceStatus.hp;
            this.pieceType = pieceStatus.pieceType;

            // �R�}�̖��O�ϐ�
            string objName = null;

            // �R�}�̃^�O�ɂ���ď�����ύX
            switch (gameObject.tag)
            {
                // �����̃R�}�̏ꍇ
                case "PlayerPiece":
                    switch (pieceType)
                    {
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

                // �����̕ǂ̏ꍇ
                case "PlayerWall":

                    break;
                // �G�̕ǂ̏ꍇ
                case "EnemyWall":
                    break;

                // ����ȊO
                default:
                    break;
            }

            // �I�������R�}���擾
            GameObject obj = GameObject.Find(objName);
            Debug.Log(obj);

            // ��D�̃R�}�����ŁH
            Destroy(obj);


        }

        private void Update()
        {
        }




        // ----- HP���� -----

        //  HP�����炷�C���^�[�t�F�[�X
        public bool DecreaseHP()
        {
            // hp���}�C�i�X
            hp--;

            // �R�}�̎�ޕʂ̎��񂾂Ƃ�����
            if (hp <= 0)
            {
                // �L���O�̏ꍇ
                if (pieceType == 0)
                {
                    // �L���O�����񂾂Ƃ������Ăяo��
                    kingDead.Dead();

                    // 3�ɂȂ����畉����ϐ��𑝂₷
                    if (gameObject.tag == "PlayerPiece") GameSetManager.loseCount = 3;

                    // �Q�[���I�������Ăяo��
                    GameSet();
                    Debug.Log("���C�t" + GameSetManager.loseCount);
                }
                // �ǂ̏ꍇ
                else if (pieceType == 4)
                {
                    Debug.Log("�ǂ͕ǂ𐶐����Ȃ���");
                }
                // ����ȊO
                else
                {
                    // �ǂ�\��
                    ActiveWall(GameSetManager.loseCount);

                    // �R�}�����񂾂Ƃ������Ăяo��
                    pieceDead.Dead();

                    // 3�ɂȂ����畉����ϐ��𑝂₷
                    GameSetManager.loseCount++;

                    // �Q�[���I�������Ăяo��
                    GameSet();
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
                GameObject manager = GameObject.Find("Manager");
                manager.GetComponent<GameSetManager>().GameSet();
                return true;
            }
            else
            {
                return false;
            }                             
        }


        // ��D�̕ǂ�\�����鏈��
        private void ActiveWall(int n)
        {
            handWall_Child = handWall.gameObject.transform.GetChild(n);
            handWall_Child.gameObject.SetActive(true);
        }
    }

}
