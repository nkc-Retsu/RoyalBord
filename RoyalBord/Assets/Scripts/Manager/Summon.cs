using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Turn;
using Bridge;


public class Summon : MonoBehaviour
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

    private ISummon iSummon;
    [SerializeField] private GameObject turnManager;
    private ITurnChange iTurnChange;

    private float[] posArrX = new float[] { -3.33f, -1.66f, 0f, 1.66f, 3.33f };
    private float[] posArrY = new float[] { -3.83f, -2.16f, -0.5f, 1.16f, 2.83f };

    [SerializeField] private GameObject[] redPieceArr;
    [SerializeField] private GameObject[] bluePieceArr;

    private int startSummonCount;
    private void Start()
    {
        //iSummon = GetComponent<ISummon>();
        iTurnChange = turnManager.GetComponent<ITurnChange>();

        startSummonCount = 0;

        Instantiate(redPieceArr[0]).transform.position= new Vector3(posArrX[0], posArrY[0], -1);
        Instantiate(bluePieceArr[0]).transform.position= new Vector3(posArrX[4], posArrY[4], -1);
    }

    public void SummonAction(GameObject selectObj1,GameObject selectObj2)
    {
        Debug.Log("è¢ä´");

        Vector2 pos= selectObj2.GetComponent<IGetPos>().GetPos();

        if(TurnManager.playerTurn)
        {
            int pieceType = selectObj1.GetComponent<IGetType>().GetType();
            GameObject summonObj = Instantiate(redPieceArr[pieceType]);
            summonObj.transform.position=new Vector3(posArrX[(int)pos.x], posArrY[(int)pos.y],-1);
            summonObj.GetComponent<ISetPos>().SetPos(pos);
        }
        else
        {
            int pieceType = selectObj1.GetComponent<IGetType>().GetType();
            GameObject summonObj = Instantiate(bluePieceArr[pieceType]);
            summonObj.transform.position = new Vector3(posArrX[(int)pos.x], posArrY[(int)pos.y],-1);
            summonObj.GetComponent<ISetPos>().SetPos(pos);
        }

        //iSummon.Summon(selectObj1,pos);

        if (TurnManager.turnCount == 0 || TurnManager.turnCount == 1)
        {
            if (TurnManager.playerTurn)
            {
                startSummonCount++;
            }

            if (startSummonCount < 3)
            {
                return;
            }

        }
        Debug.Log("ok");
        iTurnChange.TurnChange();

    }

    public void SummonAction(int pieceType, GameObject selectObj2)
    {
        Debug.Log("è¢ä´");

        Vector2 pos = selectObj2.GetComponent<IGetPos>().GetPos();

        if (TurnManager.playerTurn)
        {
            GameObject summonObj = Instantiate(redPieceArr[pieceType]);
            summonObj.transform.position = new Vector3(posArrX[(int)pos.x], posArrY[(int)pos.y], -1);
            summonObj.GetComponent<ISetPos>().SetPos(pos);
        }
        else
        {
            GameObject summonObj = Instantiate(bluePieceArr[pieceType]);
            summonObj.transform.position = new Vector3(posArrX[(int)pos.x], posArrY[(int)pos.y], -1);
            summonObj.GetComponent<ISetPos>().SetPos(pos);
        }

        //if(TurnManager.turnCount==0 || TurnManager.turnCount == 1)
        //{
        //    if (TurnManager.playerTurn)
        //    {
        //        startSummonCount++;
        //    }

        //    if (startSummonCount < 3)
        //    {
        //        return;
        //    }

        //}
        //Debug.Log("ok");
        //iTurnChange.TurnChange();

        //iSummon.Summon(selectObj1,pos);
    }

}
