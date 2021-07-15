using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Bridge;

namespace Manager
{
    public class SortAction : MonoBehaviour,IReceiveData
    {
        [SerializeField] GameObject field;

        private Summon summon;
        private Attack attack;
        private Move move;
        private ActionFailed actionFailed;

        private IGetAttackArea iGetAttackArea;
        private IGetMoveArea iGetMoveArea;

        int fieldData;

        void Start()
        {
            summon = GetComponent<Summon>();
            attack = GetComponent<Attack>();
            move = GetComponent<Move>();
        }

        void Update()
        {

        }

        public void ReceiveData(GameObject selectObj1, GameObject selectObj2)
        {
            if(selectObj1.tag=="EnemyPiece")
            return;

            Vector2 pos1 = selectObj1.GetComponent<IGetPos>().GetPos();
            Vector2 pos2 = selectObj2.GetComponent<IGetPos>().GetPos();

            if (selectObj1.tag == "HandPiece" && selectObj2.tag == "Field")
            {
                summon.SummonAction(selectObj1, selectObj2);
            }


            if (selectObj1.tag == "PlayerPiece")
            {
                if (selectObj2.tag == "Field")
                {
                    // 移動範囲チェック
                    int[,] moveAreaArr = selectObj1.GetComponent<IGetMoveArea>().GetMoveArea();
                    if (AreaCheck(moveAreaArr, pos1, pos2))
                    {
                        move.MoveAction(selectObj1, selectObj2);
                    }
                }
                else if (selectObj2.tag == "EnemyPiece")
                {
                    Debug.Log("1");
                    // 攻撃範囲チェック
                    int[,] attackAreaArr = selectObj1.GetComponent<IGetAttackArea>().GetAttackArea();
                    Debug.Log(attackAreaArr);
                    if (AreaCheck(attackAreaArr, pos1, pos2))
                    {
                        Debug.Log("2");
                        attack.AttackAction(selectObj1, selectObj2);
                    }
                }
            }
        }

        private bool AreaCheck(int[,] arr,Vector2 pos1,Vector2 pos2)
        {
            for (int i = 0; i < arr.GetLength(0); ++i)
            {
                if (pos1.x + arr[i, 0] == pos2.x && pos1.y + arr[i, 1] == pos2.y)
                {
                    return true;
                }
            }
            return false;
        }

    }
}
