using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity;
using HoloToolkit.Unity.InputModule;


public class PlaceableStage : Singleton<PlaceableStage> {
    private GazeManager gazeManager;

    // Use this for initialization
    void Start () {
        gazeManager = GameObject.Find("DefaultCursor").GetComponent<GazeManager>();
    }

    // Update is called once per frame
    void Update () {
		
	}

    // Raycast ignore collider of obj 
    // what does it collide with
    // align normals of obj with plane
    // set obj z to plane z
}
