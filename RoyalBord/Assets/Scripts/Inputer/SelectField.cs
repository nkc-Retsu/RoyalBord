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

        [SerializeField] private GameObject knightSpriteObj;
        [SerializeField] private GameObject sheilderSpriteObj;
        [SerializeField] private GameObject archerSpriteObj;
        [SerializeField] private GameObject wallSpriteObj;

        private GameObject cursurObj;


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
        private SendData      sendData;
        private HoldObj       holdObj;
        private GameObject    pieceChild;
        private HandPieceCore handPieceCore;
        private GameObject    MousehandPiece;


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
            if (!TurnManager.inputFlg) return;

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
                    Debug.Log("2回目");


                    // キャラ選択 or フィールド選択
                    SelectObj();

                    HandPieceDestroy();

                    // 1回目の選択が味方のコマの場合
                    if (holdObj.ClickObj.gameObject.tag == "PlayerPiece")
                    {
                        // コマの矢印を非表示
                        pieceChild.gameObject.SetActive(false);
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

                    Debug.Log("1回目");

                    // キャラ選択
                    holdObj.SelectObj();

                    HandPieceGenerator();

                    // 何も取得していない時 + Fieldを選択したら早期リターン
                    if (holdObj.ClickObj == null || holdObj.ClickObj.gameObject.tag == "Field") return;
                    else if (holdObj.ClickObj.gameObject.tag == "PlayerPiece")
                    {
                        // 矢印のオブジェクトを取得
                        pieceChild = holdObj.ClickObj.transform.GetChild(0).gameObject;

                        // 矢印の表示
                        pieceChild.gameObject.SetActive(true);
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

            }

        }


        // 左クリック処理
        private bool ClickLeft()
        {
            return Input.GetMouseButtonDown(0);
        }



        // 手札をクリックした時にカーソルに追従するオブジェクトを生成する処理
        private void HandPieceGenerator()
        {
            switch (holdObj.ClickObj.name)
            {
                case "HandPiece_Knight":
                    cursurObj = Instantiate(knightSpriteObj);
                    break;
                case "HandPiece_Shielder":
                    cursurObj = Instantiate(sheilderSpriteObj);
                    break;
                case "HandPiece_Archer":
                    cursurObj = Instantiate(archerSpriteObj);
                    break;
                case "Hand_WallPiece":
                    cursurObj = Instantiate(wallSpriteObj);
                    break;
                case "Hand_WallPiece (1)":
                    cursurObj = Instantiate(wallSpriteObj);
                    break;
                case "Hand_WallPiece (2)":
                    cursurObj = Instantiate(wallSpriteObj);
                    break;

            }
        }


        private void HandPieceDestroy()
        {
            switch (holdObj.ClickObj.name)
            {
                case "HandPiece_Knight":
                    cursurObj.gameObject.SetActive(false);
                    break;
                case "HandPiece_Shielder":
                    cursurObj.gameObject.SetActive(false);
                    break;
                case "HandPiece_Archer":
                    cursurObj.gameObject.SetActive(false);
                    break;
                case "Hand_WallPiece":
                    cursurObj.gameObject.SetActive(false);
                    break;
                case "Hand_WallPiece (1)":
                    cursurObj.gameObject.SetActive(false);
                    break;
                case "Hand_WallPiece (2)":
                    cursurObj.gameObject.SetActive(false);
                    break;

            }
        }

    }



}






