using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectorBehavior : MonoBehaviour {
    public GameObject laserhandel;
    SteamVR_LaserPointer laserPointer;
    private int deviceIndex = -1;
    private SteamVR_Controller.Device controller;

    bool pointerOnButton = false;
    GameObject myEventSystem;
    // Use this for initialization

    string letterTag = "Letter";
    GameObject currentFocus;

    // 1
    private SteamVR_TrackedObject trackedObj;
    // 2
    private SteamVR_Controller.Device Controller
    {
        get { return SteamVR_Controller.Input((int)trackedObj.index); }
    }

    void Awake()
    {
        trackedObj = laserhandel.GetComponent<SteamVR_TrackedObject>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == letterTag)
        {
            currentFocus = other.gameObject;
            other.GetComponent<LetterBehaviorVR>().OnGazeEnter();
        }
        if (other.tag == "Selectable")
        {
            currentFocus = other.gameObject;
            currentFocus.GetComponent<Light>().intensity = 1f; 
            
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == letterTag)
        {
            other.GetComponent<LetterBehaviorVR>().OnGazeLeave();
            currentFocus = null; 
        }
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.M))
        {
            currentFocus.GetComponent<LetterBehaviorVR>().OnSelect();
        }

        if (pointerOnButton)
        {
            if (Controller.GetHairTriggerDown())
            {
                currentFocus.GetComponent<LetterBehaviorVR>().OnSelect();
            }
        }
        if(currentFocus != null && currentFocus.tag == "Selectable" && Controller.GetHairTriggerDown())
        {
            currentFocus.GetComponent<PlayButton>().PlayMessage();
        }

    }


    void Start()
    {
        laserPointer = laserhandel.GetComponent<SteamVR_LaserPointer>();
        laserPointer.PointerIn += LaserPointer_PointerIn;
        laserPointer.PointerOut += LaserPointer_PointerOut;
        pointerOnButton = false;
    }
    private void SetDeviceIndex(int index)
    {
        deviceIndex = index;
        controller = SteamVR_Controller.Input(index);
        Debug.Log("index: " + controller.index);
    }
    private void LaserPointer_PointerOut(object sender, PointerEventArgs e)
    {
        pointerOnButton = false;

    }

    private void LaserPointer_PointerIn(object sender, PointerEventArgs e)
    {
        if (e.target.tag == letterTag)
        {
            pointerOnButton = true;
        }

    }

}
