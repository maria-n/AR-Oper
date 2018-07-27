using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity;
using HoloToolkit.Unity.InputModule;

public class FocusHandler : Singleton<FocusHandler> , IFocusable
{
    // to reset the color when object is not in focus
    private Color defaultColor;
    // to test if you can avoid colliders of specific child objects
    // private GazeManager gazeManager;
    // private GameObject avoidedObject;

    // Use this for initialization
    protected override void Awake ()
    { 
        defaultColor = gameObject.GetComponent<MeshRenderer>().material.color;
        // Currently the color of the parent object changes, if the child object is focussed as well.
        // Need to find a way to ignore child object until otherwise specified

        // avoidedObject = GameObject.Find(this.name + "/ToggleInfo");
        // gazeManager = GameObject.Find("DefaultCursor").GetComponent<GazeManager>();
        // Physics.IgnoreCollision(avoidedObject.GetComponent<Collider>(), GetComponent<Collider>());
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    
    public void OnFocusEnter()
    {
        gameObject.GetComponent<MeshRenderer>().material.color = Color.blue;
    }

    public void OnFocusExit ()
    {
        gameObject.GetComponent<MeshRenderer>().material.color = defaultColor;
    }

}
