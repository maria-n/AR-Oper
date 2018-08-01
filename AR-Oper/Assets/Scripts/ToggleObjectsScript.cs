using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity;
using HoloToolkit.Unity.InputModule;

public class ToggleObjectsScript : Singleton<ToggleObjectsScript>, IFocusable, IInputClickHandler
{ 
    private Color defaultColor;
    private GameObject currentToggledObject;
    public GameObject[] toggleObjects;
    public GameObject[] toggledObjects; 

    protected override void Awake()
    {
        defaultColor = gameObject.GetComponent<MeshRenderer>().material.color;
        currentToggledObject = GameObject.Find(this.name + "/ToggleInfo");
        toggleObjects = GameObject.FindGameObjectsWithTag("ToggleObject");
        toggledObjects = GameObject.FindGameObjectsWithTag("ToggledObject");
    }


    // Use this for initialization
    private void Update()
    {
    }

    /// <summary>
    /// When an object intersects the raycast of the gaze, the color of said object changes
    /// </summary>
    public void OnFocusEnter()
    {
        gameObject.GetComponent<MeshRenderer>().material.color = Color.blue;
    }

    /// <summary>
    /// When the raycast of the gaze stops intersecting with the object, the objects color reverts back.
    /// </summary>
    public void OnFocusExit()
    {
        gameObject.GetComponent<MeshRenderer>().material.color = defaultColor;
    }

    public void OnInputClicked(InputClickedEventData eventData)
    {
        // For loop for Array
        // If new object gets tap
        // open Infobox for object and close alle info boxes for the rest

        if (currentToggledObject.GetComponent<Renderer>().enabled == false)
        {
            Debug.Log("activate");
            currentToggledObject.GetComponent<Renderer>().enabled = true;
            foreach(GameObject toggledObject in toggledObjects)
            {
                if(toggledObject != currentToggledObject)
                {
                    toggledObject.GetComponent<Renderer>().enabled = false;
                }
            }
        }
        else
        {
            Debug.Log("deactivate");
            currentToggledObject.GetComponent<Renderer>().enabled = false;
        }
    }
}
