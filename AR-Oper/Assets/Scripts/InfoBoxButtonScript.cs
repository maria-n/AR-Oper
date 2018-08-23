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

    // private int infoState;
    private int textCountMax;
    private GameObject toggleObject;
    // private GameObject currentToggledText;
    // public GameObject[] toggleObjects;
    // public GameObject[] toggledObjects;
    private GazeManager gazeManager;

    protected override void Awake()
    {
        defaultColor = this.GetComponent<Renderer>().material.color;
        defaultIcon = this.transform.GetChild(0).GetComponent<Renderer>().material.color;
        toggleObject = GameObject.Find("InfoBox");
        // currentToggledText = GameObject.Find(toggleObject + "/InfoBoxBG/InfoBoxText");
        // toggleObjects = GameObject.FindGameObjectsWithTag("ToggleObject");
        // toggledObjects = GameObject.FindGameObjectsWithTag("ToggledObject");
        textCountMax = 3;
        gazeManager = GameObject.Find("DefaultCursor").GetComponent<GazeManager>();
        Debug.Log("Awake: " + this.gameObject);
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
        if (toggleObject.GetComponent<InfoBoxContentChange>().textState < 0)
            toggleObject.GetComponent<InfoBoxContentChange>().textState = 0;
        else if (toggleObject.GetComponent<InfoBoxContentChange>().textState > textCountMax)
            toggleObject.GetComponent<InfoBoxContentChange>().textState = textCountMax;


        switch (gazeManager.HitObject.name)
        {
            case "ButtonForward":
                ClickForward();
                break;
            case "ButtonBack":
                ClickBack();
                break;
        }
        Debug.Log(toggleObject.GetComponent<InfoBoxContentChange>().textState);
    }

    public void ClickForward()
    {
        switch(toggleObject.GetComponent<InfoBoxContentChange>().textState)
        {
            case 0:
                toggleObject.GetComponent<InfoBoxContentChange>().textState++;
                break;
            case 1:
                toggleObject.GetComponent<InfoBoxContentChange>().textState++;
                break;
            case 2:
                toggleObject.GetComponent<InfoBoxContentChange>().textState++;
                break;
            case 3:
                toggleObject.GetComponent<InfoBoxContentChange>().textState = 3;
                break;
            default:
                Debug.Log("something happened");
                break;
        }
    }

    private void ClickBack()
    {
        switch (toggleObject.GetComponent<InfoBoxContentChange>().textState)
        {
            case 0:
                toggleObject.GetComponent<InfoBoxContentChange>().textState = 0;
                break;
            case 1:
                toggleObject.GetComponent<InfoBoxContentChange>().textState--;
                break;
            case 2:
                toggleObject.GetComponent<InfoBoxContentChange>().textState--;
                break;
            case 3:
                toggleObject.GetComponent<InfoBoxContentChange>().textState--;
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

