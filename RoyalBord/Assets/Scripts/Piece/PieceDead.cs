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

        private void Start()
        {
            // コンポーネント取得
            sr = GetComponent<SpriteRenderer>();
        }

        private void Update()
        {
        }


        // 死んだとき処理
        public void Dead()
        {
            Debug.Log(gameObject + "が死んだ!!!");

            sr.material.color = sr.material.color - new Color32(0,0,0,0);

            // コルーチン呼び出し
            StartCoroutine("FadeClear");
        }

        // 透明にする処理
        IEnumerator FadeClear()
        {
            for(int i = 0; i < 255; ++i)
            {
                sr.material.color = sr.material.color - new Color32(0,0,0,1);
                
                // 0.01秒待つ
                yield return new WaitForSeconds(0.0001f);
            }

            // GameObjectのsetActiveを消す
            gameObject.SetActive(false);
        }
    }
}


