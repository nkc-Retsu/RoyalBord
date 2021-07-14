using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Piece
{
    public class KingDead : MonoBehaviour
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
            if(pieceCore.HP <= 0)
            {
                Debug.Log("キング死す");
                Debug.Log("お前の負け!!!!");
            }
        }
    }
}
