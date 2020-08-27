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

    private void OnMouseDown()
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

    public IEnumerator GrainePop()
    {
        tutoScript.TutorialNextStepDisableMessage(false, false);
        Camera.main.GetComponent<Animation>().Play();
        yield return new WaitForSeconds(Camera.main.GetComponent<Animation>().clip.length);
        scoreScript.TreeGrowth();
        tutoScript.canTextAdvance = true;
        tutoScript.TutorialNextStepEnableMessage();
    }
}
