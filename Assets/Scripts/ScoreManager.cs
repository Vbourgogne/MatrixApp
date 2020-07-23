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

    public GameObject obj_arbre;
    public GameObject obj_Arrosoire;
    public Renderer[] renderer_ArrosoireArray;
    public GameObject obj_ArrosezTexte;

    public float totemScale;

    private void Start()
    {
    }

    public IEnumerator Arrosage()
    {
        if (arrosageLoop)
        {
            yield return new WaitForSecondsRealtime(timeBetweenIncrease);
            if (arrosoirScore > 0)
            {
                ArrosoirScoreUpdate(-1);
                TotemScoreUpdate(+1);
                increases++;
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
        foreach (Renderer arrosoirePartRenderer in renderer_ArrosoireArray)
        { arrosoirePartRenderer.material.color = new Color(0, 0, arrosoirScore * 1.5f); }
        if (arrosoirScore == 0)
        { obj_ArrosezTexte.SetActive(false); }
    }

    public void TotemScoreUpdate (int scoreToAddTotem)
    {
        totemScore += scoreToAddTotem;
        txt_TotemScore.text = totemScore.ToString();
        totemScale = 0.35f + totemScore * (1.35f / 500);
        obj_arbre.transform.localScale = new Vector3 (totemScale, totemScale, totemScale);
    }
}
