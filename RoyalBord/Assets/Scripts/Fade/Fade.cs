using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class Fade : MonoBehaviour
{
    [Header("次のシーンの名前")]
    [SerializeField] string nextSceneName;
    [Header("フェード時間")]
    [SerializeField] float fadeTime;

    float startPosX =  30; //初期位置
    float stopPosX  =  -8; //停止位置
    float EndPosX   = -41; //最終位置
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        transform.position = new Vector3(startPosX, 0, 0); //初期位置設定
        StartCoroutine("FadeCoroutine");
    }

    IEnumerator FadeCoroutine()
    {
        transform.DOMoveX(stopPosX, fadeTime); //初期位置から停止位置へ
        yield return new WaitForSeconds(fadeTime + 0.5f);
        SceneManager.LoadScene(nextSceneName); //次のシーンへ
        transform.DOMoveX(EndPosX, fadeTime); //停止位置から最終位置へ
        yield return new WaitForSeconds(fadeTime + 0.1f);
        Destroy(this.gameObject); //削除
    }
}
