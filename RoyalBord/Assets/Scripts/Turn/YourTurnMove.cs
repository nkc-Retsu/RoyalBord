using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class YourTurnMove : MonoBehaviour
{
    const float startPos = 17; //初期位置
    const float centerPos = 0; //中間位置
    const float backPos = 1.7f; //戻り位置
    const float endPos = -16; //最終位置
    void Start()
    {
        transform.position = new Vector3(startPos, 0, 0);
        StartCoroutine("Move");
    }

    IEnumerator Move()//動き DOTween神
    {
        transform.DOMoveX(centerPos, 1);
        yield return new WaitForSeconds(1.01f);
        transform.DOMoveX(backPos, 0.5f).SetEase(Ease.Linear);
        yield return new WaitForSeconds(0.51f);
        transform.DOMoveX(endPos, 0.3f).SetEase(Ease.OutCirc);
        yield return new WaitForSeconds(0.31f);
        Destroy(this.gameObject);
    }
}
