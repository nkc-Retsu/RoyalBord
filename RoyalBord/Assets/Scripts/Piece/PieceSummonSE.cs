using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceSummonSE : MonoBehaviour
{

    // 召喚した時にSEを流す処理

    [SerializeField] private AudioClip audioClip;

    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        // コンポーネント取得
        audioSource = GetComponent<AudioSource>();

        // 召喚した時のSE
        audioSource.PlayOneShot(audioClip);
    }
}
