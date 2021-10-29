using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class CreateAndJoinsRooms : MonoBehaviourPunCallbacks
{
    public InputField createInput;
    public InputField joinInput;

    public void Start()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
    }
    public void CreateRooms()
    {
        PhotonNetwork.CreateRoom(createInput.text);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void JoinRooms()
    {
        PhotonNetwork.JoinRoom(joinInput.text);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("LobbyScene");
    }
}
