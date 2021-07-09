using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Bridge;

namespace Manager
{
    public class SortAction : MonoBehaviour,IReceiveData
    {
        [SerializeField] GameObject field;
        private IMove iMove;
        private ISummon iSummon;
        void Start()
        {
            iMove = field.GetComponent<IMove>();
            iSummon = field.GetComponent<ISummon>();
        }

        void Update()
        {

        }

        public void ReceiveData(GameObject selectObj1, GameObject selectObj2)
        {
            Vector2 pos = Vector2.zero;
            pos = selectObj2.GetComponent<IGetPos>().GetPos();
            iSummon.Summon(selectObj1, pos);
        }
    }
}
