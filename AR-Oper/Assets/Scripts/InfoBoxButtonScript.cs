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
    private GameObject toggleObject;

    protected override void Awake()
    {
        defaultColor = this.GetComponent<Renderer>().material.color;
        defaultIcon = this.transform.GetChild(0).GetComponent<Renderer>().material.color;
        toggleObject = GameObject.Find("InfoBox");
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
        toggleObject.GetComponent<InfoBoxContentChange>().ChangeInfoBox();
    }
}

