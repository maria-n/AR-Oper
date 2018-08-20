using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeechManagerScript : MonoBehaviour {
    private static bool created = false;
    public Collider stageCollider;
    void Awake()
    {
        stageCollider = GetComponent<Collider>();
        if (!created)
        {
            DontDestroyOnLoad(this.gameObject);
            created = true;
            Debug.Log("Awake: " + this.gameObject);
        }
    }


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void toggleStage()
    {
        if(stageCollider.enabled)
        {
            stageCollider.enabled = !stageCollider.enabled;
        }
        else
        {
            stageCollider.enabled = true;
        }
    }
}
