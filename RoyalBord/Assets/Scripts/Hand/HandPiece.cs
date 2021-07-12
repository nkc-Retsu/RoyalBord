using Bridge;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hand
{
    public class HandPiece : MonoBehaviour, ISendName
    {
        // 手札別の名前を設定する処理

        // 手札の名前を取得する変数
        [SerializeField] private string name = null;


        // 手札情報取得用インターフェース
        public string SendName()
        {
            return name;
        }
    }

}
