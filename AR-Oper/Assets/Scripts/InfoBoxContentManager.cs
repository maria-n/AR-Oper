using HoloToolkit.Unity;
using HoloToolkit.Unity.InputModule;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoBoxContentManager : MonoBehaviour
{
    public int textState;
    public int maxCount;
    private GameObject toggledText;

    private void Awake()
    {
        textState = 0;
        maxCount = 3;
        toggledText = GameObject.Find("InfoBox").transform.GetChild(0).GetChild(0).gameObject;
        Debug.Log("Awake: " + this.gameObject);
    }

    // Update is called once per frame
    void Update () {
		switch(textState)
        {
            case 0:
                toggledText.GetComponent<InfoBoxTextWrap>().NeedsLayout = true;
                toggledText.GetComponent<InfoBoxTextWrap>().UnwrappedText = "case 0 + 1";

                break;
            case 1:
                toggledText.GetComponent<InfoBoxTextWrap>().NeedsLayout = true;
                toggledText.GetComponent<InfoBoxTextWrap>().UnwrappedText = "case 1 + 1";

                break;
            case 2:
                toggledText.GetComponent<InfoBoxTextWrap>().NeedsLayout = true;
                toggledText.GetComponent<InfoBoxTextWrap>().UnwrappedText = "case 2 + 1";

                break;
            case 3:
                toggledText.GetComponent<InfoBoxTextWrap>().NeedsLayout = true;
                toggledText.GetComponent<InfoBoxTextWrap>().UnwrappedText = "case 3 + 1";

                break;
            default:
                toggledText.GetComponent<InfoBoxTextWrap>().NeedsLayout = true;
                toggledText.GetComponent<InfoBoxTextWrap>().UnwrappedText = "Ups";
                break;


        }
	}
}
