using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrosoirButtonScript : MonoBehaviour
{
    public ScoreManager scoreScript;

    void Start()
    {
        scoreScript = Camera.main.GetComponent<ScoreManager>();
    }
    void OnMouseEnter()
    {
        scoreScript.arrosageLoop = true;
        StartCoroutine(scoreScript.Arrosage());
    }

    private void OnMouseExit()
    {
        scoreScript.arrosageLoop = false ;
    }
}
