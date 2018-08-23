using HoloToolkit.Unity;
using HoloToolkit.Unity.InputModule;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoBoxContentChange : Singleton <InfoBoxContentChange>
{
    private int infoState;
    private int textCountMax;
    private GameObject toggleObject;
    private GameObject currentToggledText;
    // public GameObject[] toggleObjects;
    // public GameObject[] toggledObjects;
    private GazeManager gazeManager;

    protected override void Awake()
    {
        toggleObject = GameObject.Find("InfoBox");
        currentToggledText = GameObject.Find(toggleObject + "/InfoBoxBG/InfoBoxText");
        // toggleObjects = GameObject.FindGameObjectsWithTag("ToggleObject");
        // toggledObjects = GameObject.FindGameObjectsWithTag("ToggledObject");
        textCountMax = 3;
        gazeManager = GameObject.Find("DefaultCursor").GetComponent<GazeManager>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ChangeInfoBox()
    {
        // throw new NotImplementedException();
        switch (gazeManager.HitObject.name)
        {
            case "ButtonForward":
                switch (infoState)
                {
                    case 0:
                        infoState++;
                        break;
                    case 1:
                        infoState++;
                        break;
                    case 2:
                        infoState++;
                        break;
                    case 3:
                        infoState = 0;
                        break;
                    default:
                        infoState = 0;
                        break;
                }
                break;
        }
        Debug.Log(infoState);
    }

    private void ToggleInfoBox()
    {
        throw new NotImplementedException();
    }
}
