using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Bridge;

public class FieldTile : MonoBehaviour,IGetPos
{
    SpriteRenderer sr;

    [SerializeField] Vector2 pos;

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        sr.color = new Vector4(255, 255, 255, 0);
    }

    public Vector2 GetPos()
    {
        return pos;
    }

    private void OnMouseEnter()
    {
        sr.color = new Color32(255, 255, 255, 150);
    }

    private void OnMouseExit()
    {
        sr.color = new Color32(0, 0, 0, 0);
    }

}
