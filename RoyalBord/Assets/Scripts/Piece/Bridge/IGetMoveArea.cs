using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bridge
{
    interface IGetMoveArea
    {
        // ��ړ��ł���͈͂�n���C���^�[�t�F�[�X
         Vector2 GetMoveArea();
    }
}