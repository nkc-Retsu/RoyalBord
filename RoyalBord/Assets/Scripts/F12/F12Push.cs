using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class F12Push : MonoBehaviour
{
    F12Inputer f12Inputer;

    //[SerializeField] Sprite spHen;
    //SpriteRenderer spriteRenderer;

    [SerializeField] GameObject defaObj;
    [SerializeField] GameObject HenObj;
    void Start()
    {
        f12Inputer = GetComponent<F12Inputer>();
        //spriteRenderer = this.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (f12Inputer.F12Button())
        {
            //spriteRenderer.sprite = spHen;
            defaObj.SetActive(false);
            HenObj.SetActive(true);
        }
        else if(!f12Inputer.F12Button())
        {
            defaObj.SetActive(true);
            HenObj.SetActive(false);
        }
    }
}
