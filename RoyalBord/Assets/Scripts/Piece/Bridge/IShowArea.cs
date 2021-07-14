using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bridge
{
    interface IShowArea
    {
        // 移動と攻撃できる範囲を入力処理に渡すインターフェース
        Vector2 ShowArea();
    }
}