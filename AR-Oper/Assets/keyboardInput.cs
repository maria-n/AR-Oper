using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity;

public class keyboardInput : MonoBehaviour {

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("a"))
        {
            Debug.Log("a");
            Debug.Log(GameObject.Find("Placedus").GetComponent<SpeechManagerScript>().stagePlaceable);
            if (!GameObject.Find("Placedus").GetComponent<SpeechManagerScript>().stagePlaceable)
            {
                Debug.Log("collider on");
                GameObject.Find("Placedus").GetComponent<SpeechManagerScript>().stagePlaceable = true;
            }
            else
            {
                Debug.Log("collider off");
                GameObject.Find("Placedus").GetComponent<SpeechManagerScript>().stagePlaceable = false;
            }
        }
    }
}
