using Bridge;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Inputer
{
    public class HoldObj : MonoBehaviour
    {
        // ¶ƒNƒŠƒbƒN‚ÅèDî•ñ‚ğæ“¾‚·‚éˆ—

        private GameObject clickedObj;



        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            Click();
        }


        private void Click()
        {

            if (Input.GetMouseButtonDown(0))
            {
                clickedObj = null;

                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit2D hit2d = Physics2D.Raycast((Vector2)ray.origin, (Vector2)ray.direction);

                if (hit2d)
                {
                    clickedObj = hit2d.transform.gameObject;
                }
                Debug.Log(clickedObj);
            }

            var obj = clickedObj.gameObject.GetComponent<ISendName>();
            Debug.Log(obj.SendName());
        }
    }

}
