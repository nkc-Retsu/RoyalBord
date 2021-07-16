using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class Matching : MonoBehaviourPunCallbacks
{
    [SerializeField] private Text playerName_text;
    [SerializeField] private Text ip_text;
    [SerializeField] private Text roomID_txt;

    public static string playerName;
    public static string enemyName;
    public static bool hostFlg;
    public static bool playerTurn = false;
    void Start()
    {
        //if (PhotonNetwork.IsConnected) Debug.Log("�ڑ��ς�");
        PhotonNetwork.PhotonServerSettings.AppSettings.Server = ip_text.text;
        PhotonNetwork.ConnectUsingSettings(); // Photon�Ɛڑ�

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F12))
        {
            Connect();
        }
    }

    public void Connect()
    {

        PhotonNetwork.PhotonServerSettings.AppSettings.Server = ip_text.text;
        PhotonNetwork.ConnectUsingSettings(); // Photon�Ɛڑ�


    }

    public void Create()
    {
        PhotonNetwork.PhotonServerSettings.AppSettings.Server = ip_text.text;
        PhotonNetwork.ConnectUsingSettings(); // Photon�Ɛڑ�

        PhotonNetwork.NickName = playerName_text.text;
        PhotonNetwork.CreateRoom(roomID_txt.text);
    }

    public void Join()
    {
        PhotonNetwork.PhotonServerSettings.AppSettings.Server = ip_text.text;
        PhotonNetwork.ConnectUsingSettings(); // Photon�Ɛڑ�

        PhotonNetwork.NickName = playerName_text.text;
        PhotonNetwork.JoinRoom(roomID_txt.text);
    }

    public void StartButton()
    {
        photonView.RPC(nameof(GameStart), RpcTarget.All);
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("�ڑ�����");
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        Debug.Log("�ڑ����s");
    }

    public override void OnCreatedRoom()
    {
        Debug.Log("���[���쐬");
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        Debug.Log("���[���쐬���s");
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("���[���Q��");

        if(PhotonNetwork.CurrentRoom.PlayerCount == 1)
        {
            hostFlg = true;
            int randNum = Random.Range(0, 100);
            playerTurn = (randNum % 2 == 0) ? true : false;

        }
        if(PhotonNetwork.CurrentRoom.PlayerCount==2)
        {
            photonView.RPC(nameof(GameStart), RpcTarget.All);
        }
    }

    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        Debug.Log("���[���Q�����s");
    }

    [PunRPC]
    private void GameStart()
    {
        SceneManager.LoadScene("GodoTest");
    }
}
