using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class Matching : MonoBehaviourPunCallbacks
{
    [SerializeField] private Text playerName_text;
    [SerializeField] private Text ip_text;
    [SerializeField] private Text roomID_txt;

    [SerializeField] private GameObject waitingUI;
    [SerializeField] private Text waitingText;
    [SerializeField] private GameObject failedUI;
    [SerializeField] private Text failedText;

    [SerializeField] private GameObject cloud;

    [SerializeField] private InputField inputName;
    [SerializeField] private InputField inputIP;
    [SerializeField] private InputField inputRoomID;
    [SerializeField] private Button createButtonUI;
    [SerializeField] private Button joinButtonUI;

    private bool matchFlg = false;
    public static string playerName;
    public static string enemyName;
    public static bool hostFlg;
    public static bool playerTurn = false;

    void Start()
    {
    }

    private void Update()
    {
    }

    public void Connect()
    {
        PhotonNetwork.PhotonServerSettings.AppSettings.Server = ip_text.text;
        PhotonNetwork.ConnectUsingSettings(); // Photonと接続
    }

    public void Create()
    {
        PhotonNetwork.PhotonServerSettings.AppSettings.Server = ip_text.text;
        PhotonNetwork.ConnectUsingSettings(); // Photonと接続

        StartCoroutine(ConnectWaiting(true));
    }

    public void Join()
    {
        PhotonNetwork.PhotonServerSettings.AppSettings.Server = ip_text.text;
        PhotonNetwork.ConnectUsingSettings(); // Photonと接続

        StartCoroutine(ConnectWaiting(false));
    }

    public void StartButton()
    {
        photonView.RPC(nameof(GameStart), RpcTarget.All);
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("接続完了");
        matchFlg = true;
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        Debug.Log("接続失敗");
        waitingUI.SetActive(false);
        failedUI.SetActive(true);
        failedText.text = "接続に失敗しました";
    }

    public override void OnCreatedRoom()
    {
        waitingText.text = "対戦相手を待っています";
        Debug.Log("ルーム作成");
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        Debug.Log("ルーム作成失敗");
        waitingUI.SetActive(false);
        failedUI.SetActive(true);
        failedText.text = "ルームの作成に失敗しました";
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("ルーム参加");

        if(PhotonNetwork.CurrentRoom.PlayerCount == 1)
        {
            hostFlg = true;
            int randNum = Random.Range(0, 100);
            playerTurn = (randNum % 2 == 0) ? true : false;
            waitingText.text = "対戦相手を待っています";
        }
        if (PhotonNetwork.CurrentRoom.PlayerCount==2)
        {
            waitingText.text = "マッチング中";
            photonView.RPC(nameof(GameStart), RpcTarget.All);
        }
    }

    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        Debug.Log("ルーム参加失敗");
        waitingUI.SetActive(false);
        failedUI.SetActive(true);
        failedText.text = "ルームの参加に失敗しました";
    }

    IEnumerator ConnectWaiting(bool isCreate)
    {
        TouchUIActive(false);
        waitingUI.SetActive(true);
        waitingText.text = "接続中";

        yield return new WaitUntil(() => matchFlg == true);

        PhotonNetwork.NickName = playerName_text.text;

        if (isCreate)
        {
            waitingText.text = "ルーム作成中";
            PhotonNetwork.CreateRoom(roomID_txt.text);
        }
        else
        {
            waitingText.text = "ルームに参加中";
            PhotonNetwork.JoinRoom(roomID_txt.text);
        }

    }

    public void TouchUIActive(bool isActive)
    {
        inputName.interactable = isActive;
        inputIP.interactable = isActive;
        inputRoomID.interactable = isActive;
        createButtonUI.interactable = isActive;
        joinButtonUI.interactable = isActive;
    }


[PunRPC]
    private void GameStart()
    {
        cloud.SetActive(true);
    }
}
