using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Bridge;
using Photon.Pun;
using Photon.Realtime;
using Turn;


namespace Manager
{
    public class SortAction : MonoBehaviourPunCallbacks,IReceiveData
    {
        [SerializeField] GameObject field;

        private Summon summon;
        private Attack attack;
        private Move move;
        private ActionFailed actionFailed;

        private IGetAttackArea iGetAttackArea;
        private IGetMoveArea iGetMoveArea;

        int fieldData;

        private float[] posArrX = new float[] { -3.33f, -1.66f, 0f, 1.66f, 3.33f };
        private float[] posArrY = new float[] { -3.83f, -2.16f, -0.5f, 1.16f, 2.83f };

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
            if(selectObj1.tag=="EnemyPiece" || selectObj1==null)
            return;

            Vector2 pos1 = selectObj1.GetComponent<IGetPos>().GetPos();
            Vector2 pos2 = selectObj2.GetComponent<IGetPos>().GetPos();
            int pos1_x = (int)pos1.x;
            int pos1_y = (int)pos1.y;
            int pos2_x = (int)pos2.x;
            int pos2_y = (int)pos2.y;

            if (selectObj1.tag == "HandPiece" && selectObj2.tag == "Field")
            {
                int pieceType = selectObj1.GetComponent<IGetType>().GetType();

                photonView.RPC(nameof(SummonBridge), RpcTarget.Others, pieceType, 4-pos2_x, 4-pos2_y);
                summon.SummonAction(selectObj1, selectObj2);
                //SummonBridge(pieceType,pos2_x,pos2_y);
            }

            if (TurnManager.turnCount < 2) return;

            if (selectObj1.tag == "PlayerPiece")
            {
                if (selectObj2.tag == "Field")
                {
                    // 移動範囲チェック
                    int[,] moveAreaArr = selectObj1.GetComponent<IGetMoveArea>().GetMoveArea();
                    if (AreaCheck(moveAreaArr, pos1, pos2))
                    {
                        photonView.RPC(nameof(MoveBridge), RpcTarget.Others, 4-pos1_x, 4-pos1_y, 4-pos2_x, 4-pos2_y);
                        move.MoveAction(selectObj1, selectObj2);
                    }
                }
                else if (selectObj2.tag == "EnemyPiece" || selectObj2.tag=="PlayerWall" || selectObj2.tag=="EnemyWall")
                {
                    // 攻撃範囲チェック
                    int[,] attackAreaArr = selectObj1.GetComponent<IGetAttackArea>().GetAttackArea();
                    Debug.Log(attackAreaArr);
                    if (AreaCheck(attackAreaArr, pos1, pos2))
                    {
                        Debug.Log("攻撃しますよ～");
                        photonView.RPC(nameof(AttackBridge), RpcTarget.Others, 4-pos1_x, 4-pos1_y, 4-pos2_x, 4-pos2_y);
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

        [PunRPC]
        private void SummonBridge(int pieceType,int selectObj2_x, int selectObj2_y)
        {
            GameObject obj2 = RayHit(new Vector3(posArrX[selectObj2_x], posArrY[selectObj2_y], -10));
            summon.SummonAction(pieceType,obj2);
        }

        [PunRPC]
        private void MoveBridge(int selectObj1_x, int selectObj1_y, int selectObj2_x, int selectObj2_y)
        {
            GameObject obj1 = RayHit(new Vector3(posArrX[selectObj1_x], posArrY[selectObj1_y], -10));
            GameObject obj2 = RayHit(new Vector3(posArrX[selectObj2_x], posArrY[selectObj2_y], -10));

            move.MoveAction(obj1, obj2);
        }

        [PunRPC]
        private void AttackBridge(int selectObj1_x, int selectObj1_y, int selectObj2_x, int selectObj2_y)
        {
            GameObject obj1 = RayHit(new Vector3(posArrX[selectObj1_x], posArrY[selectObj1_y], -10));
            GameObject obj2 = RayHit(new Vector3(posArrX[selectObj2_x], posArrY[selectObj2_y], -10));

            attack.AttackAction(obj1, obj2);
        }

        private GameObject RayHit(Vector3 origin)
        {

            RaycastHit2D hit2d_2 = Physics2D.Raycast(origin, new Vector3(0, 0, 1));

            if (hit2d_2)
            {
                // オブジェクトを取得
                return hit2d_2.transform.gameObject;
            }
            return null;
        }
    }
}
