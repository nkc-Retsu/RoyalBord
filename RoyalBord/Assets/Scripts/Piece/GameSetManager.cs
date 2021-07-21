using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Manager
{
    public class GameSetManager : MonoBehaviour
    {
        // ƒRƒ}‚ª€‚ñ‚¾”‚ğ‚Á‚Ä‚¢‚é•Ï”
        public static int loseCount;

        [SerializeField] GameObject gameSet;

        public void GameSet()
        {
            Instantiate(gameSet);
        }
    }

}
