using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

        [SerializeField] GameObject king;
        [SerializeField] GameObject knight;
        [SerializeField] GameObject shield;
        [SerializeField] GameObject archer;
        [SerializeField] GameObject wall;

        [SerializeField] private int[,] fieldArr = new int[5,5] { { 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0 } };
        float[] posArrX = new float[] { -3.33f, -1.66f, 0f, 1.66f, 3.33f };
        float[] posArrY = new float[] { -3.83f, -2.16f, -0.5f, 1.16f, 2.83f };

        void Start()
        {
            Instantiate(king).transform.position = new Vector3(posArrX[0], posArrY[0], 0);
        }

        void Update()
        {
            if(Input.GetKeyDown(KeyCode.Alpha1))
            {
                Summon(2, 3, 1);
            }
        }

        public void Summon(int x,int y,int num)
        {
            fieldArr[y, x] = num;
            switch (num)
            {
                case (int)PIECE.KNIGHT:
                    Instantiate(knight).transform.position = new Vector3(posArrX[x], posArrY[y]);
                    break;

                case (int)PIECE.SHIELD:
                    Instantiate(shield).transform.position = new Vector3(posArrX[x], posArrY[y]);
                    break;

                case (int)PIECE.ARCHER:
                    Instantiate(archer).transform.position = new Vector3(posArrX[x], posArrY[y]);
                    break;

                case (int)PIECE.WALL:
                    Instantiate(wall).transform.position = new Vector3(posArrX[x], posArrY[y]);
                    break;

                default:
                    break;
            }

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
