using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bridge
{
    interface IGetAttackArea
    {
        // �U���ł���͈͂�n���C���^�[�t�F�[�X
        Vector2 GetAttackArea();
    }
}