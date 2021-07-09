using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Bridge;

namespace Field
{
    public class FieldData : MonoBehaviour,ISummon,IMove,IAttack
    {
        enum PIECE
        {
            KING,
            KNIGHT,
            SHIELD,
            ARCHER,
            WALL,
            NUM
        }

        //// 駒オブジェクト
        //[SerializeField] GameObject king;
        //[SerializeField] GameObject knight;
        //[SerializeField] GameObject shield;
        //[SerializeField] GameObject archer;
        //[SerializeField] GameObject wall;

        // フィールド配列
        [SerializeField] private int[,] fieldArr = new int[5,5] { { 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0 } };
        // 座標指定
        float[] posArrX = new float[] { -3.33f, -1.66f, 0f, 1.66f, 3.33f };
        float[] posArrY = new float[] { -3.83f, -2.16f, -0.5f, 1.16f, 2.83f };

        void Start()
        {

        }

        void Update()
        {

        }

        public void Summon(GameObject piece, Vector2 pos)
        {
            Instantiate(piece).transform.position = new Vector3(posArrX[(int)pos.x], posArrY[(int)pos.y]);
            fieldArr[(int)pos.y, (int)pos.x] = 1;

        }

        public void Move(int before_x,int before_y,int after_x,int after_y,int num)
        {
            fieldArr[before_y, before_x] = 0;

            fieldArr[after_y, after_x] = num;

        }

        public void Attack(int x,int y)
        {
            fieldArr[y, x] = 0;
        }
    }
}
