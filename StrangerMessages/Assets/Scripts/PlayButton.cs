using UnityEngine;
using System.Collections;
using HoloToolkit.Unity;

public class PlayButton : MonoBehaviour {
    public PlayerMessageManager MessageStuff;
    public bool playingMessage = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnSelect()
    {
        //Call Message Play
        MessageStuff.PlayMessage();
        playingMessage = true; 
    }
}
