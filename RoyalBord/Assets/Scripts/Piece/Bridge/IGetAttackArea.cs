using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bridge
{
    interface IGetAttackArea
    {
        // 攻撃できる範囲を渡すインターフェース
        Vector2 GetAttackArea();
    }
}