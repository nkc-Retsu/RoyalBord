using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class BGM : MonoBehaviour
{
    [SerializeField] AudioClip titleBGM;
    [SerializeField] AudioClip buttleBGM;
    AudioSource audioSource;
    Scene nowScene;
    float volumeFade = 1f;

    void Start()
    {
        audioSource = this.GetComponent<AudioSource>();
        DontDestroyOnLoad(this.gameObject);
    }

    void Update()
    {
        nowScene = SceneManager.GetActiveScene(); //åªç›Ç¢ÇÈÉVÅ[ÉìñºÇéÊìæ

        SceneManager.activeSceneChanged += ActiveSceneChanged;
    }

    void ActiveSceneChanged(Scene beforeScene,Scene nextScene)
    {
        if(beforeScene.name == "TitleScene" && nextScene.name == "SampleScene")
        {

            //StartCoroutine("BGMFade");
        }
    }

    IEnumerator BGMFade()
    {
        audioSource.volume -= volumeFade * Time.deltaTime;
        yield return new WaitForSeconds(3f);

        //audioSource.volume -= volumeFade * Time.deltaTime;
        //yield return new WaitForSeconds(3f);
        //audioSource.clip = buttleBGM;
        //audioSource.volume += volumeFade * Time.deltaTime;
        //yield return new WaitForSeconds(3f);
    }
}
