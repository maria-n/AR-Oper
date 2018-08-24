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
    private GameObject ToggledObject;
    private GazeManager gazeManager;

    protected override void Awake()
    {
        defaultColor = GetComponent<Renderer>().material.color;
        defaultIcon = transform.GetChild(0).GetComponent<Renderer>().material.color;
        ToggledObject = GetComponentInParent<InfoBoxObjectManager>().toggledObject;
        gazeManager = GameObject.Find("DefaultCursor").GetComponent<GazeManager>();

        Debug.Log("Awake: " + gameObject);
    }

    private void Start()
    {
        textCountMax = ToggledObject.GetComponent<InfoBoxContentManager>().maxCount;
    }

    // Update is called once per frame
    private void Update () {
        ChangeButtonAppeareance();   
    }

    private void ChangeButtonAppeareance()
    {
        switch (GetComponent<ObjectButton>().ButtonState.ToString())
        {
            case "Pressed":
                ChangeButtonPressed();
                break;
            case "Targeted":;
                ChangeButtonFocused();
                break;
            case "ObservationTargeted":
                ChangeButtonFocused();
                break;
        default:
                ChangeButtonDefault();
                break;
    }
}

    private void ChangeButtonPressed()
    {
        GetComponent<Renderer>().material.color = pressedColor;
        transform.GetChild(0).GetComponent<Renderer>().material.color = pressedIcon;
    }

    private void ChangeButtonFocused()
    {
        GetComponent<Renderer>().material.color = focusedColor;
        transform.GetChild(0).GetComponent<Renderer>().material.color = defaultIcon;
    }

    private void ChangeButtonDefault()
    {
        GetComponent<Renderer>().material.color = defaultColor;
        transform.GetChild(0).GetComponent<Renderer>().material.color = defaultIcon;
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
        switch (GetComponentInParent<InfoBoxContentManager>().textState)
        {
            case 0:
                GetComponentInParent<InfoBoxContentManager>().textState++;
                break;
            case 1:
                GetComponentInParent<InfoBoxContentManager>().textState++;
                break;
            case 2:
                GetComponentInParent<InfoBoxContentManager>().textState++;
                break;
            case 3:
                foreach(GameObject t_Object in GetComponentInParent<InfoBoxObjectManager>().allToggledObjects)
                {
                     t_Object.GetComponent<Renderer>().enabled = false;
                }
                GetComponentInParent<InfoBoxContentManager>().textState = 0;
                break;
            default:
                Debug.Log("something happened");
                break;
        }
    }

    private void ClickBack()
    {
        switch (GetComponentInParent<InfoBoxContentManager>().textState)
        {
            case 0:
                foreach (GameObject t_Object in GetComponentInParent<InfoBoxObjectManager>().allToggledObjects)
                {
                    t_Object.GetComponent<Renderer>().enabled = false;
                }
                GetComponentInParent<InfoBoxContentManager>().textState = 0;
                break;
            case 1:
                GetComponentInParent<InfoBoxContentManager>().textState--;
                break;
            case 2:
                GetComponentInParent<InfoBoxContentManager>().textState--;
                break;
            case 3:
                GetComponentInParent<InfoBoxContentManager>().textState--;
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

