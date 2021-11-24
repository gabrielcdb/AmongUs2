using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using System;

public class CreateAndJoinsRooms : MonoBehaviourPunCallbacks
{
    public InputField createAndJoinInput;
    public Text warning;

    public void Start()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
    }
    public void CreateandJoinRooms()
    {
        if (createAndJoinInput.text != "")
        {
            if (PhotonNetwork.IsConnectedAndReady)
            {
                PhotonNetwork.JoinRoom(createAndJoinInput.text);
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
        }
        else
        {
            warning.text = "You can't create or join a noname room";
        }
    }
    public void JoinRandomRoom()
    {
        PhotonNetwork.JoinRandomRoom();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("LobbyScene");
    }

    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        PhotonNetwork.CreateRoom(createAndJoinInput.text);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        return;
    }
    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        warning.text = "Failed to create and join room";
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        return;
    }
    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        warning.text = "Failed to join random room, maybe there is no other room, try to create one!";
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        return;
    }
}
