using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class PlayerMessageManager : MonoBehaviour
{

    float secondsBetweenLetters = 0.5f;

    public string PlayerMessage;
    public string newaddition;
    public Text usersMessageText;
    private List<GameObject> lightList;
    private float currentTime;
    private float lastLetterTime = 0;
    private float beginningDelay;
    private int listcount;
    public AudioSource monsterTriggerSound;
    public GameObject monsterObject;
    public GameObject GazeSelector;
    public List<GameObject> endLights;
    public List<Material> materialLight;
    List<GameObject> lightLightsList;
    // Use this for initialization
    void Start()
    {
        PlayerMessage = "";
        lightList = new List<GameObject>();
        lightLightsList = new List<GameObject>();
        //endLights = new List<GameObject>();
        //materialLight = new List<Material>();
    }


    public void AddLetter(string letterName)
    {
        Debug.Log(letterName);
        PlayerMessage = PlayerMessage + letterName;
        Debug.Log(PlayerMessage);
    }

    public void AddLetterToList(GameObject currentLetter)
    {
        lightList.Add(currentLetter);
    }

    public void AddLightToList(GameObject curLetterLight)
    {
        lightLightsList.Add(curLetterLight);
    }

    public void PlayMessage()
    {
        StartCoroutine(StackLetters(2.0f));
    }

    public void EndMessage()
    {
        StartCoroutine(EndStackLetters(2.0f));

    }

    IEnumerator PlayLetter(float numSeconds, int lightNum)
    {
        lightList[lightNum].GetComponent<Renderer>().material = materialLight[1];
        lightLightsList[lightNum].SetActive(true);
        // Add in any other effects for turning on light here
        yield return new WaitForSeconds(numSeconds);
        Debug.Log("Should turn back to grey");
        lightList[lightNum].GetComponent<Renderer>().material = materialLight[0];
        lightLightsList[lightNum].SetActive(false);
    }

    IEnumerator StackLetters(float numSeconds)
    {
        for (int i = 0; i < lightList.Count; i++)
        {
            StartCoroutine(PlayLetter(2.0f, i));
            yield return new WaitForSeconds(numSeconds);
            if (i == lightList.Count - 1)
            {
                //TriggerRun Script
                EndMessage();
            }
        }
    }

    IEnumerator EndStackLetters(float numSeconds)
    {

        for (int i = 0; i < endLights.Count; i++)
        {
            StartCoroutine(EndLetter(2.0f, i));
            yield return new WaitForSeconds(numSeconds);
            if (i == endLights.Count - 1)
            {
                //Play Monster Sound
                monsterTriggerSound.Play();
                GazeSelector.GetComponent<GazeTrackerBehavior>().MonsterCanBeTriggered = true;
            }
        }
    }


    IEnumerator EndLetter(float numSeconds, int lightNum)
    {
        Debug.Log("End Letter");
        endLights[lightNum].GetComponent<Renderer>().material = materialLight[1];
        // Add in any other effects for turning on light here
        Debug.Log("Playing: " + lightNum);
        yield return new WaitForSeconds(numSeconds);
        endLights[lightNum].GetComponent<Renderer>().material = materialLight[0];
        // Add in any other effects for turning off light here
    }
}
