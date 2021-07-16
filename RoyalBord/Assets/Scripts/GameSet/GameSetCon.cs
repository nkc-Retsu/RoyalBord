using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class GameSetCon : MonoBehaviour
{
    [SerializeField] private GameObject win;
    [SerializeField] private GameObject backKey;
    [SerializeField] private GameObject cloud;
    [SerializeField] private GameObject backSquare;
    private bool backAct = false;
    private SpriteRenderer renderer;
    private SpriteRenderer backrenderer;

    // Start is called before the first frame update
    void Start()
    {
        renderer = win.GetComponent<SpriteRenderer>();
        backrenderer = backSquare.GetComponent<SpriteRenderer>();

        renderer.DOFade(1, 1);
        backrenderer.DOFade(0.45f, 1);

    }

    // Update is called once per frame
    void Update()
    {

        if (renderer.color.a == 1)
        {
            backAct = true;
        }

        if(backAct)
        {
            backKey.SetActive(true);
        }
    }

    public void OnCloudBotton()
    {
        cloud.SetActive(true);
    }


}
