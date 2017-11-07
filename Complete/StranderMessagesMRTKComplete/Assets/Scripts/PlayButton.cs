using UnityEngine;
using System.Collections;
using HoloToolkit.Unity;
using HoloToolkit.Unity.InputModule;

public class PlayButton : MonoBehaviour, IFocusable, IInputClickHandler
{
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
            OnInputClicked();
        }
	}
    // Was OnSelect()
    public void OnInputClicked()
    {
        //Call Message Play
        Debug.Log("phone clicked");
        MessageManager.PlayMessage();
        playingMessage = true; 
    }

    public void OnFocusEnter()
    {
        //throw new System.NotImplementedException();
    }

    public void OnFocusExit()
    {
        //throw new System.NotImplementedException();
    }


    public void OnInputClicked(InputClickedEventData eventData)
    {
        Debug.Log("phone clicked");
        MessageManager.PlayMessage();
        playingMessage = true;
    }
}
