using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Credit : MonoBehaviour
{
    [SerializeField] GameObject fadeCloud;
    [SerializeField] float speed;
    [SerializeField] float endPos;
    float speed2;
    float trPosY;
    string text;
    string space = "\n\n\n\n";
    Text creditText;
    void Start()
    {
        speed2 = speed;
        creditText = this.GetComponent<Text>();

        ScrollText();
        creditText.text = text;

    }

    void Update()
    {
        trPosY = transform.position.y;
        transform.position += new Vector3(0, speed, 0) * Time.deltaTime;
        
        if (Input.anyKey)
        {
            speed = speed2 * 10;
        }
        else speed = speed2;

        if(trPosY >= endPos) { fadeCloud.SetActive(true); }
    }

    void ScrollText()
    {
        text =
            "締切直前に3日休んだ：三輪勇河\n" +
            space +
            "数学20/25点：戸田烈\n" +
            space +
            "サウンドコンポーザー：遠藤真一\n" +
            space +
            "最近の口癖「これ持ちネタにするわ。」：林素生\n" +
            space +
            "キラめきの剝奪者：坂東陸\n" +
            space +
            "ペン回し上手そう：恩田嵩央\n" +
            space +
            "シャニマスのツイートのリプ欄にいる：伊藤ヒロキ @hiroshi123js\n" +
            space +
            "アルティメットスペシャルアドバイザー：平野孝明\n" +
            space +
            "MayBe?：ウス\n" +
            space +
            "内閣総理大臣：菅義偉\n" +
            space +
            "田島一輝：田島一輝\n" +
            space +
            "ライバルズ終了した：中山亮太\n" +
            space +
            "またしても何も知らない：大石健二\n" +
            space +
            "";
    }
}
