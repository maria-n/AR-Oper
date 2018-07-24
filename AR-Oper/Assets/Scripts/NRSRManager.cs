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

    private void FixedUpdate()
    {
        FindObjectsInScene(); // need to evaluate if needed

        TotalNumberOfObjects = ObjectsInScene.Length;

        if (TotalNumberOfObjects != PreviousFrameObjectCount)
        {
            FilterUnneededObjects();
            numberOfVisibleObjects = FilterObjectsInScene.Count;

            foreach (GameObject go in FilterObjectsInScene)
            {
                //Todo later
            }
        }

        PreviousFrameObjectCount = ObjectsInScene.Length;
    }

    void FindObjectsInScene()
    {
        ObjectsInScene = null;
        ObjectsInScene = FindObjectsOfType<Renderer>();
    }

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
