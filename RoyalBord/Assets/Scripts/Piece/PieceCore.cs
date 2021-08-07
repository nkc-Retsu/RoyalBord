using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Bridge;
using Manager;

namespace Piece
{
    public class PieceCore : MonoBehaviour, IShowArea, IGetAttackArea, IGetMoveArea, IGetHP, IDecreaseHP, IGetPos, IGetType, ISetPos, IGameSet
    {
        // 駒の基本処理


        // ScriptableObject用変数
        [SerializeField] private PieceStatus pieceStatus;

        // 盾兵と壁のヒビのSpriteを取得
        [SerializeField] private Sprite shieldCrack_Player;
        [SerializeField] private Sprite shieldCrack_Enemy;
        [SerializeField] private Sprite wallCrack;

        // HandWall変数
        private GameObject handWall;
        private Transform handWall_Child;

        // EnemyHandWall変数
        private GameObject enemyHandWall;
        private Transform enemyHandWall_Child;

        // クラス変数
        private SpriteRenderer sr;
        private PieceAttackArea pieceAttackArea;
        private PieceMoveArea pieceMoveArea;
        private PieceDead pieceDead;
        private KingDead kingDead;
        private PieceDamageSE pieceDamageSE;
        private PieceEffectDirector pieceEffectDirector;

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
        private Vector2 piecePos = new Vector2(0f, 0f);

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


        // 味方の壁手札表示用
        private static int playerWallCount = 0;

        // 敵の壁手札表示用変数
        private static int enemyWallCount = 0;



