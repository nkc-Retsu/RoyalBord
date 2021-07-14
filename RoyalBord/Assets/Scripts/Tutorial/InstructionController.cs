using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class InstructionController : MonoBehaviour
{
    private float nowPosX = 24;
    private bool RightCheck;
    private bool LeftCheck;
    [SerializeField] private GameObject LeftKey;
    [SerializeField] private GameObject RightKey;
    private Vector3 nowPos;

    

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        nowPos = this.transform.position;

        if (nowPos.x <= -13)
        {
            RightKey.SetActive(false);
        }
        else
        {
            RightKey.SetActive(true);
        }

        if (nowPos.x >= 13)
        {
            LeftKey.SetActive(false);
        }
        else
        {
            LeftKey.SetActive(true);
        }
    }

    public void SlideRight()
    {
        nowPosX += 12;

        if(nowPosX >= 24)
        {
            nowPosX = 24;
        }

        this.transform.DOMoveX(nowPosX, 0.5f);

    }

    public void SlideLeft()
    {
        nowPosX -= 12;

        if (nowPosX <= -24)
        {
            nowPosX = -24;
        }

        this.transform.DOMoveX(nowPosX, 0.5f);

    }


}
