using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialBehaviour : MonoBehaviour
{
    public int tutoStep;

    public Vector3 camPosTutoBegin;
    public Vector3 camPosTutoEnd;
    public GameObject fadingImage;
    public GameObject graine;
    public float timeBeforeFirstMessage;
    public GameObject[][] tutoTexts;
    public RectTransform fondTexteTrans;
    public int indexArray;
    public int indexTextInArray;
    public bool canTextAdvance;

    private void Start()
    {
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
    }

    private void OnMouseDown()
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
            fondTexteTrans.sizeDelta = new Vector2(tutoTexts[indexArray][indexTextInArray].GetComponent<RectTransform>().sizeDelta.x, tutoTexts[indexArray][indexTextInArray].GetComponent<RectTransform>().sizeDelta.y);
        }
    }

}
