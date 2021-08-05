using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Piece
{
    public class PieceDamageSE : MonoBehaviour
    {
        // 攻撃された時にSEを流す処理

        [SerializeField] private AudioClip defautSE;
        [SerializeField] private AudioClip shelderSE;
        [SerializeField] private AudioClip wallSE;

        private AudioSource audioSource;


        // Start is called before the first frame update
        void Start()
        {
            // コンポーネント取得
            audioSource = GetComponent<AudioSource>();
        }


        // 攻撃された時のSE処理
        public void DamagedSE_Defaut()
        {
            // 召喚した時のSE
            audioSource.PlayOneShot(defautSE);
        }

        // 盾兵が攻撃された時のSE処理
        public void DamagedSE_Sheilder()
        {
            // 召喚した時のSE
            audioSource.PlayOneShot(shelderSE);
        }

        // 壁が攻撃された時のSE処理
        public void DamagedSE_Wall()
        {
            audioSource.PlayOneShot(wallSE);
        }
    }

}
