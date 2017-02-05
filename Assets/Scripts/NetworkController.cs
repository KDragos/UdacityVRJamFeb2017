using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkController : MonoBehaviour {

	string _room = "EscapeRoom";


	void Start()
	{
		PhotonNetwork.ConnectUsingSettings("0.1");
	}

	void OnJoinedLobby()
	{
		Debug.Log("joined lobby");

		RoomOptions roomOptions = new RoomOptions() { };
		// Set number of max players in the room. 
		roomOptions.MaxPlayers = 2;
		PhotonNetwork.JoinOrCreateRoom(_room, roomOptions, TypedLobby.Default);
	}

	void OnJoinedRoom()
	{
		PhotonNetwork.Instantiate("NetworkPlayer", Vector3.zero, Quaternion.identity, 0);
		Debug.Log("Joined Room: " + PhotonNetwork.room.ToString());
	}
}
