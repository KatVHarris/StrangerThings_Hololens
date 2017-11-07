using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GazeTrackerBehavior : MonoBehaviour {
    string eventTrigger = "MonsterTrigger";
    public GameObject monster;
    public bool MonsterCanBeTriggered;

    private void Start()
    {
        MonsterCanBeTriggered = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == eventTrigger && MonsterCanBeTriggered)
        {
            Debug.Log("HitBox");
            monster.GetComponent<MonsterBehavior>().SetMonsterActive();
        }
    }
}
