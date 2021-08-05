using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceEffectDirector : MonoBehaviour
{
    // エフェクトを生成する処理

    [Header("数字によって生成するエフェクトが変わるよ")]
    [SerializeField] private int effectSelectNum;

    // エフェクトオブジェクト用変数
    [SerializeField,Tooltip("0")] private GameObject KingDamagedEffect;     // キングがダメージを受けた時のエフェクト
    [SerializeField,Tooltip("1")] private GameObject defaultDamagedEffect;  // コマがダメージを受けた時のエフェクト
    [SerializeField,Tooltip("2")] private GameObject SheilderDamagedEffect; // シールダーがダメージを受けた時のエフェクト
    [SerializeField,Tooltip("3")] private GameObject WallDamagedEffect;     // 壁がダメージを受けた時のエフェクト


    // 数字によって生成するエフェクトを変更する処理
    public void EffectGenerator()
    {
        switch (effectSelectNum)
        {
            case 0:
                Instantiate(KingDamagedEffect).transform.position = transform.position;
                break;
            case 1:
                Instantiate(defaultDamagedEffect).transform.position = transform.position;
                break;
            case 2:
                Instantiate(SheilderDamagedEffect).transform.position = transform.position;
                break;
            case 3:
                Instantiate(WallDamagedEffect).transform.position = transform.position;
                break;
        }
    }
    
}
