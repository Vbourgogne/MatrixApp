using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class MarkBehaviour : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public string markName;
    public string markDescription;

    public GameObject obj_description;

    public TextMeshProUGUI txt_MarkName;
    public TextMeshProUGUI txt_MarkDescription;

    public bool isPointerDown;
    public float timePointerHeldDown;
    public float timePointerHeldDownforLongTouch;
    public bool longHold;

    public Vector2 poubelleUpRight;
    public Vector2 poubelleLowLeft;

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

    public void DisplayDescription() // active l'objet pour montrer le nom et la description de la valeur, change le texte pour correspondre
    {
        obj_description.SetActive(true);
        txt_MarkName.text = markName;
        txt_MarkDescription.text = markDescription;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isPointerDown = true;
        StartCoroutine(timePointerDown());
    }

    public void OnPointerUp(PointerEventData eventData)
    {
            if (!longHold)
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
                        }
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
        if(timePointerHeldDown >= timePointerHeldDownforLongTouch)
        { longHold = true; }
        if(isPointerDown)
        { StartCoroutine(timePointerDown()); }
    }

    public Vector2 ScreenToUI(Vector2 vectorToConvert)
    {
        vectorToConvert += new Vector2 (Screen.width / 2, Screen.height / 2);
        return vectorToConvert;
    }
}
