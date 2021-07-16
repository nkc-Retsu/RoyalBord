using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class F12toCredit : MonoBehaviour
{
    [SerializeField] GameObject fadeCloud;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F12)) { fadeCloud.SetActive(true); }
    }
}
