using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TutorialBehaviour : MonoBehaviour, IPointerDownHandler
{
    public int tutoStep;

    public Vector3 camPosTutoBegin;
    public Vector3 camPosTutoEnd;
    public GameObject fadingImage;
    public GameObject graine;
    public GameObject particles;
    public GameObject sakuraTree;
    public GameObject flowers;
    public float timeBeforeFirstMessage;
    public GameObject[][] tutoTexts;
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
    public RectTransform fondTexteTrans;
    public int indexArray;
    public int indexTextInArray;
    public bool canTextAdvance;
    public int textFondMargin;

    private void Start()
    {
        fadingImage.GetComponent<Animation>().Play();
        if(tutoStep == 0)
        {
            Instantiate(graine, new Vector3(0, 1.5f, 0), Quaternion.identity);
            //Camera.main.GetComponent<Transform>().position = new Vector3(camPosTutoBegin.x,camPosTutoBegin.y, camPosTutoBegin.z);
        }
       /* else
        {
            Camera.main.GetComponent<Transform>().position = new Vector3(camPosTutoEnd.x, camPosTutoEnd.y, camPosTutoEnd.z);
        }*/
        tutoTexts = new GameObject[12][];
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
        tutoTexts[10] = tutoTextsStep10;

        fondTexteTrans = transform.GetChild(0).GetComponent<RectTransform>();
        camPosTutoEnd = new Vector3(0, 1.527f, -4.66f); //15 0 0
        camPosTutoBegin = new Vector3(-0.13f, 1.22f, -1.58f); //35.56 4.49 0.261
        if (tutoStep == 0 )
        {
            StartCoroutine(GraineDrop());
        }
    }

    public IEnumerator GraineDrop()
    {
        yield return new WaitForSeconds(fadingImage.GetComponent<Animation>().clip.length);
        graine.GetComponent<Rigidbody>().isKinematic = false;
        yield return new WaitForSeconds(timeBeforeFirstMessage);
        tutoTexts[indexArray][indexTextInArray].SetActive(true);
        canTextAdvance = true;
        fondTexteTrans.gameObject.SetActive(true);
        fondTexteTrans.sizeDelta = new Vector2(tutoTexts[indexArray][indexTextInArray].GetComponent<RectTransform>().sizeDelta.x, tutoTexts[indexArray][indexTextInArray].GetComponent<RectTransform>().sizeDelta.y);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if(canTextAdvance)
        {
            TutorialNextStep();
        }
        if(indexArray == 0 && indexTextInArray == 3)
        { 
            graine.GetComponent<TutoGraineBehaviour>().canBeNudged = true;
            canTextAdvance = false;
        }
        else if (indexArray == 1 && indexTextInArray == 13)
        { 
            Camera.main.GetComponent<UIManager>().ActivateUI(Camera.main.GetComponent<UIManager>().uIObjects[2]);
            fondTexteTrans.gameObject.SetActive(false);
            tutoTexts[indexArray][indexTextInArray].SetActive(false);
            canTextAdvance = false;
        }

    }

    public void TutorialNextStep()
    {
        tutoTexts[indexArray][indexTextInArray].SetActive(false);
        if (indexTextInArray < tutoTexts[indexArray].Length - 1)
        {
            indexTextInArray++;
        }
        else
        {
            indexArray++;
            indexTextInArray = 0;
        }
        tutoTexts[indexArray][indexTextInArray].SetActive(true);
        fondTexteTrans.position = new Vector3(tutoTexts[indexArray][indexTextInArray].GetComponent<RectTransform>().position.x, tutoTexts[indexArray][indexTextInArray].GetComponent<RectTransform>().position.y);
        fondTexteTrans.sizeDelta = new Vector2(tutoTexts[indexArray][indexTextInArray].GetComponent<RectTransform>().sizeDelta.x + textFondMargin, tutoTexts[indexArray][indexTextInArray].GetComponent<RectTransform>().sizeDelta.y + textFondMargin);
    }

}
