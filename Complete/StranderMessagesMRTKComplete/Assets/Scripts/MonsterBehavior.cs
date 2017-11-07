using UnityEngine;
using System.Collections;
using HoloToolkit.Unity;
using HoloToolkit.Unity.InputModule;

public class MonsterBehavior : MonoBehaviour {
    public GameObject monsterPrefab;

    void OnGazeEnter()
    {
        if (GazeManager.Instance.HitObject.name == this.gameObject.name)
        {
            monsterPrefab.SetActive(true);

        }
    }
}
