using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkedPlayer : Photon.MonoBehaviour {

	public GameObject avatar;

	public Transform playerGlobal;
	public Transform playerLocal;

	void Awake ()
	{
		Debug.Log("I'm instantiated");

		if (photonView.isMine)
		{
			Debug.Log("player is mine");

			playerGlobal = GameObject.Find("NVRPlayer").transform; // Where the avatar is in space. 
			playerLocal = playerGlobal.Find("Head"); // Responsible for the head movements.

			this.transform.SetParent(playerLocal);
			this.transform.localPosition = Vector3.zero;

			avatar.SetActive(false);
		}
	}

	void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
	{
		if (stream.isWriting) // Sending info out to everyone else.
		{
			stream.SendNext(playerGlobal.position);
			stream.SendNext(playerGlobal.rotation);
			stream.SendNext(playerLocal.localPosition);
			stream.SendNext(playerLocal.localRotation);
		}
		else
		{
			this.transform.position = (Vector3)stream.ReceiveNext();
			this.transform.rotation = (Quaternion)stream.ReceiveNext();
			avatar.transform.localPosition = (Vector3)stream.ReceiveNext();
			avatar.transform.localRotation = (Quaternion)stream.ReceiveNext();
		}
	}
}
