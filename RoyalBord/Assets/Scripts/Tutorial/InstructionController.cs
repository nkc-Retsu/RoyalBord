using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class InstructionController : MonoBehaviour
{
    private float nowPos = 24;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SlideRight()
    {
        nowPos += 12;

        if(nowPos >= 24)
        {
            nowPos = 24;
        }

        this.transform.DOMoveX(nowPos, 0.5f);

    }

    public void SlideLeft()
    {
        nowPos -= 12;

        if (nowPos <= -24)
        {
            nowPos = -24;
        }

        this.transform.DOMoveX(nowPos, 0.5f);

    }


}
