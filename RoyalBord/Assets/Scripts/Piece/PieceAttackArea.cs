using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Piece
{
    public class PieceAttackArea : MonoBehaviour
    {

        // �\���U��
        int[,] attackAreaDefault = new int[,] { { 1, 0 }, { 0, 1 }, { -1, 0 }, { 0, -1 } };
        public int[,] AttackAreaDefault { get; set; }

        // �|�U��
        int[,] attackAreaArcher = new int[,] { { 2, 0 }, { 0, 2 }, { -2, 0 }, { 0, -2 } };
        public int[,] AttackAreaArcher { get; set; }

        // �S�}�X�U��
        int[,] attackAreaKnight = new int[,] { { 0, 1 }, { 1, 1 }, { 1, 0 }, { 1, -1 }, { 0, 1 }, { -1, 1 }, { -1, 0 }, { -1, 1 } };
        public int[,] AttackAreaKnight { get; set; }
    }

}
