using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NotifsSetupPanelBehaviour : MonoBehaviour
{
    public Button btn_NotifsSetup;
    public TMP_InputField[] randomNotifsInputFields;
    public int maxRangeInMinutes;
    public int hourBegin;
    public int minuteBegin;
    public int hourEnd;
    public int minuteEnd;
    public int nbNotifications;
    private TutorialBehaviour tutoScript;
    private AchievementBehaviour achievementScript;
    private ScoreManager scoreScript;
    // Start is called before the first frame update
    void Start()
    {
        btn_NotifsSetup.onClick.AddListener(NotifsSetup);
        tutoScript = transform.parent.GetComponent<TutorialBehaviour>();
        achievementScript = Camera.main.GetComponent<AchievementBehaviour>();
        scoreScript = Camera.main.GetComponent<ScoreManager>();
    }

    public void NotifsSetup()
    {
        hourBegin = int.Parse(randomNotifsInputFields[0].text);
        minuteBegin = int.Parse(randomNotifsInputFields[1].text);
        hourEnd = int.Parse(randomNotifsInputFields[2].text);
        minuteEnd = int.Parse(randomNotifsInputFields[3].text);
        nbNotifications = int.Parse(randomNotifsInputFields[4].text);

        if (hourBegin <= hourEnd)
        {
            maxRangeInMinutes = (hourEnd - hourBegin) * 60 + (minuteEnd-minuteBegin);
        }
        else
        {

        }
        for (int i = 0; i < nbNotifications; i++)
        {

        }
        achievementScript.AchievementCheck(1, 0, 33 + tutoScript.tutoStep);
        scoreScript.obj_arbre.GetComponent<ArrosoirButtonScript>().canTutoAdvance = true;
        gameObject.SetActive(false);
    }

}
