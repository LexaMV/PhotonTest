using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launcher : Photon.PunBehaviour {


#region PublicVariables
[Tooltip("Панель отрубается после ввода имени, подключения и игры")]
public GameObject controlPanel;
[Tooltip("Панель информирует пользователя что подключение в процессе")]
public GameObject progressLabel;
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
	void Start() {
	 	progressLabel.SetActive(false);
		 controlPanel.SetActive(true);
	 }
	

	public void Connect(){

        progressLabel.SetActive(true);
		controlPanel.SetActive(false);

		if(PhotonNetwork.connected){
        PhotonNetwork.JoinRandomRoom();
		} 
		else {
			PhotonNetwork.ConnectUsingSettings(_gameversion);
		}
	}

	public void DisConnect(){

       
        PhotonNetwork.Disconnect();
		
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
		progressLabel.SetActive(false);
		 controlPanel.SetActive(true);
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