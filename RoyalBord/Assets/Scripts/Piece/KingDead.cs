using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Piece
{
    public class KingDead : MonoBehaviour
    {
        // キングが死んだとき処理

        private void Start()
        {
        }

        private void Update()
        {
        }


        // 死んだとき処理
        public void Dead()
        {
            Debug.Log("キング死す");
            // フェードで消える
        }
    }
}
