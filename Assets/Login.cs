using UnityEngine;
using System.Collections;

public class Login : Photon.MonoBehaviour {

	// Use this for initialization
	void Start () {
        PhotonNetwork.ConnectUsingSettings("0.1");
    }


    // Update is called once per frame
    void Update()
    {
       

    }
    void OnJoinedLobby()
    {
        PhotonNetwork.JoinOrCreateRoom("Test room", new RoomOptions(), TypedLobby.Default);
    }

    void OnJoinedRoom()
    {
        PhotonNetwork.Instantiate("Cube", Vector3.up * 5, Quaternion.identity, 0);
    }
}
