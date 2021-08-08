using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Batsu : MonoBehaviour
{
    [SerializeField] private GameObject photonManager;
    void Start()
    {
        
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            gameObject.SetActive(false);
            photonManager.GetComponent<Matching>().TouchUIActive(true);
        }
    }
}
