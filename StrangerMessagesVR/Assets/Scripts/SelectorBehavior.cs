using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectorBehavior : MonoBehaviour {
    public GameObject laserhandel;
    SteamVR_LaserPointer laserPointer;
    private int deviceIndex = -1;
    private SteamVR_Controller.Device controller;
    SteamVR_TrackedObject trackedObj;

    bool pointerOnButton = false;
    GameObject myEventSystem;
    // Use this for initialization

    string letterTag = "Letter";
    GameObject currentFocus;


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
        var device = SteamVR_Controller.Input((int)trackedObj.index);
        if (Input.GetKeyUp(KeyCode.M))
        {
            currentFocus.GetComponent<LetterBehaviorVR>().OnSelect();
        }

        if (pointerOnButton)
        {
            if (device.GetPressDown(Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger))
            {
                //btn.onClick.Invoke();
                Debug.Log("Clicked");
            }
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
        Debug.Log("out");
        pointerOnButton = false;

    }

    private void LaserPointer_PointerIn(object sender, PointerEventArgs e)
    {
        if (e.target.tag == letterTag)
        {
            pointerOnButton = true;
            Debug.Log("in");

        }

    }

}
