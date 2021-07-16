using Hand;
using Turn;
using Bridge;
using Piece;
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


        // クラス変数
        private SendData sendData;
        private HoldObj holdObj;
        private GameObject pieceChild;
        private HandPieceCore handPieceCore;
        private GameObject MousehandPiece;


        // 選択可能フラグ
        private bool selecrFlg = false;


        // Start is called before the first frame update
        void Start()
        {
            // コンポーネント取得
            sendData = GetComponent<SendData>();
            holdObj = GetComponent<HoldObj>();
        }

        // Update is called once per frame
        void Update()
        {
            // 入力受付
            if (!TurnManager.playerTurn) return;

            // メソッド呼び出し
            InputClick();
        }



        // クリック処理
        private void InputClick()
        {
            // 選択可能フラグがtrueの時 (2回目)
            if (selecrFlg && holdObj.ClickObj.gameObject.tag == "HandPiece" || selecrFlg && holdObj.ClickObj.gameObject.tag == "PlayerPiece")
            {
                if (ClickLeft())
                {

                    // キャラ選択 or フィールド選択
                    SelectObj();

                    if (holdObj.ClickObj.gameObject.tag == "PlayerPiece")
                    {
                        if (ClickObj.gameObject.tag == "Field" || ClickObj.gameObject.tag == "EnemyPiece")
                        {
                            // 矢印のオブジェクトを取得
                            pieceChild = holdObj.ClickObj.transform.GetChild(0).gameObject;

                            // 矢印の表示を消す
                            pieceChild.gameObject.SetActive(false);

                        }
                    }

                    // 何も取得していない時は早期リターン
                    if (clickedObj == null)
                    {
                        return;
                    }
                    // 同じ駒を選択した場合は選択解除
                    else if (clickedObj == holdObj.ClickObj)
                    {
                        if (clickedObj.gameObject.tag == "HandPiece") return;

                        // 矢印の表示を消す
                        pieceChild.gameObject.SetActive(false);

                        // 取得したオブジェクトの中身を空にする
                        clickedObj = null;
                        holdObj.ClickObj = null;

                        // 1回目の選択に戻す
                        selecrFlg = false;
                    }

                    // フラグを変更
                    selecrFlg = false;

                    // 情報を送る
                    sendData.Send(holdObj.ClickObj, ClickObj);

                }
            }
            // 選択可能フラグがfalseの時 (1回目)
            else
            {
                if (ClickLeft())
                {
                    // キャラ選択
                    holdObj.SelectObj();

                    // 何も取得していない時 + Fieldを選択したら早期リターン
                    if (holdObj.ClickObj == null || holdObj.ClickObj.gameObject.tag == "Field") return;
                    else if (holdObj.ClickObj.gameObject.tag == "PlayerPiece")
                    {
                        // 矢印のオブジェクトを取得
                        pieceChild = holdObj.ClickObj.transform.GetChild(0).gameObject;

                        // 矢印の表示
                        pieceChild.gameObject.SetActive(true);
                    }
                    else if (holdObj.gameObject.tag == "HandPiece")
                    {
                        //handPieceCore = holdObj.GetComponent<HandPieceCore>();
                        //MousehandPiece = holdObj.ClickObj; 
                    }

                    // フラグを変更
                    selecrFlg = true;
                }
            }

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

                // 何も取得していない時は早期リターン
                if (clickedObj == null) return;

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






