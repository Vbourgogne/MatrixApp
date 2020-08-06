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
        isPointerDown = false;
    }

    public IEnumerator timePointerDown()
    {
        yield return new WaitForSeconds(Time.deltaTime);
        timePointerHeldDown += Time.deltaTime;
        if(isPointerDown)
        { StartCoroutine(timePointerDown()); }
    }
}
