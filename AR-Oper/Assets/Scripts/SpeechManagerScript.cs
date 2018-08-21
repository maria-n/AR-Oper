using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeechManagerScript : MonoBehaviour {
    private bool stagePlaceable = false;
    private Material stageMaterial;
    public Color editStageColor;
    public Color stageColor;
    //private Collider stageCollider;
    private Collider interactiveObjectsCollider;
    private GameObject debug;

    void Awake()
    {
        stageMaterial = this.transform.GetChild(0).GetComponent<Renderer>().material;
        // editStageColor = stageMaterial.color;
        // stageColor = new Color(255, 255, 255, 16);
        // stageCollider = GetComponent<Collider>();
        interactiveObjectsCollider = this.transform.GetChild(1).GetComponent<Collider>();
        // debug = this.transform.GetChild(1).gameObject;
        Debug.Log("Awake: " + this.gameObject);
    }


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	}

    public void toggleStage()
    {
        // if Stage is currently placeable
        if(stagePlaceable)
        {
            this.GetComponent<Collider>().enabled = false;
            this.transform.GetChild(0).GetComponent<Renderer>().material.color = stageColor;
            // interactiveObjectsCollider.enabled = true;
            stagePlaceable = false;
        }
        else // if Stage is not currently placeable
        {
            this.GetComponent<Collider>().enabled = true;
            this.transform.GetChild(0).GetComponent<Renderer>().material.color = editStageColor;
            // interactiveObjectsCollider.enabled = false;
            stagePlaceable = true;
        }
    }
}
