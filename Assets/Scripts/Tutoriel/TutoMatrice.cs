﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class TutoMatrice : MonoBehaviour, IPointerDownHandler
{
    public GameObject compassMark;

    public GameObject[] obj_NewInputWord;
    //public GameObject obj_palette;

    private int screenWidthMid;
    private int screenHeightMid;

    public Vector3 mousePosMarker;

    public bool isInputPanelActive;

    public List<GameObject> inputPanels;
    public int nbMarksLeft;
    public int nbMarksRight;

    void Start()
    {
        screenWidthMid = Screen.width / 2;
        screenHeightMid = Screen.height / 2;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (!isInputPanelActive)
        {
            if (Input.mousePosition.x < screenWidthMid)
            {
                obj_NewInputWord[0].SetActive(true);
                nbMarksLeft++;
            }
            else if (Input.mousePosition.x >= screenWidthMid)
            {
                obj_NewInputWord[1].SetActive(true);
                nbMarksRight++;
            }
            mousePosMarker = new Vector3(Input.mousePosition.x - screenWidthMid, Input.mousePosition.y - screenHeightMid, 0);
            isInputPanelActive = true;
        }
    }

}