using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Notifications.Android;
using UnityEngine;
using UnityEngine.UI;

public class NotifsSetupPanelBehaviour : MonoBehaviour
{
    public Button btn_NotifsSetup;
    public TMP_InputField[] randomNotifsInputFields;
    public TMP_InputField[] eveningNotifsInputFields;
    public int maxRangeInMinutes;
    
    public int nbNotifications;
    public int hourBegin;
    public int minuteBegin;
    public int hourEnd;
    public int minuteEnd;

    public int hourEvening;
    public int minuteEvening;

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
        nbNotifications = int.Parse(randomNotifsInputFields[0].text);
        hourBegin = int.Parse(randomNotifsInputFields[1].text);
        minuteBegin = int.Parse(randomNotifsInputFields[2].text);
        hourEnd = int.Parse(randomNotifsInputFields[3].text);
        minuteEnd = int.Parse(randomNotifsInputFields[4].text);
        hourEvening = int.Parse(eveningNotifsInputFields[0].text);
        minuteEvening = int.Parse(eveningNotifsInputFields[1].text);
        notifsScript.heuresNotifs = new int[nbNotifications, 2];

        if (hourBegin <= hourEnd)
        {
            maxRangeInMinutes = (hourEnd - hourBegin) * 60 + (minuteEnd-minuteBegin);
            for (int i = 0; i < nbNotifications; i++)
            {
                var tempMinutes = Mathf.RoundToInt(Random.Range(0, maxRangeInMinutes));
                var tempHours = Mathf.FloorToInt(tempMinutes / 60);
                tempMinutes = tempMinutes % 60;
                notifsScript.heuresNotifs[i, 0] = hourBegin + tempHours;
                notifsScript.heuresNotifs[i, 1] = minuteBegin + tempMinutes;

            }
        }
        else
        {

        }
        achievementScript.AchievementCheck(1, 0, 33 + tutoScript.tutoStep);
        scoreScript.obj_arbre.GetComponent<ArrosoirButtonScript>().canTutoAdvance = true;
        //notifsScript.NotificationsUpdate(nbNotifications, 0, 0);
        gameObject.SetActive(false);
    }

}
