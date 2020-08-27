using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrosoirButtonScript : MonoBehaviour
{
    public ScoreManager scoreScript;
    public TutorialBehaviour tutoScript;
    public bool canTutoAdvance;

    void OnEnable()
    {
        scoreScript = Camera.main.GetComponent<ScoreManager>();
    }
    void OnMouseDown()
    {
        if(canTutoAdvance)
        { 
            tutoScript.TutorialNextStepEnableMessage();
            canTutoAdvance = false;
        }
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
