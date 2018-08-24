using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoBoxObjectManager : MonoBehaviour {
    public GameObject toggledObject;
    public GameObject toggledText;
    public GameObject toggelingObject;
    public GameObject[] allToggledObjects;
    public GameObject[] allToggleObjects;

    private void Awake()
    {
        toggledObject = GameObject.Find(name + "/InfoBox");
        toggledText = GameObject.Find(name + "/InfoBox").transform.GetChild(0).GetChild(0).gameObject;
        toggelingObject = GameObject.Find(name + "/InfoBoxObject");
        allToggleObjects = GameObject.FindGameObjectsWithTag("ToggleObject");
        allToggledObjects = GameObject.FindGameObjectsWithTag("ToggledObject");
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ToggleInfoBox()
    {
        toggledObject.GetComponent<Renderer>().enabled = true;

        for (int i = 0; i < toggledObject.transform.childCount; i++)
        {
            toggledObject.transform.GetChild(i).GetComponent<Renderer>().enabled = true;
            toggledObject.transform.GetChild(i).GetChild(0).GetComponent<Renderer>().enabled = true;
        }

        // RemoveOtherBoxes();
    }

    public void RemoveOtherBoxes()
    {
        foreach (GameObject t_Object in allToggledObjects)
        {
            if (t_Object != toggledObject)
            {
                t_Object.GetComponent<Renderer>().enabled = false;
            }
        }
    }
}
