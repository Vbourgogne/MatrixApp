using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class TutoMarqueur : MonoBehaviour
{
    public GameObject obj_palette;
    public int index;

    public bool isPointerDown;
    public float timePointerHeldDown;
    public float timePointerHeldDownforLongTouch;
    public bool longHold;

    public Vector2 poubelleUpRight;
    public Vector2 poubelleLowLeft;

    public TutoMatrice compassScript;

    private void OnEnable()
    {
        poubelleUpRight = ScreenToUI(poubelleUpRight);
        poubelleLowLeft = ScreenToUI(poubelleLowLeft);
    }
    private void Update()
    {
        if (longHold)
        {
            transform.parent.GetComponent<RectTransform>().position = Input.mousePosition;
        }
    }

    public void DisplayDescription() // Rouvre l'inputPanel et la Palette
    {
        compassScript.inputPanels[index].SetActive(true);
        obj_palette.SetActive(true);
        compassScript.inputPanels[index].GetComponent<WordInputPanelScript>().currentMark = transform.parent.gameObject;
        compassScript.isInputPanelActive = true;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isPointerDown = true;
        StartCoroutine(timePointerDown());
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (!longHold) // quand la souris est relâchée, affiche les données du marqueur si l'user ne reste pas longtemps
        { DisplayDescription(); }
        else
        {
            if (transform.parent.GetComponent<RectTransform>().position.x < poubelleUpRight.x)
            {
                if (transform.parent.GetComponent<RectTransform>().position.x > poubelleLowLeft.x)
                {
                    if (transform.parent.GetComponent<RectTransform>().position.y > poubelleLowLeft.y)
                    {
                        if (transform.parent.GetComponent<RectTransform>().position.y < poubelleUpRight.y)
                        {
                            Destroy(transform.parent.gameObject);
                        } //si l'user déplace le marqueur dans la poubelle, supprime le marqueur
                    }
                }
            }
            longHold = false;
        }
        isPointerDown = false;
        timePointerHeldDown = 0;
    }

    public IEnumerator timePointerDown()
    {
        yield return new WaitForSeconds(Time.deltaTime);
        timePointerHeldDown += Time.deltaTime;
        if (timePointerHeldDown >= timePointerHeldDownforLongTouch)
        { longHold = true; }
        if (isPointerDown)
        { StartCoroutine(timePointerDown()); }
    }

    public Vector2 ScreenToUI(Vector2 vectorToConvert)
    {
        vectorToConvert += new Vector2(Screen.width / 2, Screen.height / 2);
        return vectorToConvert;
    }
}
