using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Piece
{
    [CreateAssetMenu]
    public class PieceStatus : ScriptableObject
    {
        // ��̃X�e�[�^�X���Ǘ����鏈�� 

        [SerializeField, Tooltip("�R�}�̎��")]     public int pieceType  = default;
        [SerializeField, Tooltip("HP")] �@�@�@�@�@�@public int hp �@�@�@  = default;
        [SerializeField, Tooltip("�U���ł���͈�")] public int attackArea = default;
        [SerializeField, Tooltip("�ړ��ł���͈�")] public int moveArea   = default;
    }

}
