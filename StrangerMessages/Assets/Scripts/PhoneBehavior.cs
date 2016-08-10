using UnityEngine;
using System.Collections;
using HoloToolkit.Unity;

public class PhoneBehavior : MonoBehaviour
{
    //public GameObject Player;
    SimpleTagalong tagAlong;

    void Start()
    {
        tagAlong = this.gameObject.AddComponent<SimpleTagalong>();
        tagAlong.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (SpatialMappingManager.Instance.IsObserverRunning())
        {
            tagAlong.enabled = true;
        }
        else
        {
            tagAlong.enabled = false;
        }

    }

    //public void UnParent()
    //{

    //}

    //public void ParentToPalyer()
    //{
    //    this.transform.parent = Player.transform;
    //}
}
