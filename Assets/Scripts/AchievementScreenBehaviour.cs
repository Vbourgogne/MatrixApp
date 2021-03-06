﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AchievementScreenBehaviour : MonoBehaviour
{
    public AchievementBehaviour achievementScript;

    public GameObject[] obj_Achievements;

    public string lockedSuccessTitle;
    public Sprite lockedSuccessImage;
    public Color clr_FondSuccedActive;
    public Color clr_ImageSuccesActive;
    public Color clr_FondSuccesDesactive;
    public Color clr_ImageSuccesDesactive;
    public Image[] img_achievements;
    public TextMeshProUGUI[] tmp_Titres;
    public TextMeshProUGUI[] tmp_Descriptions;

    private int index;

    private void Awake()
    {
    }

    // Start is called before the first frame update
    void Start()
    {
        achievementScript = Camera.main.GetComponent<AchievementBehaviour>();
        AchievementsToNone();
    }

    private void OnEnable()
    {
        //AchievementDisplayCheck();
    }

    public void AchievementsToNone ()
    {
        foreach(GameObject anAchievement in obj_Achievements)
        {
            tmp_Titres[index] = obj_Achievements[index].transform.GetChild(0).GetComponent<TextMeshProUGUI>();
            tmp_Descriptions[index] = obj_Achievements[index].transform.GetChild(1).GetComponent<TextMeshProUGUI>();
            img_achievements[index] = obj_Achievements[index].transform.GetChild(2).GetComponent<Image>();
            img_achievements[index].color = clr_ImageSuccesDesactive;
            img_achievements[index].sprite = lockedSuccessImage;
            tmp_Titres[index].text = achievementScript.achievementTitles[index];
            tmp_Titres[index].text = lockedSuccessTitle;
            obj_Achievements[index].GetComponent<Image>().color = clr_FondSuccesDesactive;
            tmp_Descriptions[index].text = achievementScript.achievementTexts[index];
            index++;
        }
    }

    public void AchievementDisplay(int achievementUnlockedIndex)
    {
                img_achievements[achievementUnlockedIndex].sprite = achievementScript.achievementImages[achievementUnlockedIndex];
                img_achievements[achievementUnlockedIndex].color = clr_ImageSuccesActive;
                obj_Achievements[achievementUnlockedIndex].GetComponent<Image>().color = clr_FondSuccedActive;
                tmp_Titres[achievementUnlockedIndex].text = achievementScript.achievementTitles[achievementUnlockedIndex];
    }

        /*public void AchievementDisplayCheck()
        {
            if (achievementScript.achievementsUnlocked != null)
            {
                foreach (int achievementUnlockedIndex in achievementScript.achievementsUnlocked)
                {
                    img_achievements[achievementUnlockedIndex].sprite = achievementScript.achievementImages[achievementUnlockedIndex];
                    img_achievements[achievementUnlockedIndex].color = clr_ImageSuccesActive;
                    obj_Achievements[achievementUnlockedIndex].GetComponent<Image>().color = clr_FondSuccedActive;
                    tmp_Titres[achievementUnlockedIndex].text = achievementScript.achievementTitles[achievementUnlockedIndex];
                }
            }
        }*/
    }
