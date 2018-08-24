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
    private GameObject textContent;

    private void Awake()
    {
        textState = 0;
        maxCount = 3;
        Debug.Log("Awake: " + this.gameObject);
    }

    private void Start()
    {
        textContent = GetComponentInParent<InfoBoxObjectManager>().toggledText;
    }

    // Update is called once per frame
    private void Update ()
    {
        ChangeInfoBoxText();
    }

    private void ChangeInfoBoxText()
    {
        switch (textState)
        {
            case 0:
                textContent.GetComponent<InfoBoxTextWrap>().NeedsLayout = true;
                textContent.GetComponent<InfoBoxTextWrap>().UnwrappedText = "case 0 + 1";

                break;
            case 1:
                textContent.GetComponent<InfoBoxTextWrap>().NeedsLayout = true;
                textContent.GetComponent<InfoBoxTextWrap>().UnwrappedText = "case 1 + 1";

                break;
            case 2:
                textContent.GetComponent<InfoBoxTextWrap>().NeedsLayout = true;
                textContent.GetComponent<InfoBoxTextWrap>().UnwrappedText = "case 2 + 1";

                break;
            case 3:
                textContent.GetComponent<InfoBoxTextWrap>().NeedsLayout = true;
                textContent.GetComponent<InfoBoxTextWrap>().UnwrappedText = "case 3 + 1";

                break;
            default:
                textContent.GetComponent<InfoBoxTextWrap>().NeedsLayout = true;
                textContent.GetComponent<InfoBoxTextWrap>().UnwrappedText = "Ups";
                break;


        }
    }
}
