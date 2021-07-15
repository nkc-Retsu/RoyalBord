using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Bridge;
using Piece;

public class Attack : MonoBehaviour
{
    private IAttack iAttack;
    private IDecreaseHP iDecreaseHP;
    void Start()
    {
        
    }

    public void AttackAction(GameObject selectObj1,GameObject selectObj2)
    {
        Debug.Log("çUåÇ");

        iDecreaseHP.DecreaseHP();
        // if(éÄÇÒÇæÇÁ)
        Vector2 pos = selectObj2.GetComponent<IGetPos>().GetPos();
        //iAttack.Attack(pos);
    }
}
