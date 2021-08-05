using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Piece
{
    public class KingDead : MonoBehaviour
    {
        // キングが死んだとき処理


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
            // コルーチン呼び出し
            StartCoroutine("FadeClear");
        }

        // 透明にする処理
        IEnumerator FadeClear()
        {
            // フェードで消える
            sr.color = new Color(0f, 0f, 0f, 0.5f);

            // 2秒待つ　(こうすると結局消えるから意味なし？)
            yield return new WaitForSeconds(1.5f);

            // GameObjectのsetActiveを消す
            gameObject.SetActive(false);
        }
    }
}
