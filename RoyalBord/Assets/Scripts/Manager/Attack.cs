using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Bridge;


public class Attack : MonoBehaviour
{
    private IAttack iAttack;
    private IDecreaseHP iDecreaseHP;

    [SerializeField] private GameObject turnManager;
    private ITurnChange iTurnChange;

    void Start()
    {
        iTurnChange = turnManager.GetComponent<ITurnChange>();
    }

    public void AttackAction(GameObject selectObj1,GameObject selectObj2)
    {
        Debug.Log("çUåÇ");

        selectObj2.GetComponent<IDecreaseHP>().DecreaseHP();
        // if(éÄÇÒÇæÇÁ)
        Vector2 pos = selectObj2.GetComponent<IGetPos>().GetPos();
        //iAttack.Attack(pos);

        iTurnChange.TurnChange();
    }
}
