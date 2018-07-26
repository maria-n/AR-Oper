﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity;
using HoloToolkit.Unity.InputModule;

public class AirTapHandler : Singleton<AirTapHandler> , IInputClickHandler {
    //private Color defaultColor;
    private GameObject toggledObject;

    // Use this for initialization
    protected override void Awake()
    {
        //defaultColor = gameObject.GetComponent<MeshRenderer>().material.color;
        toggledObject = GameObject.Find(this.name+"/ToggleInfo");
    }

    // Update is called once per frame
    void Update () {
		
	}

    public void OnInputClicked(InputClickedEventData eventData)
    {
        Debug.Log(toggledObject);

        if (toggledObject.activeInHierarchy == true)
        {
            Debug.Log("deactivate");
            toggledObject.SetActive(false);
        }
        else
        {
            Debug.Log("activate");
            toggledObject.SetActive(true);
        }
    }
}