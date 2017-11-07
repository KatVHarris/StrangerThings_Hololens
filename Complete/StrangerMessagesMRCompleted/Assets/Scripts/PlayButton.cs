using UnityEngine;
using System.Collections;
using HoloToolkit.Unity.InputModule;

public class PlayButton : MonoBehaviour, IInputClickHandler, IPointerSpecificFocusable
{
    GameObject _messageManager;
    PlayerMessageManager MessageManager;
    public bool playingMessage = false;
    public GameObject phoneLight;
	// Use this for initialization
	void Start () {
        _messageManager = GameObject.Find("MessageManager");
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

    public void PlayMessage()
    {
        //Call Message Play
        MessageManager.PlayMessage();
        playingMessage = true;
    }

    public void OnInputClicked(InputClickedEventData eventData)
    {
        MessageManager.PlayMessage();
        playingMessage = true;
    }

    public void OnFocusEnter(PointerSpecificEventData eventData)
    {
        //throw new System.NotImplementedException();
    }

    public void OnFocusExit(PointerSpecificEventData eventData)
    {
        //throw new System.NotImplementedException();
    }
}
