using Bridge;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Inputer
{
    public class SendData : MonoBehaviour
    {
        // 情報を取得して送る処理

        // クラス変数
        private HoldObj     holdObj;
        private SelectField selectField;


        // Start is called before the first frame update
        void Start()
        {
            holdObj     = GetComponent<HoldObj>();
            selectField = GetComponent<SelectField>();
        }

        // Update is called once per frame
        void Update()
        {

        }

        private void Send()
        {
            
        }
    }

}
