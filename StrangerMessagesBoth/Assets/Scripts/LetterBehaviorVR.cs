using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetterBehaviorVR : MonoBehaviour {

    private GameObject focusedObject;
    public GameObject MessageManager;
    private PlayerMessageManager PMessageManager;
    public List<Material> materialList;
    public GameObject letterLightlight;
    public GameObject letterLight;
    public GameObject Billboard;
    bool selectable = false;
    public GameObject phone;
    // Use this for initialization
    void Start()
    {
        MessageManager = GameObject.Find("MessageManager");
        PMessageManager = MessageManager.GetComponent<PlayerMessageManager>();

    }

    public void OnSelect()
    {

        //Add letter to stringMessage
        PMessageManager.AddLetter(this.name);
        PMessageManager.AddLetterToList(letterLight);
        PMessageManager.AddLightToList(letterLightlight);
        letterLight.GetComponent<Renderer>().material = materialList[2];
    }

    public void OnGazeEnter()
    {
        LightOn();
        //change light color
        letterLight.GetComponent<Renderer>().material = materialList[1];

    }

    public void OnGazeLeave()
    {
        LightOff(); 
        //change light color
        letterLight.GetComponent<Renderer>().material = materialList[0];

    }

    public void LightOn()
    {
        letterLightlight.SetActive(true);
    }

    public void LightOff()
    {
        letterLightlight.SetActive(false);

    }

    public void MaterialChange(int x)
    {
        letterLight.GetComponent<Renderer>().material = materialList[x];
    }
}
