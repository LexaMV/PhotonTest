using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launcher : Photon.PunBehaviour {


#region PublicVariables
public byte MaxPlayersPerRoom = 4;
public PhotonLogLevel logLevel = PhotonLogLevel.Informational;
#endregion

#region PrivateVariables

string _gameversion = "1";

#endregion

#region MonoBehavior CallBack
	// Use this for initialization

	void Awake (){
		PhotonNetwork.autoJoinLobby = false;
		PhotonNetwork.automaticallySyncScene = true;
		PhotonNetwork.logLevel = logLevel;
	}
	// void Start() {
	// 	Connect();
	// }
	

	public void Connect(){
		if(PhotonNetwork.connected){
        PhotonNetwork.JoinRandomRoom();
		} 
		else {
			PhotonNetwork.ConnectUsingSettings(_gameversion);
		}
	}

	#endregion
	// Update is called once per frame
	#region Photon.PunBechavior

	public override void OnConnectedToMaster(){
		Debug.Log("OnConnectToMaster() был вызван перезаписаннным PUN");
		PhotonNetwork.JoinRandomRoom();
	}

	public override void OnDisconnectedFromPhoton(){
		Debug.LogWarning("OnDisconnetFromPhoton был вызван перезаписанным PUN");
	}

	public override void OnPhotonJoinRoomFailed(object[] codeAndMsg){
		Debug.Log("OnPhotonJoinRoomFailed был вызван перезаписанным PUN, комнату создать не удалось");
		PhotonNetwork.CreateRoom(null, new RoomOptions{MaxPlayers = MaxPlayersPerRoom},null);
	}

	public override void OnJoinedRoom(){
        Debug.Log("OnJoineRoom был презаписан PUN");
	}

	#endregion
}