using HoloToolkit.Unity;
using HoloToolkit.Unity.InputModule;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GazeHandler : Singleton<GazeHandler> {
    private Color startColor = Color.clear;
    private GazeManager gazeManager;
    private GameObject currentObject;

    // Use this for initialization
    void Start()
    {
        gazeManager = GameObject.Find("Cursor").GetComponent<GazeManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gazeManager.HitObject != null)
        {
            currentObject = gazeManager.HitObject;
            Material com = gazeManager.HitObject.GetComponent<Renderer>().material;
            com.color = Color.yellow;
        }
        else
        {
            Material com = currentObject.GetComponent<Renderer>().material;
            com.color = startColor;
        }
    }
}
