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

            // 手札の壁を取得
            handWall = GameObject.Find("Hand_Wall");
            handWall_Child = handWall.gameObject.transform.GetChild(0);


            // ScriptableObjectを代入
            hp = pieceStatus.hp;
            this.pieceType = pieceStatus.pieceType;

            // コマの名前を取得する変数
            string objName = null;

            // 取得したコマのタグ
            switch (gameObject.tag)
            {
                // 味方のコマの場合
                case "PlayerPiece":
                    switch (pieceType)
                    {
                        // 味方の手札
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
                        // 敵の手札
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

                // 味方の壁
                case "PlayerWall":

                    break;

                // 敵の壁
                case "EnemyWall":
                    break;

                // それ以外
                default:
                    break;
            }

            // 特定のゲームオブジェクトを取得
            GameObject obj = GameObject.Find(objName);
            Debug.Log(obj);

            // 選択したコマを消滅
            Destroy(obj);


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
                // プレイヤーのコマの場合
                if (gameObject.tag == "PlayerPiece")
                {
                    // コマのタイプがキングだった場合
                    if (pieceType == 0)
                    {
                        // キングが死ぬ処理呼び出し
                        kingDead.Dead();

                        // 勝敗に必要な変数(この変数が3になったら負ける)
                        GameSetManager.loseCount = 3;

                        // ゲームセット処理呼び出し
                        GameSet();

                        Debug.Log("ライフ" + GameSetManager.loseCount);
                    }
                    // コマのタイプが壁の場合
                    else if (pieceType == 4)
                    {
                        Debug.Log("壁は壁を生成しないよ");
                    }
                    // それ以外
                    else
                    {
                        // 手札の壁を使えるようにする
                        ActiveWall(GameSetManager.loseCount);

                        // コマが死ぬとき処理呼び出し
                        pieceDead.Dead();

                        // 勝敗に必要な変数(この変数が3になったら負ける)
                        GameSetManager.loseCount++;

                        // ゲームセット処理呼び出し
                        GameSet();

                        Debug.Log("ライフ" + GameSetManager.loseCount);
                    }
                }
                // コマが死んだかを返す
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
            // コマによって攻撃できる範囲を変える
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
                // コマによって移動できる範囲を変える
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
            // コマを選択した時に矢印を出す用
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
                // マネージャーを取得する
                GameObject manager = GameObject.Find("Manager");

                // コンポーネント取得
                manager.GetComponent<GameSetManager>().GameSet();

                // ゲームが終了したことを返す
                return true;
            }
            else
            {
                // まだゲームが終了していないことを返す
                return false;
            }                             
        }


        // 手札の壁を使えるようにする処理
        private void ActiveWall(int n)
        {
            handWall_Child = handWall.gameObject.transform.GetChild(n);
            handWall_Child.gameObject.SetActive(true);
        }
    }

}
