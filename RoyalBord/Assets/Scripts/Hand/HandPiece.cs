using Bridge;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hand
{
    public class HandPiece : MonoBehaviour, ISendName
    {
        // èD•Ê‚Ì–¼‘O‚ğİ’è‚·‚éˆ—

        [SerializeField] private string name = "";

        public string SendName()
        {
            return name;
        }
    }

}
