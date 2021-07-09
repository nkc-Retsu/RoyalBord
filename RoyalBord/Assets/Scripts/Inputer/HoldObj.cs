using Hand;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Inputer
{
    public class HoldObj : MonoBehaviour
    {
        // 左クリックで手札情報を取得する処理


        // オブジェクト取得用変数
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



        // 手札を左クリックした時に情報を取得する処理
        private void Click()
        {
            if (ClickLeft())
            {
                // クリックしたオブジェクトを取得する変数
                clickedObj = null;
                HandPiece obj = null;

                // クリックでオブジェクトを取得
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit2D hit2d = Physics2D.Raycast((Vector2)ray.origin, (Vector2)ray.direction);

                // オブジェクトを取得した時
                if (hit2d)
                {
                    // クリックしたオブジェクトのクラスを取得
                    clickedObj = hit2d.transform.gameObject;
                    obj = clickedObj.GetComponent<HandPiece>();
                }

                // 名前を表示
                Debug.Log("名前 " + obj.SendName());
            }

            
        }

        // 左クリック処理
        private bool ClickLeft()
        {
            return Input.GetMouseButtonDown(0);
        }
    }

}
