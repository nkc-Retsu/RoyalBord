using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Bridge;
using Turn;

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

        // フィールド配列
        [SerializeField] private int[,] fieldArr = new int[5,5] { { 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0 } };
        // 座標指定
        private float[] posArrX = new float[] { -3.33f, -1.66f, 0f, 1.66f, 3.33f };
        private float[] posArrY = new float[] { -3.83f, -2.16f, -0.5f, 1.16f, 2.83f };

        private ITurnChange iTurnChange;

        void Start()
        {
            iTurnChange = GetComponent<ITurnChange>();
        }

        void Update()
        {
            // デバッグ用
            if (Input.GetKeyDown(KeyCode.Space))
            {
                for (int i = 0; i < 5; ++i)
                {
                    Debug.Log(fieldArr[i, 0] + " " + fieldArr[i, 1] + " " + fieldArr[i, 2] + " " + fieldArr[i, 3] + " " + fieldArr[i, 4]);
                }
            }
        }

        public void Summon(GameObject piece, Vector2 pos)
        {
            fieldArr[(int)pos.y, (int)pos.x] = (TurnManager.playerTurn) ? 1 : 2;
        }

        public void Move(Vector2 beforePos,Vector2 afterPos)
        {
            fieldArr[(int)beforePos.y, (int)beforePos.x] = 0;
            // 自ターンなら1(自キャラ)、相手ターンなら2(相手キャラ)
            fieldArr[(int)afterPos.y, (int)afterPos.x] = (TurnManager.playerTurn) ? 1 : 2;
        }

        public void Attack(Vector2 pos)
        {
            fieldArr[(int)pos.y, (int)pos.x] = 0;
        }

        IEnumerator TurnChangeDelay()
        {
            yield return new WaitForSeconds(3f);

            iTurnChange.TurnChange();
        }
    }
}
