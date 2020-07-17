using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public int arrosoirScore;
    public TextMeshProUGUI txt_ArrosoirScore;

    public int totemScore;
    public TextMeshPro txt_TotemScore;

    public Button btn_Arrosage;

    public float compteurTemps;
    public float timeBetweenIncrease;
    public int increases;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            ArrosoirScoreUpdate(5);
        }
        if (Input.GetKey(KeyCode.A))
        {
            compteurTemps += Time.deltaTime;
            if (compteurTemps >= timeBetweenIncrease && arrosoirScore > 0)
            {
                ArrosoirScoreUpdate(-1);
                TotemScoreUpdate(+1);
                increases++;
                compteurTemps = 0;
                if (increases >= 10)
                {
                    timeBetweenIncrease = timeBetweenIncrease / 2;
                    increases = 0;
                }
            }
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            compteurTemps = 0;
        }
    }

    public void ArrosoirScoreUpdate (int scoreToAddArrosoir)
    {
        arrosoirScore += scoreToAddArrosoir;
        txt_ArrosoirScore.text = "Arrosoir : " + arrosoirScore.ToString();
    }

    public void TotemScoreUpdate (int scoreToAddTotem)
    {
        totemScore += scoreToAddTotem;
        txt_TotemScore.text = totemScore.ToString();
    }
}
