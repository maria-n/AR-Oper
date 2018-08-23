using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using HoloToolkit.Unity.Buttons;
using HoloToolkit.Unity.InputModule;
using HoloToolkit.Unity;

public class InfoBoxButtonScript : Singleton<InfoBoxButtonScript>, IInputClickHandler
{
    private Color defaultColor;
    public Color focusedColor;
    public Color pressedColor;
    private Color defaultIcon;
    public Color pressedIcon;

    private int textCountMax;
    private GameObject toggelingObject;
    // public GameObject[] toggelingObjects;
    // public GameObject[] toggledObjects;
    private GazeManager gazeManager;

    protected override void Awake()
    {
        defaultColor = this.GetComponent<Renderer>().material.color;
        defaultIcon = this.transform.GetChild(0).GetComponent<Renderer>().material.color;
        toggelingObject = GameObject.Find("InfoBox");
        // toggelingObjects = GameObject.FindGameObjectsWithTag("toggelingObject");
        // toggledObjects = GameObject.FindGameObjectsWithTag("ToggledObject");
        gazeManager = GameObject.Find("DefaultCursor").GetComponent<GazeManager>();

        Debug.Log("Awake: " + this.gameObject);
    }

    private void Start()
    {
        textCountMax = toggelingObject.GetComponent<InfoBoxContentManager>().maxCount;
    }

    // Update is called once per frame
    void Update () {
        switch (this.GetComponent<ObjectButton>().ButtonState.ToString())
        {
            case "Pressed":
                this.GetComponent<Renderer>().material.color = pressedColor;
                this.transform.GetChild(0).GetComponent<Renderer>().material.color = pressedIcon;
                break;
            case "Targeted":
                this.GetComponent<Renderer>().material.color = focusedColor;
                break;
            case "ObservationTargeted":
                this.GetComponent<Renderer>().material.color = focusedColor;
                break;
            default:
                this.GetComponent<Renderer>().material.color = defaultColor;
                this.transform.GetChild(0).GetComponent<Renderer>().material.color = defaultIcon;
                break;
        }
    }

    public void OnInputClicked(InputClickedEventData eventData)
    {
        switch (gazeManager.HitObject.name)
        {
            case "ButtonForward":
                ClickForward();
                break;
            case "ButtonBack":
                ClickBack();
                break;
        }
    }

    public void ClickForward()
    {
        switch (toggelingObject.GetComponent<InfoBoxContentManager>().textState)
        {
            case 0:
                toggelingObject.GetComponent<InfoBoxContentManager>().textState++;
                break;
            case 1:
                toggelingObject.GetComponent<InfoBoxContentManager>().textState++;
                break;
            case 2:
                toggelingObject.GetComponent<InfoBoxContentManager>().textState++;
                break;
            case 3:
                toggelingObject.GetComponent<InfoBoxContentManager>().textState = textCountMax;
                break;
            default:
                Debug.Log("something happened");
                break;
        }
    }

    private void ClickBack()
    {
        switch (toggelingObject.GetComponent<InfoBoxContentManager>().textState)
        {
            case 0:
                toggelingObject.GetComponent<InfoBoxContentManager>().textState = 0;
                break;
            case 1:
                toggelingObject.GetComponent<InfoBoxContentManager>().textState--;
                break;
            case 2:
                toggelingObject.GetComponent<InfoBoxContentManager>().textState--;
                break;
            case 3:
                toggelingObject.GetComponent<InfoBoxContentManager>().textState--;
                break;
            default:
                Debug.Log("something happened");
                break;
        }
    }

    private void ToggleInfoBox()
    {
        throw new NotImplementedException();
    }
}

