using HoloToolkit.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GazeHandler : Singleton<GazeHandler> {
    private Color startColor;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit HitInfo;

        if (Physics.Raycast(
                Camera.main.transform.position,
                Camera.main.transform.forward,
                out HitInfo,
                20.0f,
                Physics.DefaultRaycastLayers))
        {
            var com = gameObject.GetComponent<Renderer>();
            startColor = com.material.color;
            com.material.color = Color.yellow;
            Debug.Log("Did Hit");
        }
        else
        {
            var com = gameObject.GetComponent<Renderer>();
            com.material.color = startColor;
            Debug.Log("Did Not Hit");
        }
            // If the Raycast has succeeded and hit a hologram
            // hitInfo's point represents the position being gazed at
            // hitInfo's collider GameObject represents the hologram being gazed at
    }
}
