using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Bridge;
using Manager;

namespace Piece
{
    public class PieceCore : MonoBehaviour, IShowArea, IGetAttackArea, IGetMoveArea, IGetHP, IDecreaseHP, IGetPos,IGetType,ISetPos,IGameSet
    {
        // 駒の基本処理

        
        // ScriptableObject用変数
        [SerializeField] private PieceStatus pieceStatus;

        // HandWall変数
        private GameObject handWall;
        private Transform handWall_Child;

        // クラス変数
        private PieceAttackArea pieceAttackArea;
        private PieceMoveArea   pieceMoveArea;
        private PieceDead       pieceDead;
        private KingDead        kingDead;


        // 変更用HP変数
        private int hp;
        // プロパティ
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

        // コマの位置変数
        private Vector2 piecePos = new Vector2(0f,0f);

        // コマの種類変数
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
            string objName = null;

            switch (gameObject.tag)
            {
                case "PlayerPiece":
                    switch (pieceType)
                    {
                         
                    }
                    break;

                case "EnemyPiece":
                    break;

                case "PlayerWall":
                    break;

                case "EnemyWall":
                    break;

                default:
                    break;
            }

            GameObject obj = GameObject.Find(objName);
            Destroy(obj);


            // コンポーネント取得
            pieceAttackArea = GetComponent<PieceAttackArea>();
            pieceMoveArea   = GetComponent<PieceMoveArea>();
            pieceDead       = GetComponent<PieceDead>();
            kingDead        = GetComponent<KingDead>();


            handWall = GameObject.Find("Hand_Wall");
            handWall_Child = handWall.gameObject.transform.GetChild(0);


            // ScriptableObjectを代入
            hp = pieceStatus.hp;
            this.pieceType = pieceStatus.pieceType;
        }

        private void Update()
        {
        }




        // ----- HP処理 -----

        //  HPを減らすインターフェース
        public bool DecreaseHP()
        {
            hp--;
            if (hp <= 0)
            {
                if (pieceType == 0)
                {
                    kingDead.Dead();
                    GameSetManager.loseCount = 3;
                    GameSet();
                    Debug.Log("ライフ" + GameSetManager.loseCount);
                }
                else if (pieceType == 4)
                {
                    Debug.Log("壁は壁を生成しないよ");
                }
                else 
                {
                    ActiveWall(GameSetManager.loseCount);
                    pieceDead.Dead();
                    GameSetManager.loseCount++;
                    GameSet();
                    Debug.Log("ライフ" + GameSetManager.loseCount);
                }               

                return true;
            }
            return false;
        }
        // HPを返すインターフェース
        public int GetHP()
        { 
            return hp;
        }        




        // ----- 範囲処理 -----

        // 攻撃範囲インターフェース
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

        // 移動範囲インターフェース
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

        // 移動範囲インターフェース(Inputerに渡す用)
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




        // コマの位置情報を送るインターフェース
        public Vector2 GetPos()
        {
            return piecePos;
        }

        // コマの種類インターフェース
        int IGetType.GetType()
        {
            return pieceType;
        }

        // コマの位置を変更するインターフェース
        public void SetPos(Vector2 pos)
        {
            piecePos = pos;
        }


        // ゲームが終了したかどうかを返すインターフェース
        public bool GameSet()
        {
            if (GameSetManager.loseCount >= 3)
            {
                Debug.Log("お前の負け!!!!");
                return true;
            }
            else
            {
                return false;
            }                             
        }



        private void ActiveWall(int n)
        {
            handWall_Child = handWall.gameObject.transform.GetChild(n);
            handWall_Child.gameObject.SetActive(true);
        }
    }

}
