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
    void OnMouseDown()
    {
        scoreScript.arrosageLoop = true;
        StartCoroutine(scoreScript.Arrosage());
    }

    private void OnMouseUp()
    {
        scoreScript.arrosageLoop = false ;
        scoreScript.ArrosageReset();
    }
    private void OnMouseExit()
    {
        scoreScript.arrosageLoop = false;
        scoreScript.ArrosageReset();
    }
}
