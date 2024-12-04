using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NetworkingManager : MonoBehaviourPunCallbacks
{
    public Button multiplayerButton;

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
}
