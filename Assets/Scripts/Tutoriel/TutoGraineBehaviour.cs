using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutoGraineBehaviour : MonoBehaviour
{
    public int nbNudges;
    public int nbNudgesToTrigger;
    public TutorialBehaviour tutoScript;
    public bool canBeNudged;
    public ScoreManager scoreScript;

    private void OnEnable()
    {
        scoreScript = Camera.main.GetComponent<ScoreManager>();
    }

    private void OnMouseDown() //quand elle est cliquée nbNudgesToTrigger fois, lance GrainePop
    {
        if (canBeNudged)
        {
            if (nbNudges < nbNudgesToTrigger-1)
            {
                nbNudges++;
            }
            else
            {
                StartCoroutine(GrainePop());
                canBeNudged = false;
            }
        }
    }

    public IEnumerator GrainePop() // désactive l'affichage du message, lance l'animation de la caméra, fais pousser l'arbre d'un cran
    {
        tutoScript.TutorialNextStepDisableMessage(false, false);
        Camera.main.GetComponent<Animation>().Play();
        yield return new WaitForSeconds(Camera.main.GetComponent<Animation>().clip.length);
        scoreScript.TreeGrowth();
        tutoScript.canTextAdvance = true;
        tutoScript.TutorialNextStepEnableMessage();
    }
}
