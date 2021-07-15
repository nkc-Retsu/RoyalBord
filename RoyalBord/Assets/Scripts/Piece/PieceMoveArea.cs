using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Piece
{
    public class PieceMoveArea : MonoBehaviour
    {
        // �\���ړ�
        int[,] moveAreaDefault = new int[,] { { 1, 0 }, { 0, 1 }, { -1, 0 }, { 0, -1 } };
        public int[,] MoveAreaDefault
        {
            get
            {
                return moveAreaDefault;
            }
        }

        // �S�}�X�ړ�
        int[,] moveAreaKing = new int[,] { { 1,0 }, { 1, 1 }, { 0, 1 }, { -1, 1 }, { -1, 0 }, { -1, -1 }, { 0, -1 }, { 1, -1 } };
        public int[,] MoveAreaKing
        {
            get
            {
                return moveAreaKing;
            }
        }
    }

}
