using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Piece
{
    public class PieceDead : MonoBehaviour
    {
        // コマが死んだとき処理


        // クラス変数
        private SpriteRenderer sr;
        private BoxCollider2D col;

        private void Start()
        {
            // コンポーネント取得
            sr  = GetComponent<SpriteRenderer>();
            col = GetComponent<BoxCollider2D>();
        }

        private void Update()
        {
        }


        // 死んだとき処理
        public void Dead()
        {
            Debug.Log(gameObject + "が死んだ!!!");

            sr.material.color = sr.material.color - new Color32(0,0,0,0);

            col.enabled = false;

            // コルーチン呼び出し
            StartCoroutine("FadeClear");
        }

        // 透明にする処理
        IEnumerator FadeClear()
        {
            for(int i = 0; i < 255; ++i)
            {
                sr.material.color = sr.material.color - new Color32(0,0,0,5);
                
                // 0.01秒待つ
                yield return new WaitForSeconds(0.00001f);
            }

            // GameObjectのsetActiveを消す
            gameObject.SetActive(false);
        }
    }
}


