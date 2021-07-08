using Bridge;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hand
{
    public class HandPiece : MonoBehaviour, ISendName
    {
        // 手札別の名前を設定する処理

        [SerializeField] private string name = "";

        public string SendName()
        {
            return name;
        }
    }

}
