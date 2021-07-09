using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstructionManager : MonoBehaviour
{
    public string rightKey = "RightKey";
    public string leftKey = "LeftKey";


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = new Ray();
            RaycastHit2D hit = new RaycastHit2D();
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics2D.Raycast((Vector2)ray.origin, (Vector2)ray.direction))
            {
                if (hit.collider.gameObject.CompareTag(rightKey))
                {
                    Debug.Log("右にスライド");
                    hit.collider.gameObject.GetComponent<InstructionController>().SlideLeft();
                }
                else if (hit.collider.gameObject.CompareTag(leftKey))
                {
                    Debug.Log("左へスライド");
                    hit.collider.gameObject.GetComponent<InstructionController>().SlideRight();
                }


            }
        }
    }
}
