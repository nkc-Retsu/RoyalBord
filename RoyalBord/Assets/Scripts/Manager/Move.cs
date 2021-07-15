using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Bridge;
using DG.Tweening;

public class Move : MonoBehaviour
{
    private IMove iMove;

    private float[] posArrX = new float[] { -3.33f, -1.66f, 0f, 1.66f, 3.33f };
    private float[] posArrY = new float[] { -3.83f, -2.16f, -0.5f, 1.16f, 2.83f };

    void Start()
    {
        iMove = GetComponent<IMove>();
    }

    public void MoveAction(GameObject selectObj1,GameObject selectObj2)
    {
        Debug.Log("ˆÚ“®");

        Vector2 beforePos = selectObj2.GetComponent<IGetPos>().GetPos();
        Vector2 afterPos = selectObj2.GetComponent<IGetPos>().GetPos();
        selectObj1.transform.DOMove(new Vector3(posArrX[(int)afterPos.x], posArrY[(int)afterPos.y], -1), 0.5f);
        selectObj1.GetComponent<ISetPos>().SetPos(afterPos);

        //iMove.Move(beforePos, afterPos);
    }

}
