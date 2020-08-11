using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CompassBehavior : MonoBehaviour, IPointerDownHandler
{
    public GameObject compassMark;

    //public Button btn_HautGaucheCadran;
    //public Button btn_HautDroiteCadran;
    //public Button btn_BasDroiteCadran;
    //public Button btn_BasGaucheCadran;

    public GameObject[] obj_NewInputWord;

    //public event EventHandler OnDoubleTap;

    private int screenWidthMid;
    private int screenHeightMid;

    public Vector3 mousePosMarker;

    public bool isInputPanelActive;

    public List <GameObject> inputPanels;

    void Start()
    {
        screenWidthMid = Screen.width / 2;
        screenHeightMid = Screen.height / 2;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (!isInputPanelActive)
        {
            if (Input.mousePosition.y >= screenHeightMid && Input.mousePosition.x < screenWidthMid)
            {
                obj_NewInputWord[0].SetActive(true);
            }
            else if (Input.mousePosition.y >= screenHeightMid && Input.mousePosition.x >= screenWidthMid)
            {
                obj_NewInputWord[1].SetActive(true);
            }
            else if (Input.mousePosition.y < screenHeightMid && Input.mousePosition.x >= screenWidthMid)
            {
                obj_NewInputWord[2].SetActive(true);
            }
            else if (Input.mousePosition.y < screenHeightMid && Input.mousePosition.x < screenWidthMid)
            {
                obj_NewInputWord[3].SetActive(true);
            }
            mousePosMarker = new Vector3(Input.mousePosition.x - screenWidthMid, Input.mousePosition.y - screenHeightMid, 0);
            isInputPanelActive = true;
        }
    }
    
}
