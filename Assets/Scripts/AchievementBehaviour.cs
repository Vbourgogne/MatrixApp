﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AchievementBehaviour : MonoBehaviour
{
    public List <int> achievementsUnlocked;
    public Animator achievementNotificationAnimator;

    public Image achievementNotificationImage;
    public TextMeshProUGUI achievementNotificationText;
    public TextMeshProUGUI achievementNotificationTitle;
    public Sprite[] achievementImages;
    public string[] achievementTexts;
    public string[] achievementTitles;
    private AchievementScreenBehaviour achievementScreenScript;

    private void Start()
    {
        achievementScreenScript = GetComponent<AchievementScreenBehaviour>();
    }

    public bool AchievementCheck(float variable, float condition, int indexAchievement) 
    {
        if (variable >= condition && !achievementsUnlocked.Contains(indexAchievement))
        {
            achievementNotificationImage.sprite = achievementImages[indexAchievement];
            achievementNotificationText.text = achievementTexts[indexAchievement];
            achievementNotificationTitle.text = achievementTitles[indexAchievement];
            achievementNotificationAnimator.SetTrigger("AchievementGet");
            achievementsUnlocked.Add(indexAchievement);
            achievementScreenScript.AchievementDisplay(indexAchievement);
                return true;
        }
        else 
        { return false; }
    }
}
