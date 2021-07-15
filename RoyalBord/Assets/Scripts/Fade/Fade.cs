using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class Fade : MonoBehaviour
{
    [Header("���̃V�[���̖��O")]
    [SerializeField] string nextSceneName;
    [Header("�t�F�[�h����")]
    [SerializeField] float fadeTime;

    float startPosX =  30; //�����ʒu
    float stopPosX  =  -8; //��~�ʒu
    float EndPosX   = -41; //�ŏI�ʒu
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        transform.position = new Vector3(startPosX, 0, 0); //�����ʒu�ݒ�
        StartCoroutine("FadeCoroutine");
    }

    IEnumerator FadeCoroutine()
    {
        transform.DOMoveX(stopPosX, fadeTime); //�����ʒu�����~�ʒu��
        yield return new WaitForSeconds(fadeTime + 0.5f);
        SceneManager.LoadScene(nextSceneName); //���̃V�[����
        transform.DOMoveX(EndPosX, fadeTime); //��~�ʒu����ŏI�ʒu��
        yield return new WaitForSeconds(fadeTime + 0.1f);
        Destroy(this.gameObject); //�폜
    }
}
