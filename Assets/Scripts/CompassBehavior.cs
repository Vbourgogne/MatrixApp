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

    public GameObject[] obj_NewInputWord;
    public GameObject obj_palette;
    public GameObject[] MatriceSteps;
    public int[] nbMarksMatriceTuto;
    public TutorialBehaviour tutoScript;

    private int screenWidthMid;
    private int screenHeightMid;

    public Vector3 mousePosMarker;

    public bool isInputPanelActive;

    public List <GameObject> inputPanels;

    public AchievementBehaviour achievementScript;
    [Header("Nombre de marqueurs total et par cadran")]
    public int nbMarkerGlobal;
    public int nbMarkerHG;
    public int nbMarkerHD;
    public int nbMarkerBD;
    public int nbMarkerBG;

    [Header("Listes nb marqueurs requis pour achievement")]
    public int[] conditionsAchievementGlobal;
    public int[] conditionsAchievementCadran;


    [Header("positions dans la liste des achievements")]
    public int indexConditionsGlobal;
    public int indexConditionsHG;
    public int indexConditionsHD;
    public int indexConditionsBD;
    public int indexConditionsBG;

    void Start()
    {
        screenWidthMid = Screen.width / 2;
        screenHeightMid = Screen.height / 2;
        achievementScript = Camera.main.GetComponent<AchievementBehaviour>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (!isInputPanelActive)
        {
            if (tutoScript.tutoStep == 1)
            {
                if (Input.mousePosition.x < screenWidthMid)
                {
                    obj_NewInputWord[4].SetActive(true);
                }
                else if (Input.mousePosition.x >= screenWidthMid)
                {
                    obj_NewInputWord[5].SetActive(true);
                }
            }
            else if (tutoScript.tutoStep == 2)
            {
                if (Input.mousePosition.y < screenHeightMid)
                {
                    obj_NewInputWord[6].SetActive(true);
                }
                else if (Input.mousePosition.y > screenHeightMid)
                {
                    obj_NewInputWord[7].SetActive(true);
                }
            }
            else if (tutoScript.tutoStep > 2)
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
            }
            obj_palette.SetActive(true);
            mousePosMarker = new Vector3(Input.mousePosition.x - screenWidthMid, Input.mousePosition.y - screenHeightMid, 0);
            isInputPanelActive = true;
        }
    }

    public void AddMarkerAchievement(int cadran)
    {
        switch (cadran)
        {
            case 0:
                nbMarkerHG++;
                if (indexConditionsHG < conditionsAchievementCadran.Length && achievementScript.AchievementCheck(nbMarkerHG, conditionsAchievementCadran[indexConditionsHG], 18 + indexConditionsHG))
                {
                    achievementScript.AchievementCheck(nbMarkerHG, conditionsAchievementCadran[indexConditionsHG], 18 + indexConditionsHG);
                    indexConditionsHG++;
                }
                break;
            case 1:
                nbMarkerHD++;
                if (indexConditionsHD < conditionsAchievementCadran.Length && achievementScript.AchievementCheck(nbMarkerHD, conditionsAchievementCadran[indexConditionsHD], 22 + indexConditionsHD))
                {
                    achievementScript.AchievementCheck(nbMarkerHD, conditionsAchievementCadran[indexConditionsHD], 22 + indexConditionsHD);
                    indexConditionsHD++;
                }
                break;
            case 2:
                nbMarkerBD++;
                if (indexConditionsBD < conditionsAchievementCadran.Length && achievementScript.AchievementCheck(nbMarkerBD, conditionsAchievementCadran[indexConditionsBD], 26 + indexConditionsBD))
                {
                    achievementScript.AchievementCheck(nbMarkerBD, conditionsAchievementCadran[indexConditionsBD], 26 + indexConditionsBD);
                    indexConditionsBD++;
                }
                break;
            case 3:
                nbMarkerBG++;
                if (indexConditionsBG < conditionsAchievementCadran.Length && achievementScript.AchievementCheck(nbMarkerBG, conditionsAchievementCadran[indexConditionsBG], 30 + indexConditionsBG))
                {
                    achievementScript.AchievementCheck(nbMarkerBG, conditionsAchievementCadran[indexConditionsBG], 30 + indexConditionsBG);
                    indexConditionsBG++;
                }
                break;
            case 4:
                nbMarkerGlobal++;
                if (indexConditionsGlobal < conditionsAchievementGlobal.Length && achievementScript.AchievementCheck(nbMarkerGlobal, conditionsAchievementGlobal[indexConditionsGlobal], 0 + indexConditionsGlobal))
                {
                    achievementScript.AchievementCheck(nbMarkerGlobal, conditionsAchievementGlobal[indexConditionsGlobal], 0 + indexConditionsGlobal);
                    indexConditionsGlobal++;
                }
                break;
            default:
                break;
        }

    }
    
}