        // 最初に行う処理
        private void Start()
        {
            // コンポーネント取得
            sr                  = GetComponent<SpriteRenderer>();
            pieceAttackArea     = GetComponent<PieceAttackArea>();
            pieceMoveArea       = GetComponent<PieceMoveArea>();
            pieceDead           = GetComponent<PieceDead>();
            kingDead            = GetComponent<KingDead>();
            pieceDamageSE       = GetComponent<PieceDamageSE>();
            pieceEffectDirector = GetComponent<PieceEffectDirector>();


            // 手札の壁取得
            handWall = GameObject.Find("Hand_Wall");
            handWall_Child = handWall.gameObject.transform.GetChild(0);

            // 敵の手札の壁取得
            enemyHandWall = GameObject.Find("Enemy_Hand_Wall");
            enemyHandWall_Child = enemyHandWall.gameObject.transform.GetChild(0);


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

                // 手札の壁を非表示にする(味方)
                case "PlayerWall":
                    ActivePlayerWall(playerWallCount, false);
                    playerWallCount--;
                    break;

                // 手札の壁を非表示にする(敵)
                case "EnemyWall":
                    ActiveEnemyWall(enemyWallCount, false);
                    enemyWallCount--;
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



        // ----- HP処理 -----

        //  HPを減らすインターフェース処理
        public bool DecreaseHP()
        {
            // hpをマイナス
            hp--;

            // コマが死んだ時処理
            if (hp <= 0)
            {
                switch (gameObject.tag)
                {
                    // 味方のコマの場合
                    case "PlayerPiece":
                        PlayerPieceDead();
                        Debug.Log("味方のコマ");
                        return true;

                    // 敵の駒の場合
                    case "EnemyPiece":
                        EnemyPieceDead();
                        Debug.Log("敵のコマ");
                        return true;

                    // それ以外
                    default:
                        pieceDamageSE.DamagedSE_Wall();       // SE再生
                        pieceEffectDirector.EffectGenerator();// エフェクト生成
                        pieceDead.Dead();
                        Debug.Log("それ以外");
                        break;
                }

            }
            // 壁と盾兵にヒビをいれる
            else if (hp == 1)
            {
                switch (gameObject.tag)
                {
                    // 味方の場合
                    case "PlayerPiece":
                        pieceDamagedClack(shieldCrack_Player);// sprite変更
                        pieceDamageSE.DamagedSE_Sheilder();   // SE再生
                        pieceEffectDirector.EffectGenerator();// エフェクト生成


                        break;

                    // 敵の場合
                    case "EnemyPiece":
                        pieceDamagedClack(shieldCrack_Enemy); // sprite変更
                        pieceDamageSE.DamagedSE_Sheilder();   // SE再生
                        pieceEffectDirector.EffectGenerator();// エフェクト生成

                        break;

                    // 味方の壁の場合
                    case "PlayerWall":
                        pieceDamagedClack(shieldCrack_Player);// sprite変更
                        pieceDamageSE.DamagedSE_Wall();       // SE再生
                        pieceEffectDirector.EffectGenerator();// エフェクト生成
                        break;

                    // 敵の壁の場合
                    case "EnemyWall":
                        pieceDamagedClack(shieldCrack_Enemy);// sprite変更
                        pieceDamageSE.DamagedSE_Wall();      // SE再生
                        pieceEffectDirector.EffectGenerator();// エフェクト生成
                        break;

                    // それ以外
                    default:
                        break;
                }
            }
            return false;
        }

        // HPを返すインターフェース
        public int GetHP()
        {
            return hp;
        }



        // ----- ダメージ処理 -----

        // 味方のコマが死んだとき処理
        private void PlayerPieceDead()
        {
            // キングの場合
            if (pieceType == 0)
            {
                // SE再生
                pieceDamageSE.DamagedSE_Defaut();

                // エフェクト生成
                pieceEffectDirector.EffectGenerator();

                // キングが死んだとき処理呼び出し
                kingDead.Dead();

                Debug.Log("味方のキング死亡");

                // 3になったら負ける変数を増やす
                GameSetManager.playerLoseCount = 3;

                // 壁表示変数を増やす(味方用)
                playerWallCount = 3;

                // ゲーム終了処理呼び出し
                GameSet();

                Debug.Log("味方の" + "ライフ" + GameSetManager.playerLoseCount);
            }
            // 壁の場合
            else if (pieceType == 4)
            {
                // SE再生
                pieceDamageSE.DamagedSE_Wall();

                // エフェクト生成
                pieceEffectDirector.EffectGenerator();

            }
            else if(pieceType == 2)
            {
                // SE再生
                pieceDamageSE.DamagedSE_Sheilder();

                // エフェクト生成
                pieceEffectDirector.EffectGenerator();


                // コマが死んだとき処理呼び出し
                pieceDead.Dead();

                // 3になったら負ける変数を増やす
                GameSetManager.playerLoseCount++;

                // 壁表示変数を増やす(味方用)
                playerWallCount++;

                // 壁を表示
                ActivePlayerWall(playerWallCount, true);

                //ゲーム終了処理呼び出し
                GameSet();

                Debug.Log("味方の" + "ライフ" + GameSetManager.playerLoseCount);

            }
            // それ以外
            else
            {
                // SE再生
                pieceDamageSE.DamagedSE_Defaut();

                // エフェクト生成
                pieceEffectDirector.EffectGenerator();

                // コマが死んだとき処理呼び出し
                pieceDead.Dead();

                // 3になったら負ける変数を増やす
                GameSetManager.playerLoseCount++;

                // 壁表示変数を増やす(味方用)
                playerWallCount++;

                // 壁を表示
                ActivePlayerWall(playerWallCount, true);

                //ゲーム終了処理呼び出し
                GameSet();

                Debug.Log("味方の" + "ライフ" + GameSetManager.playerLoseCount);

            }
        }

        // 敵のコマが死んだとき処理
        private void EnemyPieceDead()
        {
            // キングの場合
            if (pieceType == 0)
            {
                // SE再生
                pieceDamageSE.DamagedSE_Defaut();

                // エフェクト生成
                pieceEffectDirector.EffectGenerator();

                // キングが死んだとき処理呼び出し
                kingDead.Dead();

                // 3になったら負ける変数を増やす
                GameSetManager.enemyLoseCount = 3;

                // 壁表示変数を増やす(敵用)
                enemyWallCount = 3;

                Debug.Log("敵のキング死亡");

                // ゲーム終了処理呼び出し
                GameSet();

            }
            // 壁の場合
            else if (pieceType == 4)
            {
                // SE再生
                pieceDamageSE.DamagedSE_Wall();

                // エフェクト生成
                pieceEffectDirector.EffectGenerator();

            }
            // それ以外
            else
            {
                // SE再生
                pieceDamageSE.DamagedSE_Defaut();

                // エフェクト生成
                pieceEffectDirector.EffectGenerator();

                // コマが死んだとき処理呼び出し
                pieceDead.Dead();

                // 敵の手札壁表示用変数
                GameSetManager.enemyLoseCount++;

                // 壁表示変数を増やす(敵用)
                enemyWallCount++;

                // 壁を表示
                ActiveEnemyWall(enemyWallCount, true);

                //ゲーム終了処理呼び出し
                GameSet();

            }

        }

        // 壁と盾兵のスプライトを変更する処理(攻撃されたらヒビ入る)
        private void pieceDamagedClack(Sprite sprite)
        {
            if (pieceType == 2)
            {
                // 画像を変更
                sr.sprite = sprite;

            }
            else if (pieceType == 4)
            {
                // 画像を変更
                sr.sprite = wallCrack;
            }

        }



        // ----- Mangerに送る情報処理 -----

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
            if (GameSetManager.playerLoseCount >= 3 || GameSetManager.enemyLoseCount >= 3)
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




        // ----- 手札壁表示処理 -----

        // 手札の壁を表示する処理
        private void ActivePlayerWall(int n, bool activeFlg)
        {
            handWall_Child = handWall.gameObject.transform.GetChild(n);
            handWall_Child.gameObject.SetActive(activeFlg);
        }


        // 敵の手札の壁を表示(引数になんの値を入れるのか)
        private void ActiveEnemyWall(int n, bool activeFlg)
        {
            Debug.Log("敵壁表示");
            enemyHandWall_Child = enemyHandWall.gameObject.transform.GetChild(n);
            enemyHandWall_Child.gameObject.SetActive(activeFlg);
        }
    }

}
