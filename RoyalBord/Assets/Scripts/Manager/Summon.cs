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

    private float[] posArrX = new float[] { -3.33f, -1.66f, 0f, 1.66f, 3.33f };
    private float[] posArrY = new float[] { -3.83f, -2.16f, -0.5f, 1.16f, 2.83f };



    private void Start()
    {
        iSummon = GetComponent<ISummon>();
    }

    public void SummonAction(GameObject selectObj1,GameObject selectObj2)
    {
        Debug.Log("è¢ä´");

        Vector2 pos= selectObj2.GetComponent<IGetPos>().GetPos();

        if(TurnManager.playerTurn)
        {
            //instantiate(é©ãÓ)
        }
        else
        {
            //instantiate(ìGãÓ)
        }

        //iSummon.Summon(selectObj1,pos);
    }

}
