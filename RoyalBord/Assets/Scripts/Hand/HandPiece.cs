using Bridge;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hand
{
    public class HandPiece : MonoBehaviour, ISendName
    {
        // ��D�ʂ̖��O��ݒ肷�鏈��

        [SerializeField] private string name = "";

        public string SendName()
        {
            return name;
        }
    }

}
