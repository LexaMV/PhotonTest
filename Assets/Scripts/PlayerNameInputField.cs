﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(InputField))]
public class PlayerNameInputField : MonoBehaviour {


    #region Private Variables
	static string playerNamePrefKey = "PlayerName";
	# endregion

	#region MonoBehavior CallBacks
	// Use this for initialization
	void Start () {
		string defaultName = "";
		InputField _inputfield = this.GetComponent<InputField>();
		if(_inputfield != null)
		{
			if(PlayerPrefs.HasKey(playerNamePrefKey))
			{
				defaultName = PlayerPrefs.GetString(playerNamePrefKey);
				_inputfield.text = defaultName;
			}
		}
        
          PhotonNetwork.playerName = defaultName;
	}

	#endregion

	#region Public Methods

	public void SetPlayerName(string value)
	{
		PhotonNetwork.playerName = value + " ";
		PlayerPrefs.SetString(playerNamePrefKey,value);
	}
	
	#endregion
	// Update is called once per frame
	void Update () {
		
	}
}
