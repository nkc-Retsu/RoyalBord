using Bridge;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Inputer
{
    public class HoldObj : MonoBehaviour, ICanInput
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


        // 手札を選んだ時にフィールド
        private bool handSelectFlg = false;
        public bool HandSelectFlg
        {
            get
            {
                return handSelectFlg;
            }
            set
            {
                handSelectFlg = value;
            }
        }



        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (!handSelectFlg)
            {
                SelectObj();
            }
        }



        // 入力可能かどうか判定する処理
        public bool CanInput(bool flg)
        {
            return flg;
        }



        // 手札を左クリックした時に情報を取得する処理
        private void SelectObj()
        {
            if (ClickLeft())
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

                    // 2回目の選択を可能にする
                    handSelectFlg = true;
                }

                // 名前を表示
                Debug.Log("select1 " + clickedObj);
            }

            
        }

        // 左クリック処理
        private bool ClickLeft()
        {
            return Input.GetMouseButtonDown(0);
        }

    }

}
