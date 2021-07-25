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
            // コンポーネント取得
            pieceAttackArea = GetComponent<PieceAttackArea>();
            pieceMoveArea   = GetComponent<PieceMoveArea>();
            pieceDead       = GetComponent<PieceDead>();
            kingDead        = GetComponent<KingDead>();


            // 手札の壁取得
            handWall = GameObject.Find("Hand_Wall");
            handWall_Child = handWall.gameObject.transform.GetChild(0);


            // ScriptableObjectを代入
            hp = pieceStatus.hp;
            this.pieceType = pieceStatus.pieceType;

            // コマの名前変数
            string objName = null;

            // コマのタグによって処理を変更
            switch (gameObject.tag)
            {
                // 味方のコマの場合
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

                // 敵のコマの場合
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

                // 味方の壁の場合
                case "PlayerWall":

                    break;
                // 敵の壁の場合
                case "EnemyWall":
                    break;

                // それ以外
                default:
                    break;
            }

            // 選択したコマを取得
            GameObject obj = GameObject.Find(objName);
            Debug.Log(obj);

            // 手札のコマを消滅？
            Destroy(obj);


        }

        private void Update()
        {
        }




        // ----- HP処理 -----

        //  HPを減らすインターフェース
        public bool DecreaseHP()
        {
            // hpをマイナス
            hp--;

            // コマの種類別の死んだとき処理
            if (hp <= 0)
            {
                // キングの場合
                if (pieceType == 0)
                {
                    // キングが死んだとき処理呼び出し
                    kingDead.Dead();

                    // 3になったら負ける変数を増やす
                    if (gameObject.tag == "PlayerPiece") GameSetManager.loseCount = 3;

                    // ゲーム終了処理呼び出し
                    GameSet();
                    Debug.Log("ライフ" + GameSetManager.loseCount);
                }
                // 壁の場合
                else if (pieceType == 4)
                {
                    Debug.Log("壁は壁を生成しないよ");
                }
                // それ以外
                else
                {
                    // 壁を表示
                    ActiveWall(GameSetManager.loseCount);

                    // コマが死んだとき処理呼び出し
                    pieceDead.Dead();

                    // 3になったら負ける変数を増やす
                    GameSetManager.loseCount++;

                    // ゲーム終了処理呼び出し
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
                GameObject manager = GameObject.Find("Manager");
                manager.GetComponent<GameSetManager>().GameSet();
                return true;
            }
            else
            {
                return false;
            }                             
        }


        // 手札の壁を表示する処理
        private void ActiveWall(int n)
        {
            handWall_Child = handWall.gameObject.transform.GetChild(n);
            handWall_Child.gameObject.SetActive(true);
        }
    }

}
