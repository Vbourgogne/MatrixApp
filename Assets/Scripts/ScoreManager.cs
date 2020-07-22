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

    //public float compteurTemps;
    public float timeBetweenIncrease;
    public int increases;
    public int incrementationStep;
    public bool arrosageLoop;

    public IEnumerator Arrosage()
    {
        if (arrosageLoop)
        {
            yield return new WaitForSecondsRealtime(timeBetweenIncrease);
            //compteurTemps += Time.deltaTime;
            if (arrosoirScore > 0)
            {
                ArrosoirScoreUpdate(-1);
                TotemScoreUpdate(+1);
                increases++;
                //compteurTemps = 0;
                if (increases >= incrementationStep)
                {
                    timeBetweenIncrease = timeBetweenIncrease / 2;
                    increases = 0;
                    incrementationStep *= 2;
                }
                StartCoroutine(Arrosage());
            }
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
