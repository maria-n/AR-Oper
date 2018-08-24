using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity;
using HoloToolkit.Unity.InputModule;

public class InfoBoxToggleScript : Singleton<InfoBoxToggleScript>, IFocusable, IInputClickHandler
{
    private Color defaultColor;
    private Color changeColor;
    private GameObject ToggledObject;
    private GameObject ToggledText;
    // private GameObject[] toggleObjects;
    // public GameObject[] allToggleObjects;

    protected override void Awake()
    {
        defaultColor = GetComponent<MeshRenderer>().material.color;
        changeColor = Color.blue;
        
        Debug.Log("Awake: " + gameObject);
    }

    private void Start()
    {
        ToggledObject = GetComponentInParent<InfoBoxObjectManager>().toggledObject;
        ToggledText = GetComponentInParent<InfoBoxObjectManager>().toggledText;
        // toggleObjects = GetComponentInParent<InfoBoxObjectManager>().allToggleObjects;
        // allToggledObjects = GetComponentInParent<InfoBoxObjectManager>().allToggledObjects;
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
        GetComponent<MeshRenderer>().material.color = changeColor;
    }

    /// <summary>
    /// When the raycast of the gaze stops intersecting with the object, the objects color reverts back.
    /// </summary>
    public void OnFocusExit()
    {
        GetComponent<MeshRenderer>().material.color = defaultColor;
    }

    public void OnInputClicked(InputClickedEventData eventData)
    { 
        if (ToggledObject.GetComponent<Renderer>().enabled == false)
        {
            ToggledObject.GetComponent<InfoBoxContentManager>().textState = 0;
            GetComponentInParent<InfoBoxObjectManager>().ToggleInfoBox();
            EnableInfoBox();
        }
    }

    public void EnableInfoBox()
    {

    }
}