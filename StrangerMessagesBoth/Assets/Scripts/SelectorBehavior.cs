using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectorBehavior : MonoBehaviour {
    public GameObject laserhandel;
    SteamVR_LaserPointer laserPointer;
    private int deviceIndex = -1;
    private SteamVR_Controller.Device controller;
    string eventTrigger = "MonsterTrigger";
    public GameObject monster;
    public bool MonsterCanBeTriggered;
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

    void Start()
    {
        laserPointer = laserhandel.GetComponent<SteamVR_LaserPointer>();
        laserPointer.PointerIn += LaserPointer_PointerIn;
        laserPointer.PointerOut += LaserPointer_PointerOut;
        pointerOnButton = false;
        MonsterCanBeTriggered = false;

    }



    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == letterTag)
        {
            currentFocus = other.gameObject;
            pointerOnButton = true;
            other.GetComponent<LetterBehaviorVR>().OnGazeEnter();
        }
        if (other.tag == "Selectable")
        {
            currentFocus = other.gameObject;
            currentFocus.GetComponent<Light>().intensity = 1f; 
            
        }
        if (other.tag == eventTrigger && MonsterCanBeTriggered)
        {
            Debug.Log("HitBox");
            monster.GetComponent<MonsterBehavior>().SetMonsterActive();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == letterTag)
        {
            other.GetComponent<LetterBehaviorVR>().OnGazeLeave();
            currentFocus = null;
            pointerOnButton = false;
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
