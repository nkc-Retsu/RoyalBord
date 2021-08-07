using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseCursorFollowObj : MonoBehaviour
{

    // オブジェクトをマウスカーソルに追従させる処理


    // 位置座標
    private Vector3 position;

    // スクリーン座標をワールド座標に変換した位置座標
    private Vector3 screenToWorldPointPositon;

    // Update is called once per frame
    void Update()
    {
        // メソッド呼び出し
        PositionFollow();
    }

    // 追従させる処理
    private void PositionFollow()
    {
        // Vector3でマウス位置座標を取得する
        position = Input.mousePosition;

        // Z軸修正
        position.z = 10f;

        // マウス位置座標をスクリーン座標からワールド座標に変換する
        screenToWorldPointPositon = Camera.main.ScreenToWorldPoint(position);

        // ワールド座標に変換されたマウス座標を代入
        gameObject.transform.position = screenToWorldPointPositon;
    }
}
