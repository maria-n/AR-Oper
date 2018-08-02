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
    private GameObject currentToggledText;
    // public GameObject[] toggleObjects;
    public GameObject[] toggledObjects; 

    protected override void Awake()
    {
        defaultColor = gameObject.GetComponent<MeshRenderer>().material.color;
        toggleState = 0;
        currentToggledObject = GameObject.Find(this.name + "/ToggleInfo");
        currentToggledText = GameObject.Find(this.name + "/ToggleInfo/InfoText");
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
                ToggleInfoBox();
                currentToggledText.GetComponent<SmartTextMesh>().NeedsLayout = true;
                currentToggledText.GetComponent<SmartTextMesh>().UnwrappedText = "Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod tempor invidunt ut labore et dolore magna";
                toggleState++;
                break;
            case 1:
                currentToggledText.GetComponent<SmartTextMesh>().NeedsLayout = true;
                currentToggledText.GetComponent<SmartTextMesh>().UnwrappedText = "Stet clita kasd gubergren, no sea takimata sanctus est Lorem ipsum dolor sit amet.";
                toggleState++;
                break;
            case 2:
                currentToggledText.GetComponent<SmartTextMesh>().NeedsLayout = true;
                currentToggledText.GetComponent<SmartTextMesh>().UnwrappedText = "No sea takimata sanctus est Lorem ipsum dolor sit amet.";
                toggleState++;
                break;
            case 3:
                currentToggledObject.GetComponent<Renderer>().enabled = false;
                for (int i = 0; i < currentToggledObject.transform.childCount; i++)
                { 
                    currentToggledObject.transform.GetChild(i).GetComponent<Renderer>().enabled = false;
                }
                toggleState = 0;
                break;
        }
    }

    private void ToggleInfoBox ()
    {
        currentToggledObject.GetComponent<Renderer>().enabled = true;
        for (int i = 0; i < currentToggledObject.transform.childCount; i++)
        {
            currentToggledObject.transform.GetChild(i).GetComponent<Renderer>().enabled = true;
        }
        foreach (GameObject toggledObject in toggledObjects)
        {
            if (toggledObject != currentToggledObject)
            {
                toggledObject.GetComponent<Renderer>().enabled = false;
                for (int i = 0; i < toggledObject.transform.childCount; i++)
                {
                    toggledObject.transform.GetChild(i).GetComponent<Renderer>().enabled = false;
                }
            }
        }
    }

    
}
