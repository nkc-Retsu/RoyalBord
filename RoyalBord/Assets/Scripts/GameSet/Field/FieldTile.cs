using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Bridge;

public class FieldTile : MonoBehaviour,IGetPos
{
    SpriteRenderer sr;

    [SerializeField] Vector2 pos;

    private bool colorFlg = true;

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
        if(colorFlg) sr.color = new Color32(255, 255, 255, 150);
    }

    private void OnMouseExit()
    {
        if (colorFlg) sr.color = new Color32(0, 0, 0, 0);
    }

    private void ColorRedField()
    {
        sr.color = new Color32(255, 0, 0, 160);
    } 


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "AttackZone")
        {
            ColorRedField();
            colorFlg = false;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        colorFlg = true;
        OnMouseExit();
<<<<<<< HEAD
        
=======
>>>>>>> 4b8ea8fadf354f38e12bdaeb4796629492b2f9c0
    }
}
