using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Piece
{
    public class PieceMoveArea : MonoBehaviour
    {
        // 十字移動
        int[,] moveAreaDefault = new int[,] { { 1, 0 }, { 0, 1 }, { -1, 0 }, { 0, -1 } };
        public int[,] MoveAreaDefault
        {
            get
            {
                return moveAreaDefault;
            }
        }

        // 全マス移動
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
