﻿using UnityEngine;
using System.Collections;
using HoloToolkit.Unity;

public class PlayButton : MonoBehaviour {
    GameObject _messageManager;
    PlayerMessageManager MessageManager;
    public bool playingMessage = false;
	// Use this for initialization
	void Start () {
        _messageManager = GameObject.Find("PlayerMessageManager");
        MessageManager = _messageManager.GetComponent<PlayerMessageManager>();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyUp(KeyCode.P))
        {
            OnSelect();
        }
	}
    void OnSelect()
    {
        //Call Message Play
        MessageManager.PlayMessage();
        playingMessage = true; 
    }
}
