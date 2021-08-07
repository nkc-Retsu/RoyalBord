using Bridge;
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
        public GameObject ClickObj
        {
            get
            {
                return clickedObj;
            }
            set
            {
                clickedObj = value;
            }
        }




        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }


        // 手札を左クリックした時に情報を取得する処理
        public void SelectObj()
        {
            // クリックしたオブジェクトを取得する変数
            clickedObj = null;

            // クリックでオブジェクトを取得
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit2d = Physics2D.Raycast((Vector2)ray.origin, (Vector2)ray.direction);


            // オブジェクトを取得した時
            if (hit2d)
            {
                // クリックしたオブジェクトのクラスを取得
                clickedObj = hit2d.transform.gameObject;

                // 何も取得していない時 + Fieldを選択したら早期リターン
                if (ClickObj == null || clickedObj.gameObject.tag == "Field") return;
            }
        }


        // 左クリック処理
        private bool ClickLeft()
        {
            return Input.GetMouseButtonDown(0);
        }

    }

}


