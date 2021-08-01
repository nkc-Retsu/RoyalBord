using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Bridge;
using Manager;

namespace Piece
{
    public class PieceCore : MonoBehaviour, IShowArea, IGetAttackArea, IGetMoveArea, IGetHP, IDecreaseHP, IGetPos, IGetType, ISetPos, IGameSet
    {
        // ��̊�{����


        // ScriptableObject�p�ϐ�
        [SerializeField] private PieceStatus pieceStatus;

        // �����ƕǂ̃q�r��Sprite���擾
        [SerializeField] private Sprite shieldCrack_Player;
        [SerializeField] private Sprite shieldCrack_Enemy;
        [SerializeField] private Sprite wallCrack;

        // HandWall�ϐ�
        private GameObject handWall;
        private Transform handWall_Child;

        // EnemyHandWall�ϐ�
        private GameObject enemyHandWall;
        private Transform enemyHandWall_Child;

        // �N���X�ϐ�
        private SpriteRenderer sr;
        private PieceAttackArea pieceAttackArea;
        private PieceMoveArea pieceMoveArea;
        private PieceDead pieceDead;
        private KingDead kingDead;

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
        private Vector2 piecePos = new Vector2(0f, 0f);

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

        // �G�̕ǎ�D�\���p�ϐ�
        private static int enemyWallCount;



