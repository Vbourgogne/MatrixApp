using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchievementScript : MonoBehaviour
{
    public GameObject[] achievements;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void OnEnable()
    {
        AchievementCheck();
    }

    public void AchievementCheck()
    {
        foreach(GameObject succes in achievements)
        {
            if (succes.GetComponent<AchievementObjectBehavior>().isAchieved)
            {
                succes.GetComponent<AchievementObjectBehavior>().AchievementActivation();
            }
        }
    }
}
