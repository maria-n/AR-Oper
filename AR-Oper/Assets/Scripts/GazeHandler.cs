using HoloToolkit.Unity;
using HoloToolkit.Unity.InputModule;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GazeHandler : Singleton<GazeHandler> {
    private Color startColor;
    private GazeManager gazeManager;
    private GameObject currentObject;

    protected override void Awake()
    {
        currentObject = gameObject;
        startColor = GetComponent<Renderer>().material.color;
    }

    void Start()
    {
        gazeManager = GameObject.Find("Cursor").GetComponent<GazeManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gazeManager.HitObject == currentObject)
        {
            //currentObject = gazeManager.HitObject;
            Material com = gazeManager.HitObject.GetComponent<Renderer>().material;
            com.color = Color.yellow;
        }
        else
        {
            Material com = this.GetComponent<Renderer>().material;
            com.color = startColor;
        }
    }
}
