using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class BGM : MonoBehaviour
{
    [SerializeField] AudioClip titleBGM;
    [SerializeField] AudioClip buttleBGM;
    AudioSource audioSource;
    float volumeFadeTime = 1f;

    int sceneJudge = 1; //1ならtitleBGM  -1ならbuttleBGM
    public static bool fadeStartFlg = false; //trueになったらフェード開始


    void Start()
    {
        audioSource = this.GetComponent<AudioSource>();
        DontDestroyOnLoad(this.gameObject);
    }


    void Update()
    {

        if(fadeStartFlg == true)
        {
            sceneJudge *= -1;
            StartCoroutine("BGMFade");
            Debug.Log("tootta");

            fadeStartFlg = false;
        }
    }


    //void ActiveSceneChanged(Scene beforeScene,Scene nextScene)
    //{
    //    if(beforeScene.name == "TitleScene" && nextScene.name == "SampleScene")
    //    {

    //        //StartCoroutine("BGMFade");
    //    }
    //}

    public IEnumerator BGMFade()
    {
        audioSource.DOFade(0,volumeFadeTime);
        yield return new WaitForSeconds(volumeFadeTime + 0.01f);

        //ここでシーンチェンジ

        if (sceneJudge == -1) { audioSource.clip = buttleBGM; }
        else                  { audioSource.clip =  titleBGM; }
        audioSource.Play();

        audioSource.DOFade(0.2f, volumeFadeTime);
        yield return new WaitForSeconds(volumeFadeTime + 0.01f);
    }
}
