using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstructionBack : MonoBehaviour
{

    //[SerializeField] private string sceneName;
    [SerializeField] GameObject fadeCloud;

    public void SceneBack()
    {
        fadeCloud.SetActive(true);
        //FadeManager.Instance.LoadScene(sceneName, 0.5f);
    }

}
