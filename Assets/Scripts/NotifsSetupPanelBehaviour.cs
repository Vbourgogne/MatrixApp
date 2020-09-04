using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Notifications.Android;
using UnityEngine;
using UnityEngine.UI;

public class NotifsSetupPanelBehaviour : MonoBehaviour
{
    public Toggle toggleRandom;
    public Toggle toggleSoir;
    public Button btn_NotifsSetup;
    public TMP_InputField[] randomNotifsInputFields;
    public TMP_InputField[] eveningNotifsInputFields;
    public int maxRangeInMinutes;
    
    public int nbNotifications;
    public int hourBegin;
    public int minuteBegin;
    public int hourEnd;
    public int minuteEnd;

    private TutorialBehaviour tutoScript;
    private AchievementBehaviour achievementScript;
    private ScoreManager scoreScript;
    private TimeAndNotifsBehaviour notifsScript;

    // Start is called before the first frame update
    void Start()
    {
        btn_NotifsSetup.onClick.AddListener(NotifsSetup);
        tutoScript = transform.parent.GetComponent<TutorialBehaviour>();
        achievementScript = Camera.main.GetComponent<AchievementBehaviour>();
        scoreScript = Camera.main.GetComponent<ScoreManager>();
        notifsScript = Camera.main.GetComponent<TimeAndNotifsBehaviour>();
    }

    public void NotifsSetup()
    {
        if (toggleRandom.isOn)
        {
            nbNotifications = int.Parse(randomNotifsInputFields[0].text);
            hourBegin = int.Parse(randomNotifsInputFields[1].text);
            minuteBegin = int.Parse(randomNotifsInputFields[2].text);
            hourEnd = int.Parse(randomNotifsInputFields[3].text);
            minuteEnd = int.Parse(randomNotifsInputFields[4].text);
            notifsScript.heuresNotifsRandom = new int[nbNotifications, 2];

            if (hourBegin <= hourEnd)
            {
                maxRangeInMinutes = (hourEnd - hourBegin) * 60 + (minuteEnd - minuteBegin);
                for (int i = 0; i < nbNotifications; i++)
                {
                    var tempMinutes = Mathf.RoundToInt(Random.Range(0, maxRangeInMinutes));
                    var tempHours = Mathf.FloorToInt(tempMinutes / 60);
                    tempMinutes = tempMinutes % 60;
                    notifsScript.heuresNotifsRandom[i, 0] = hourBegin + tempHours;
                    notifsScript.heuresNotifsRandom[i, 1] = minuteBegin + tempMinutes;

                }
            }
            else
            {
                maxRangeInMinutes = 24 - (hourEnd - hourBegin) * 60 + (minuteEnd - minuteBegin);
                var nbMinutesToMidnight = 1440 - (hourBegin * 60 + minuteBegin);
                for (int i = 0; i < nbNotifications; i++)
                {
                    var tempMinutes = Mathf.RoundToInt(Random.Range(0, maxRangeInMinutes));
                    if (tempMinutes < nbMinutesToMidnight)
                    {
                        var tempHours = Mathf.FloorToInt(tempMinutes / 60);
                        tempMinutes = tempMinutes % 60;
                        notifsScript.heuresNotifsRandom[i, 0] = hourBegin + tempHours;
                        notifsScript.heuresNotifsRandom[i, 1] = minuteBegin + tempMinutes;
                    }
                    else
                    {
                        tempMinutes = tempMinutes - nbMinutesToMidnight;
                        var tempHours = Mathf.FloorToInt(tempMinutes / 60);
                        tempMinutes = tempMinutes % 60;
                        notifsScript.heuresNotifsRandom[i, 0] = tempHours;
                        notifsScript.heuresNotifsRandom[i, 1] = tempMinutes;
                    }
                    Debug.Log(notifsScript.heuresNotifsRandom[i, 0].ToString() + " h " + notifsScript.heuresNotifsRandom[i, 1].ToString());
                    notifsScript.NotificationsUpdate(nbNotifications, true, false);
                }
            }
        }
        if (toggleSoir.isOn)
        {
            notifsScript.heureNotifSoir[0] = int.Parse(eveningNotifsInputFields[0].text);
            notifsScript.heureNotifSoir[1] = int.Parse(eveningNotifsInputFields[1].text);
            notifsScript.NotificationsUpdate(1, false, true);
        }
        achievementScript.AchievementCheck(1, 0, 33 + tutoScript.tutoStep);
        scoreScript.obj_arbre.GetComponent<ArrosoirButtonScript>().canTutoAdvance = true;
        //notifsScript.NotificationsUpdate(nbNotifications, 0, 0);
        gameObject.SetActive(false);
    }

}
