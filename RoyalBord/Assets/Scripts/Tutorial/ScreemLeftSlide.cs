using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using DG.Tweening;

public class ScreemLeftSlide : MonoBehaviour
{
    [SerializeField] private GameObject Slider;

    private float nowPos = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            nowPos -= 5;

            if(Slider.transform.position.x < 0)
            {
                Slider.transform.position = Vector3.zero;
            }
        }
    }

    public void OnClickLeftCursor()
    {
            Debug.Log("ƒXƒ‰ƒCƒh");
            Slider.transform.DOLocalMoveX(nowPos, 0.5f);
    }

}
