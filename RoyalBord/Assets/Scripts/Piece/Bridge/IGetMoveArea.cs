using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bridge
{
    interface IGetMoveArea
    {
        // 駒が移動できる範囲を渡すインターフェース
         Vector2 GetMoveArea();
    }
}