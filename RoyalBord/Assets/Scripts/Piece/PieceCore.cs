using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Bridge;

namespace Piece
{
    public class PieceCore : MonoBehaviour, IShowArea, IGetAttackArea, IGetMoveArea, IGetHP, IDecreaseHP, IGetPos,IGetType,ISetPos
    {
        // 駒の基本処理


        // ScriptableObject用変数
        [SerializeField] private PieceStatus pieceStatus;

        // クラス変数
        private PieceAttackArea pieceAttackArea;
        private PieceMoveArea   pieceMoveArea;

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

        private Vector2 piecePos = new Vector2(0f,0f) ;

        private int pieceType;

        private void Start()
        {
            pieceAttackArea = GetComponent<PieceAttackArea>();
            pieceMoveArea   = GetComponent<PieceMoveArea>();

            hp = pieceStatus.hp;
            this.pieceType = pieceStatus.pieceType;
        }
        private void Update()
        {
        }



        //HP処理

        //  HPを減らすインターフェース
        public bool DecreaseHP()
        {
            hp--;
            if (hp <= 0)
            {
                Debug.Log("死ぬメソッド呼び出し");
                return true;
            }
            return false;
        }
        // HPを返すインターフェース
        public int GetHP()
        { 
            return hp;
        }        




        // 範囲処理

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
            return null;
        }

        public Vector2 GetPos()
        {
            return piecePos;
        }

        int IGetType.GetType()
        {
            return pieceType;
        }

        public void SetPos(Vector2 pos)
        {
            piecePos = pos;
        }
    }

}
