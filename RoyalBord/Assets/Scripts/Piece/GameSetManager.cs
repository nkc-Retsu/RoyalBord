using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Manager
{
    public class GameSetManager : MonoBehaviour
    {
        // コマが死んだ数を持っている変数
        public static int loseCount;

        [SerializeField] GameObject gameSet;

        public void GameSet()
        {
            Instantiate(gameSet);
        }
    }

}
