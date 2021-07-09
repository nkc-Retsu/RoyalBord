using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstructionBack : MonoBehaviour
{

    [SerializeField] private string sceneName;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SceneBack()
    {
        FadeManager.Instance.LoadScene(sceneName, 0.5f);
    }

}
