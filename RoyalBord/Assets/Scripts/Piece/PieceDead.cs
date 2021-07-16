using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Piece
{
    public class PieceDead : MonoBehaviour
    {
        // コマが死んだとき処理

        private void Start()
        {
        }

        private void Update()
        {
        }


        // 死んだとき処理
        public void Dead()
        {
            Debug.Log(gameObject + "が死んだ!!!");
            // フェードで消える
            // 手札の壁を生成する
        }
    }
}


