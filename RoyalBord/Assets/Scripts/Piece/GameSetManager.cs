using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Manager
{
    public class GameSetManager : MonoBehaviour
    {
        // �R�}�����񂾐��������Ă���ϐ�
        public static int loseCount;

        [SerializeField] GameObject gameSet;

        public void GameSet()
        {
            Instantiate(gameSet);
        }
    }

}
