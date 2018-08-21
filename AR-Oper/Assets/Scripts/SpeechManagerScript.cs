using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeechManagerScript : MonoBehaviour {
    public bool stagePlaceable = false;
    private Material stageMaterial;
    public Color editStageColor;
    public Color stageColor;
    private Collider stageCollider;
    private Collider interactiveObjectsCollider;
    private GameObject debug;

    void Awake()
    {
        stageMaterial = this.transform.GetChild(0).GetComponent<Renderer>().material;
        // editStageColor = stageMaterial.color;
        // stageColor = new Color(255, 255, 255, 16);
        stageCollider = GetComponent<Collider>();
        interactiveObjectsCollider = this.transform.GetChild(1).GetComponent<Collider>();
        // debug = this.transform.GetChild(1).gameObject;
        Debug.Log("Awake: " + this.gameObject);
    }


    // Use this for initialization
    void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("b"))
        {
            toggleStage();
        }
    }

    public void toggleStage()
    {
        // if Stage is currently placeable
        if(stagePlaceable)
        {
            this.transform.GetChild(0).GetComponent<Renderer>().material.color = stageColor;
            // interactiveObjectsCollider.enabled = true;
            stageCollider.enabled = false;
            stagePlaceable = false;
        }
        else if (!stagePlaceable) // if Stage is not currently placeable
        {
            this.transform.GetChild(0).GetComponent<Renderer>().material.color = editStageColor;
            // interactiveObjectsCollider.enabled = false;
            stageCollider.enabled = true;
            stagePlaceable = true;
        }
    }
}
