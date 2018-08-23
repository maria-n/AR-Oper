using HoloToolkit.Unity;
using HoloToolkit.Unity.InputModule;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoBoxContentChange : MonoBehaviour
{
    public int textState;
    private void Awake()
    {
        textState = 0;
        Debug.Log("Awake: " + this.gameObject);
    }

    // Update is called once per frame
    void Update () {
		
	}
}
