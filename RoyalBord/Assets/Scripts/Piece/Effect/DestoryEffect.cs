using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoryEffect : MonoBehaviour
{
    // 生成されたエフェクトを消滅させる処理

    private void Start()
    {
        Destroy(gameObject,0.3f);
    }
}
