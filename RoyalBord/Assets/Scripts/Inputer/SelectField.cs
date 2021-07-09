using Bridge;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Inputer
{
    public class SelectField : MonoBehaviour
    {
        // フィールド情報を取得する処理


        // オブジェクト取得用変数
        private GameObject clickedObj;


        // クラス変数
        private HoldObj holdObj;
        private SendData sendData;


        // Start is called before the first frame update
        void Start()
        {
            holdObj  = GetComponent<HoldObj>();
            sendData = GetComponent<SendData>();
        }

        // Update is called once per frame
        void Update()
        {
            // 1回目の選択がされている時
            if (holdObj.HandSelectFlg)
            {
                SelectObj();
            }
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
                    holdObj.HandSelectFlg = false;

                    sendData.Send(holdObj.ClickObj, clickedObj);
                }

                // 名前を表示
                Debug.Log("select2 " + clickedObj);
            }


        }

        // 左クリック処理
        private bool ClickLeft()
        {
            return Input.GetMouseButtonDown(0);
        } 
    }

}
