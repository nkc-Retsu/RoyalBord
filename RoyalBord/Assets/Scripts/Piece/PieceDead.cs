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

        private float time = 0;

        private void Start()
        {
            // コンポーネント取得
            sr = GetComponent<SpriteRenderer>();
        }

        private void Update()
        {
            time += Time.deltaTime;
        }


        // 死んだとき処理
        public void Dead()
        {
            Debug.Log(gameObject + "が死んだ!!!");

            // コルーチン呼び出し
            StartCoroutine("FadeClear");
        }

        // 透明にする処理
        IEnumerator FadeClear()
        {
            time = 0f;

            // フェードで消える
            if(sr.color.a <= 0f) sr.color -= new Color(0f, 0f, 0f, 0.01f * time);

            // 2秒待つ　(こうすると結局消えるから意味なし？)
            yield return new WaitForSeconds(2);

            // GameObjectのsetActiveを消す
            gameObject.SetActive(false); 
        }
    }
}


