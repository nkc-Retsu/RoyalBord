using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceSummonSE : MonoBehaviour
{

    // ������������SE�𗬂�����

    [SerializeField] private AudioClip audioClip;

    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        // �R���|�[�l���g�擾
        audioSource = GetComponent<AudioSource>();

        // ������������SE
        audioSource.PlayOneShot(audioClip);
    }
}
