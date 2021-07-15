using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class NetworkTest : MonoBehaviourPunCallbacks
{
    [SerializeField] private string ip;
    [SerializeField] private Text playerName_text;
    [SerializeField] private Text roomID_txt;

    //private int playerNum = 0;
    private string playerName;
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings(); // Photonと接続
        //if (PhotonNetwork.IsConnected) subject.text = "接続済み";
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F12))
        {
            //NameDisplay();
        }
    }

    public void Connect()
    {
        PhotonNetwork.PhotonServerSettings.AppSettings.Server = ip;
        PhotonNetwork.ConnectUsingSettings(); // Photonと接続

    }

    public void Create()
    {
        //PhotonNetwork.PhotonServerSettings.AppSettings.Server = ip.text;

        PhotonNetwork.NickName = playerName_text.text;
        //PhotonNetwork.PlayerList[0]=
        PhotonNetwork.CreateRoom(roomID_txt.text);
    }

    public void Join()
    {
        PhotonNetwork.NickName = playerName_text.text;

        PhotonNetwork.JoinRoom(roomID_txt.text);
    }

    public void StartButton()
    {
        photonView.RPC(nameof(GameStart), RpcTarget.All);
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("接続完了");
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        Debug.Log("接続失敗");
    }

    public override void OnCreatedRoom()
    {
        Debug.Log("ルーム作成");
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        Debug.Log("ルーム作成失敗");
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("ルーム参加");
    }

    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        Debug.Log("ルーム参加失敗");
    }


    [PunRPC]
    private void GameStart()
    {
        SceneManager.LoadScene("GameScene");
    }
}
