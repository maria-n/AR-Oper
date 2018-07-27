using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity;
using HoloToolkit.Unity.InputModule;

public class AirTapHandler : Singleton<AirTapHandler> , IInputClickHandler {
    //private Color defaultColor;
    private GameObject toggledObject;

    // Use this for initialization
    /// <summary>
    /// "Save" the child object of the GameObject this script is applied to in a private variable to use in function.
    /// </summary>
    protected override void Awake()
    {
        //defaultColor = gameObject.GetComponent<MeshRenderer>().material.color;
        toggledObject = GameObject.Find(this.name+"/ToggleInfo");
    }

    // Update is called once per frame
    void Update () {
		
	}

    /// <summary>
    /// Toggles the Renderer of the child object. 
    /// </summary>
    public void OnInputClicked(InputClickedEventData eventData)
    {
        //Debug.Log(toggledObject);

        if (toggledObject.GetComponent<Renderer>().enabled == false)
        {
            Debug.Log("activate");
            toggledObject.GetComponent<Renderer>().enabled = true;
        }
        else
        {
            Debug.Log("deactivate");
            toggledObject.GetComponent<Renderer>().enabled = false;
        }
    }
}
