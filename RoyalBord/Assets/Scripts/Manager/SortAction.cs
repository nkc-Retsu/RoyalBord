using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Bridge;

namespace Manager
{
    public class SortAction : MonoBehaviour,IReceiveData
    {
        [SerializeField] private IMove iMove;
        [SerializeField] private ISummon iSummon;
        void Start()
        {

        }

        void Update()
        {

        }

        public void ReceiveData(GameObject selectObj1, GameObject selectObj2)
        {
            Vector2 pos = Vector2.zero;
            //pos = selectObj2.GetComponent<IGetPos>();
            iSummon.Summon(selectObj1, pos);
        }
    }
}
