using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugScript : MonoBehaviour
{
    private ScoreManager scoreScript;
    public int scoreToAddArrosoir;
    public int scoreToAddTotem;

    private void Start()
    {
        scoreScript = GetComponent<ScoreManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) // ajoute des points au score de l'arrosoir
        {
            scoreScript.ArrosoirScoreUpdate(scoreToAddArrosoir);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2)) // ajoute des points au score du totem
        {
            scoreScript.TotemScoreUpdate(scoreToAddTotem);
        }
        if (Input.GetKeyDown(KeyCode.R)) //reset le score de l'arrosoir et du totem à 0
        {
            scoreScript.TotemScoreUpdate(- scoreScript.totemScore); 
            scoreScript.ArrosoirScoreUpdate(- scoreScript.arrosoirScore);
        }
    }
}
