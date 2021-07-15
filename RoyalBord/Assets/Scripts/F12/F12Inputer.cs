using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HayashiF12;

public class F12Inputer : MonoBehaviour,F12IInputer
{
    public bool F12Button()
    {
        return Input.GetKey(KeyCode.F12);
    }
}
