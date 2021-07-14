using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Piece
{
    public class PieceDead : MonoBehaviour
    {
        private PieceCore pieceCore;

        private void Start()
        {
            pieceCore = GetComponent<PieceCore>();
        }

        private void Update()
        {
            Dead();
        }

        private void Dead()
        {
            if (pieceCore.HP <= 0)
            {
                Debug.Log(gameObject + "‚ªŽ€‚ñ‚¾!!!");
            }
        }
    }

}
