using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TutorialBehaviour : MonoBehaviour, IPointerDownHandler
{
    public int tutoStep;

    [Header("Vecteurs position et rotation Caméra")]
    public Vector3 camPosTuto;
    public Vector3 camRotTuto;
    public Vector3 camPosMain;
    public Vector3 camRotMain;

    [Header("Liens à faire gameObjects")]
    public GameObject fadingImage;
    public GameObject graine;
    public GameObject particles;
    public GameObject sakuraTree;
    public GameObject flowers;
    public float timeBeforeFirstMessage;

    private GameObject[][] tutoTexts;
    [Header("Obj textes pour ce que dit le totem")]
    public GameObject[] tutoTextsIntro;
    public GameObject[] tutoTextsStep1;
    public GameObject[] tutoTextsStep2;
    public GameObject[] tutoTextsStep3;
    public GameObject[] tutoTextsStep4;
    public GameObject[] tutoTextsStep5;
    public GameObject[] tutoTextsStep6;
    public GameObject[] tutoTextsStep7;
    public GameObject[] tutoTextsStep8;
    public GameObject[] tutoTextsStep9;
    public GameObject[] tutoTextsStep10;

    private int[][] indexEtapes;
    [Header("index Textes pour 0 : Mise à l'épreuve 1: Texte Choix choix puis message de l'arbre et 2 : joueur libéré ")]
    public int[] indexEtapesStep1;
    public int[] indexEtapesStep2;
    public int[] indexEtapesStep3;
    public int[] indexEtapesStep4;
    public int[] indexEtapesStep5;
    public int[] indexEtapesStep6;
    public int[] indexEtapesStep7;
    public int[] indexEtapesStep8;
    public int[] indexEtapesStep9;
    public int[] indexEtapesStep10;

    [Header("Liste des gameObject parents avec les contenus pour la mise à l'épreuve à chaque étape")]
    public GameObject[] gameObjectsTestTuto;

    public int indexTextInArray;
    public bool canTextAdvance;
    public int textFondMargin;

    private RectTransform fondTexteTrans;
    private Transform camTrans;
    private UIManager uiScript;
    private AchievementBehaviour achievementScript;
    public Image tutoHitbox;

    private void Start()
    {
        camTrans = Camera.main.GetComponent<Transform>();
        uiScript = Camera.main.GetComponent<UIManager>();
        achievementScript = Camera.main.GetComponent<AchievementBehaviour>();
        fondTexteTrans = transform.GetChild(0).GetComponent<RectTransform>();
        tutoHitbox = GetComponent<Image>();
        fadingImage.GetComponent<Animation>().Play();

        tutoTexts = new GameObject[10][];
        tutoTexts[0] = tutoTextsIntro;
        tutoTexts[1] = tutoTextsStep1;
        tutoTexts[2] = tutoTextsStep2;
        tutoTexts[3] = tutoTextsStep3;
        tutoTexts[4] = tutoTextsStep4;
        tutoTexts[5] = tutoTextsStep5;
        tutoTexts[6] = tutoTextsStep6;
        tutoTexts[7] = tutoTextsStep7;
        tutoTexts[8] = tutoTextsStep8;
        tutoTexts[9] = tutoTextsStep9;

        indexEtapes = new int[10][];
        indexEtapes[1] = indexEtapesStep1;
        indexEtapes[2] = indexEtapesStep2;
        indexEtapes[3] = indexEtapesStep3;
        indexEtapes[4] = indexEtapesStep4;
        indexEtapes[5] = indexEtapesStep5;
        indexEtapes[6] = indexEtapesStep6;
        indexEtapes[7] = indexEtapesStep7;
        indexEtapes[8] = indexEtapesStep8;
        indexEtapes[9] = indexEtapesStep9;

        if (tutoStep == 0)
        {
            camTrans.position = camPosTuto;
            camTrans.rotation = Quaternion.Euler(camRotTuto);
            StartCoroutine(GraineDrop());
        }
        else
        {
            camTrans.position = camPosMain;
            camTrans.rotation = Quaternion.Euler(camRotMain);
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (canTextAdvance)
        {
                if (tutoStep != 0 && indexTextInArray == indexEtapes[tutoStep][0])
                {
                    TutorialNextStepDisableMessage(false, false);
                    tutoHitbox.enabled = false;
                    gameObjectsTestTuto[tutoStep].SetActive(true);
                }
                else if (tutoStep != 0 && indexTextInArray == indexEtapes[tutoStep][1])
                {
                    //disable text et afficher le choix de quand seront les notifications
                    TutorialNextStepDisableMessage(false, false);

                }
                else if (tutoStep != 0 && indexTextInArray == indexEtapes[tutoStep][2])
                {
                    //disable text et laisser le joueur libre en lui donnant la nouvelle option qu'il vient d'acquérir
                    TutorialNextStepDisableMessage(false, false);
                    achievementScript.AchievementCheck(1, 0, 34 + tutoStep);
                }
                else
                    TutorialNextStepDisableMessage(true, true);
        }

        if(tutoStep == 0 && indexTextInArray == 4)
        { 
            graine.GetComponent<TutoGraineBehaviour>().canBeNudged = true;
            canTextAdvance = false;
        }
        /*else if (tutoStep == 1 && indexTextInArray == 13) // A SUPPRIMER
        { 
            uiScript.ActivateUI(uiScript.uIObjects[2]);
            TutorialNextStepDisableMessage(false, false);
        }*/
    }

    public IEnumerator GraineDrop()
    {
        yield return new WaitForSeconds(fadingImage.GetComponent<Animation>().clip.length);
        GameObject graineInstance = Instantiate(graine, new Vector3(0, 1.5f, 0), Quaternion.identity);
        graineInstance.GetComponent<TutoGraineBehaviour>().tutoScript = this;
        yield return new WaitForSeconds(timeBeforeFirstMessage);
        TutorialNextStepEnableMessage();
    }

    public void TutorialNextStepDisableMessage(bool enableNext, bool enableFond)
    {
        tutoTexts[tutoStep][indexTextInArray].SetActive(false);
        canTextAdvance = false;
        if(enableNext)
        {
            TutorialNextStepEnableMessage();
        }
        if (!enableFond)
        {
            fondTexteTrans.gameObject.SetActive(false);
        }
    }

    public void TutorialNextStepEnableMessage()
    {
        if (indexTextInArray < tutoTexts[tutoStep].Length - 1)
        {
            indexTextInArray++;
        }
        else
        {
            tutoStep++;
            indexTextInArray = 0;
        }
        if (!fondTexteTrans.gameObject.activeInHierarchy)
        { fondTexteTrans.gameObject.SetActive(true); }
        if (!tutoHitbox.enabled)
        { tutoHitbox.enabled = true; }
        fondTexteTrans.position = new Vector3(tutoTexts[tutoStep][indexTextInArray].GetComponent<RectTransform>().position.x, tutoTexts[tutoStep][indexTextInArray].GetComponent<RectTransform>().position.y);
        fondTexteTrans.sizeDelta = new Vector2(tutoTexts[tutoStep][indexTextInArray].GetComponent<RectTransform>().sizeDelta.x + textFondMargin, tutoTexts[tutoStep][indexTextInArray].GetComponent<RectTransform>().sizeDelta.y + textFondMargin);
        tutoTexts[tutoStep][indexTextInArray].SetActive(true);
        canTextAdvance = true;
    }
}
