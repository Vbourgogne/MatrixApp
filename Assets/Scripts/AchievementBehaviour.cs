using System.Collections;
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
    public Sprite[] achievementImages;
    public string[] achievementTexts;

    public void AchievementCheck(float variable, float condition, int indexAchievement)
    {
        if (variable >= condition)
        {
            achievementNotificationImage.sprite = achievementImages[indexAchievement];
            achievementNotificationText.text = achievementTexts[indexAchievement];
            achievementNotificationAnimator.SetTrigger("AchievementGet");

            achievementsUnlocked.Add(indexAchievement);
        }
    }
}
