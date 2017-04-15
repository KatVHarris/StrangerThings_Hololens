using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LetterBehavior : MonoBehaviour {
 //   private GameObject focusedObject;
 //   public GameObject MessageManager;
 //   private PlayerMessageManager PMessageManager;
 //   public List<Material> materialList;
 //   public GameObject letterLightlight;
 //   public GameObject letterLight;
 //   public GameObject Billboard;
 //   bool selectable = false;
 //   public GameObject phone; 
 //   // Use this for initialization
 //   void Start () {
 //       MessageManager = GameObject.Find("PlayerMessageManager");
 //       PMessageManager = MessageManager.GetComponent<PlayerMessageManager>();
        
	//}
	
	//// Update is called once per frame
	//void Update () {
 //       if(Billboard.GetComponent<TapToPlace>().placing)//|| phone.GetComponent<PlayButton>().playingMessage)
 //       {
 //           selectable = false;
 //           this.transform.GetComponent<BoxCollider>().enabled = false;
 //       }
 //       else
 //       {
 //           selectable = true;
 //           this.transform.GetComponent<BoxCollider>().enabled = true;
 //       }

 //       if (Input.GetKeyUp(KeyCode.M))
 //       {
 //           OnSelect();
 //       }
	
	//}

 //   void OnSelect()
 //   {
 //           //Send Message that the Letter was selected
 //           if (GazeManager.Instance.FocusedObject.name == this.gameObject.name)
 //           {
 //               //Add letter to stringMessage
 //               PMessageManager.AddLetter(this.name);
 //               PMessageManager.AddLetterToList(letterLight);
 //               letterLight.GetComponent<Renderer>().material = materialList[2];
 //           }
        
 //   }

 //   void OnGazeEnter()
 //   {
 //       Debug.Log("can select? " + selectable +"is placing: "+ Billboard.GetComponent<TapToPlace>().placing);
 //           if (GazeManager.Instance.FocusedObject.name == this.gameObject.name)
 //           {
 //               letterLightlight.SetActive(true);
 //               //change light color
 //               letterLight.GetComponent<Renderer>().material = materialList[1];
 //           }
        
 //   }

 //   void OnGazeLeave()
 //   {
 //       letterLightlight.SetActive(false);
 //       //change light color
 //       letterLight.GetComponent<Renderer>().material = materialList[0];
        
 //   }


}