        // �ŏ��ɍs������
        private void Start()
        {
            // �R���|�[�l���g�擾
            sr �@�@         = GetComponent<SpriteRenderer>();
            pieceAttackArea = GetComponent<PieceAttackArea>();
            pieceMoveArea   = GetComponent<PieceMoveArea>();
            pieceDead       = GetComponent<PieceDead>();
            kingDead        = GetComponent<KingDead>();


            // ��D�̕ǎ擾
            handWall = GameObject.Find("Hand_Wall");
            handWall_Child = handWall.gameObject.transform.GetChild(0);

            // �G�̎�D�̕ǎ擾
            enemyHandWall       = GameObject.Find("Enemy_Hand_Wall");
            enemyHandWall_Child = enemyHandWall.gameObject.transform.GetChild(0);


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

                // ��D�̕ǂ��\���ɂ���(����)
                case "PlayerWall":
                    if (GameSetManager.loseCount == 1)
                    {
                        ActivePlayerWall(GameSetManager.loseCount, false);
                    }
                    else if (GameSetManager.loseCount == 2)
                    {
                        ActivePlayerWall(GameSetManager.loseCount, false);
                    }
                    else if (GameSetManager.loseCount == 3)
                    {
                        ActivePlayerWall(GameSetManager.loseCount, false);
                    }
                    break;

                // ��D�̕ǂ��\���ɂ���(�G)
                case "EnemyWall":
                    if(enemyWallCount == 1)
                    {
                        ActiveEnemyWall(enemyWallCount, false);
                    }
                    if (enemyWallCount == 2)
                    {
                        ActiveEnemyWall(enemyWallCount, false);
                    }
                    if (enemyWallCount == 3)
                    {
                        ActiveEnemyWall(enemyWallCount, false);
                    }

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


        // ----- HP���� -----

        //  HP�����炷�C���^�[�t�F�[�X����
        public bool DecreaseHP()
        {
            // hp���}�C�i�X
            hp--;

            // �R�}�����񂾎�����
            if (hp <= 0)
            {
                switch (gameObject.tag)
                {
                    // �����̃R�}�̏ꍇ
                    case "PlayerPiece":
                        PlayerPieceDead();
                        Debug.Log("�����̃R�}");
                        return true;

                    // �G�̋�̏ꍇ
                    case "EnemyPiece":
                        EnemyPieceDead();
                        Debug.Log("�G�̃R�}");
                        return true;

                    // ����ȊO
                    default:
                        pieceDead.Dead();
                        Debug.Log("����ȊO");
                        break;
                }

                //// �Q�[���I�������Ăяo��
                //GameSet();
                //Debug.Log("�Q�[���Z�b�g�Ăяo��");

            }
            // �ǂƏ����Ƀq�r�������
            else if(hp == 1)
            {
                switch (gameObject.tag)
                {
                    // �����̏ꍇ
                    case "PlayerPiece":
                        // sprite�ύX
                        pieceDamagedClack(shieldCrack_Player);
                        break;

                    // �G�̏ꍇ
                    case "EnemyPiece":
            �@�@�@�@�@�@// sprite�ύX
                        pieceDamagedClack(shieldCrack_Enemy);
                        break;

                    // �����̕ǂ̏ꍇ
                    case "PlayerWall":
                        pieceDamagedClack(shieldCrack_Player);
                        break;

                    // �G�̕ǂ̏ꍇ
                    case "EnemyWall":
                        pieceDamagedClack(shieldCrack_Enemy);
                        break;

                    // ����ȊO
                    default:
                        break;
                }
            }
            return false;
        }

        // HP��Ԃ��C���^�[�t�F�[�X
        public int GetHP()
        {
            return hp;
        }



        // ----- �_���[�W���� -----

        // �����̃R�}�����񂾂Ƃ�����
        private void PlayerPieceDead()
        {
            // �L���O�̏ꍇ
            if (pieceType == 0)
            {
                // �L���O�����񂾂Ƃ������Ăяo��
                kingDead.Dead();

                Debug.Log("�����̃L���O���S");

                // 3�ɂȂ����畉����ϐ��𑝂₷
                GameSetManager.loseCount = 3;

                // �Q�[���I�������Ăяo��
                GameSet();

                Debug.Log("������"+"���C�t" + GameSetManager.loseCount);
            }
            // �ǂ̏ꍇ
            else if (pieceType == 4)
            {
                Debug.Log("�ǂ͕ǂ𐶐����Ȃ���");
            }
            // ����ȊO
            else
            {
                // �R�}�����񂾂Ƃ������Ăяo��
                pieceDead.Dead();
                
                // 3�ɂȂ����畉����ϐ��𑝂₷
                GameSetManager.loseCount++;

                // �ǂ�\��
                ActivePlayerWall(GameSetManager.loseCount, true);

                //�Q�[���I�������Ăяo��
                GameSet();

                Debug.Log("������" + "���C�t" + GameSetManager.loseCount);

            }
        }

        // �G�̃R�}�����񂾂Ƃ�����
        private void EnemyPieceDead()
        {
            // �L���O�̏ꍇ
            if (pieceType == 0)
            {
                // �L���O�����񂾂Ƃ������Ăяo��
                kingDead.Dead();

                Debug.Log("�G�̃L���O���S");

                // �ǂ����������������ǂ��`����H(��[���Ƒ��k)
                // �Q�[���I�������Ăяo��
                GameSet();

            }
            // �ǂ̏ꍇ
            else if (pieceType == 4)
            {
                Debug.Log("�ǂ͕ǂ𐶐����Ȃ���");
            }
            // ����ȊO
            else
            {
                // �R�}�����񂾂Ƃ������Ăяo��
                pieceDead.Dead();

                // �G�̎�D�Ǖ\���p�ϐ�
                enemyWallCount++;
                
                // �ǂ�\��
                ActiveEnemyWall(enemyWallCount,true);

                //�Q�[���I�������Ăяo��
                GameSet();

            }

        }

        // �ǂƏ����̃X�v���C�g��ύX���鏈��(�U�����ꂽ��q�r����)
        private void pieceDamagedClack(Sprite sprite)
        {
            if (pieceType == 2)
            {
                // �摜��ύX
                sr.sprite = sprite;
                
            }
            else if (pieceType == 4)
            {
                // �摜��ύX
                sr.sprite = wallCrack;
            }

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
        private void ActivePlayerWall(int n, bool activeFlg)
        {
            handWall_Child = handWall.gameObject.transform.GetChild(n);
            handWall_Child.gameObject.SetActive(activeFlg);
        }



        // �G�̎�D�̕ǂ�\��(�����ɂȂ�̒l������̂�)
        private void ActiveEnemyWall(int n, bool activeFlg)
        {
            Debug.Log("�G�Ǖ\��");
            enemyHandWall_Child = enemyHandWall.gameObject.transform.GetChild(n);
            enemyHandWall_Child.gameObject.SetActive(activeFlg);
        }
    }

}
