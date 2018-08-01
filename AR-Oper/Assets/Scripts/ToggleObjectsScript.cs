using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity;
using HoloToolkit.Unity.InputModule;

public class ToggleObjectsScript : Singleton<ToggleObjectsScript>, IFocusable, IInputClickHandler
{ 
    private Color defaultColor;
    private int toggleState;
    private GameObject currentToggledObject;
    // public GameObject[] toggleObjects;
    public GameObject[] toggledObjects; 

    protected override void Awake()
    {
        defaultColor = gameObject.GetComponent<MeshRenderer>().material.color;
        toggleState = 0;
        currentToggledObject = GameObject.Find(this.name + "/ToggleInfo");
        // toggleObjects = GameObject.FindGameObjectsWithTag("ToggleObject");
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
        ChangeInfoBox();
    }

    private void ChangeInfoBox()
    {
        if (currentToggledObject.GetComponent<Renderer>().enabled == false)
        {
            toggleState = 0;
        }

        switch (toggleState)
        {
            case 0:
                Debug.Log(toggleState);
                ToggleInfoBox();
                toggleState++;
                break;
            case 1:
                Debug.Log(toggleState);
                toggleState++;
                break;
            case 2:
                Debug.Log(toggleState);
                toggleState++;
                break;
            case 3:
                Debug.Log(toggleState);
                currentToggledObject.GetComponent<Renderer>().enabled = false;
                toggleState = 0;
                break;
        }
    }

    private void ToggleInfoBox ()
    {
        currentToggledObject.GetComponent<Renderer>().enabled = true;
        foreach (GameObject toggledObject in toggledObjects)
        {
            if (toggledObject != currentToggledObject)
            {
                toggledObject.GetComponent<Renderer>().enabled = false;
            }
        }
    }

    
}
