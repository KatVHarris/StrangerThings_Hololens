using UnityEngine;
using System.Collections;

public class MonsterBehavior : MonoBehaviour {
    public GameObject monsterModel;

    public void SetMonsterActive()
    {
        monsterModel.SetActive(true);
    }
}
