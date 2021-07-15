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
        PhotonNetwork.ConnectUsingSettings(); // Photon�Ɛڑ�
        //if (PhotonNetwork.IsConnected) subject.text = "�ڑ��ς�";
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
        PhotonNetwork.ConnectUsingSettings(); // Photon�Ɛڑ�

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
    }

    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        Debug.Log("���[���Q�����s");
    }


    [PunRPC]
    private void GameStart()
    {
        SceneManager.LoadScene("GameScene");
    }
}
