using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity;
using HoloToolkit.Unity.InputModule;

public class FocusHandler : Singleton<FocusHandler> , IFocusable
{
    private Color defaultColor;

    // Use this for initialization
    protected override void Awake ()
    { 
        defaultColor = gameObject.GetComponent<MeshRenderer>().material.color;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    
    public void OnFocusEnter()
    {
        gameObject.GetComponentInParent<MeshRenderer>().material.color = Color.blue;
    }

    public void OnFocusExit ()
    {
        gameObject.GetComponentInParent<MeshRenderer>().material.color = defaultColor;
    }

}
