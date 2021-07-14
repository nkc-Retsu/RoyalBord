using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Piece
{
    [CreateAssetMenu]
    public class PieceStatus : ScriptableObject
    {
        // 駒のステータスを管理する処理

        [SerializeField, Tooltip("HP")] 　　　　　　public int hp 　　　　　  = default;
        [SerializeField, Tooltip("攻撃できる範囲")] public Vector2 attackArea = default;
        [SerializeField, Tooltip("移動できる範囲")] public Vector2 moveArea   = default;
    }

}
