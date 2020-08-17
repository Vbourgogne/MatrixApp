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
        camPosTutoEnd = new Vector3(0, 1.527f, -4.66f);
        if (tutoStep == 0 )
        {
            fadingImage.GetComponent<Animation>().Play();
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
            tutoTexts[indexArray][indexTextInArray].SetActive(false);
            if (indexTextInArray < tutoTexts[indexArray].Length)
            {
                indexTextInArray++;
            }
            else
            {
                indexArray++;
                indexTextInArray = 0;
            }
            tutoTexts[indexArray][indexTextInArray].SetActive(true);
            fondTexteTrans.sizeDelta = new Vector2(tutoTexts[indexArray][indexTextInArray].GetComponent<RectTransform>().sizeDelta.x + textFondMargin, tutoTexts[indexArray][indexTextInArray].GetComponent<RectTransform>().sizeDelta.y + textFondMargin);
        }
    }

}
