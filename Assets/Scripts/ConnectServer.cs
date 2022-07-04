using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;

public class ConnectServer : MonoBehaviourPunCallbacks
{
    [SerializeField]
    InputField roomName;

    [SerializeField]
    InputField playerName;

    private void Start()
    {
        Debug.Log("Attempting to connect to the server");
        try
        {
            PhotonNetwork.ConnectUsingSettings(); // this will connect to the pun server using the user settings in Unity
        }
        catch
        {
            Debug.LogError("Did not connect to the server");
        }
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected to master server");
        PhotonNetwork.JoinLobby();  // try and join the lobby
    }

    public override void OnJoinedLobby()
    {
        Debug.Log("Joined lobby");
    }

    // This is called when the player enters the room name and personal name and clicks a button
    public void CreateRoom()
    {
        // If either field is left empty, relay a message
        if(string.IsNullOrEmpty(roomName.text) || string.IsNullOrEmpty(playerName.text))
        {
            Debug.LogError("Please fill out both fields");
            return;
        }

        PhotonNetwork.CreateRoom(roomName.text);
    }

    // This method is called if the createroom method is successful
    public override void OnJoinedRoom()
    {

    }

    // This method is called if the createroom method fails
    public override void OnCreateRoomFailed(short returnCode, string message)
    {

    }
}
