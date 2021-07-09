using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickEffectDeleter : MonoBehaviour
{
    float timer = 0;
    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= 0.4f) { Destroy(this.gameObject); }
    }
}
