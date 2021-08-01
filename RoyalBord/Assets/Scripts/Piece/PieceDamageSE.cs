using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceDamageSE : MonoBehaviour
{
    // �U�����ꂽ����SE�𗬂�����

    [SerializeField] private AudioClip defautSE;
    [SerializeField] private AudioClip ShelderSE;

    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        // �R���|�[�l���g�擾
        audioSource = GetComponent<AudioSource>();
    }

    // �U�����ꂽ����SE����
    public void DamagedSE_Defaut()
    {    
        // ������������SE
        audioSource.PlayOneShot(defautSE);
    }

    // �������U�����ꂽ����SE����
    public void DamagedSE_Sheilder()
    {
        // ������������SE
        audioSource.PlayOneShot(ShelderSE);
    }

}
