using UnityEngine;
using System.Collections;
using HoloToolkit.Unity;

public class MonsterBehavior : MonoBehaviour {
    public GameObject monsterPrefab;

    void OnGazeEnter()
    {
        if (GazeManager.Instance.FocusedObject.name == this.gameObject.name)
        {
            monsterPrefab.SetActive(true);

        }
    }
}
