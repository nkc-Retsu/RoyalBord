using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Bridge;

namespace Piece
{
    public class PieceCore : MonoBehaviour, IShowArea, IGetAttackArea, IGetMoveArea, IGetHP, IDecreaseHP
    {
        // 駒の基本処理


        // ScriptableObject用変数
        [SerializeField] private PieceStatus pieceStatus;

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


        private void Start()
        {
            hp = pieceStatus.hp;
        }

        private void Update()
        {
        }



        //HP処理

        //  HPを減らすインターフェース
        public int DecreaseHP(int dec)
        {
            return this.hp -= dec;
        }
        // HPを返すインターフェース
        public int GetHP()
        { 
            return hp;
        }        




        // 範囲処理

        // 攻撃範囲インターフェース
        public Vector2 GetAttackArea()
        {
            return pieceStatus.attackArea;
        }

        // 移動範囲インターフェース
        public Vector2 GetMoveArea()
        {
            return pieceStatus.moveArea;
        }

        // 移動範囲インターフェース(Inputerに渡す用)
        public Vector2 ShowArea()
        {
            return pieceStatus.moveArea;
        }
    }

}
