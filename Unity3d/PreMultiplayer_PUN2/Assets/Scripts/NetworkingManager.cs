using Photon.Pun;
using Photon.Realtime;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NetworkingManager : MonoBehaviourPunCallbacks
{
    public Button multiplayerButton;

    public override void OnConnectedToMaster()
    {
        Debug.Log("Unirnos a un lobby");
        PhotonNetwork.JoinLobby();
    }

    public override void OnJoinedLobby()
    {
        Debug.Log("Estamos listo para multijugador");
        multiplayerButton.interactable = true;
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.Log("No se pudo encontrar una sala");
        CreateRoom();
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("Cargando escena de juego");
        SceneManager.LoadScene(1);
    }

    public void FindMatch()
    {
        Debug.Log("Buscando una sala");
        PhotonNetwork.JoinRandomRoom();
    }

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Conexión a un servidor");
        PhotonNetwork.ConnectUsingSettings();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void CreateRoom()
    {
        int randomRoomName = UnityEngine.Random.Range(0, 10000);

        RoomOptions roomOptions = new RoomOptions
        {
            IsVisible = true,
            IsOpen = true,
            MaxPlayers = 6,
            PublishUserId = true
        };

        PhotonNetwork.CreateRoom($"RoomName_{randomRoomName}", roomOptions);
        Debug.Log($"Sala creada: {randomRoomName}");
    }
}
