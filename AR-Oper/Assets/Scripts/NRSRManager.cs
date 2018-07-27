using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using HoloToolkit.Unity;

public class NRSRManager : MonoBehaviour {
    public Renderer[] ObjectsInScene;
    public List<GameObject> FilterObjectsInScene = new List<GameObject>();
    // Used to trigger next object update
    public int TotalNumberOfObjects = 0;
    public int PreviousFrameObjectCount = 0;

    // for debug: these nrs added together should always equal total nrs of objcets
    public int numberOfVisibleObjects;
    public int numberOfFilteredObjects;


    // declare new elements?
    private void FixedUpdate()
    {
        FindObjectsInScene(); // need to evaluate if needed

        TotalNumberOfObjects = ObjectsInScene.Length; // debug int now knows how many objects with a renderer are in the scene

        if (TotalNumberOfObjects != PreviousFrameObjectCount)
        {
            FilterUnneededObjects();
            numberOfVisibleObjects = FilterObjectsInScene.Count;

            foreach (GameObject go in FilterObjectsInScene)
            {
                // Todo Later
            }
        }

        PreviousFrameObjectCount = ObjectsInScene.Length;
    }

    void FindObjectsInScene()
    {
        // Fills array with every object that has a renderer attached
        ObjectsInScene = null;
        ObjectsInScene = FindObjectsOfType<Renderer>();
    }

    /// <summary>
    /// filters out all objects without specific tag
    /// </summary>
    void FilterUnneededObjects ()
    {
        FilterObjectsInScene.Clear();
        numberOfFilteredObjects = 0;

        
        for (int i = 0; i < ObjectsInScene.Length; i++)
        {
            if (ObjectsInScene[i].gameObject.tag != "NRSRTools")
            {
                FilterObjectsInScene.Add(ObjectsInScene[i].gameObject);
            }
            else
            {
                numberOfFilteredObjects++;
            }
        }
    }
}
