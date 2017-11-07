using HoloToolkit.Unity.InputModule;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetterBehaviorVR : MonoBehaviour, IInputClickHandler, IFocusable, IPointerSpecificFocusable
{

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
        Billboard = GameObject.Find("Billboard2");
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

    public void OnInputClicked(InputClickedEventData eventData)
    {
        if (eventData.selectedObject.name == this.name)
        {

        }

            // Increase the scale of the object just as a response.
            // gameObject.transform.localScale += 0.05f * gameObject.transform.localScale;

            // eventData.Use(); // Mark the event as used, so it doesn't fall through to other handlers.
            Debug.Log("Registered Trigger");
        PMessageManager.AddLetter(this.name);
        PMessageManager.AddLetterToList(letterLight);
        PMessageManager.AddLightToList(letterLightlight);
        letterLight.GetComponent<Renderer>().material = materialList[2];

    }

    public void OnFocusEnter()
    {
        Debug.Log("I am focused " + this.name);
        LightOn();
        MaterialChange(1);
    }

    public void OnFocusEnter(PointerSpecificEventData eventData)
    {
        if(eventData.selectedObject.name == this.name)
        {
            LightOn();
            MaterialChange(1);
        }

    }

    public void OnFocusExit()
    {
        LightOn();
        MaterialChange(0);
    }

    public void OnFocusExit(PointerSpecificEventData eventData)
    {
        //throw new System.NotImplementedException();
    }
}
