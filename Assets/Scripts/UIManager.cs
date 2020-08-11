using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public GameObject[] uIObjects;
    public Button[] homeUIButtons;

    public GameObject obj_ArrosezMessage;

    public ScoreManager scoreScript;
    public ArrosoirButtonScript arrosageScript;
    
    void Start()
    {
        scoreScript = Camera.main.GetComponent<ScoreManager>();
        uIObjects[0].SetActive(true);

        if (scoreScript.arrosoirScore > 0) // si le score de l'arrosoir est supérieur à 0, montrer le message d'arrosage
        {
            obj_ArrosezMessage.SetActive(true);
        }
    }

    public void ActivateUI(GameObject objectToActivate)
    {
        foreach(GameObject UIObject in uIObjects)
        {
            if (UIObject.activeInHierarchy)
            { UIObject.SetActive(false); }
        }
        objectToActivate.SetActive(true);
        if (objectToActivate == uIObjects[0] && scoreScript.arrosoirScore > 0) // si le changement se fait vers le menu principal, activer le collider de l'arrosoir
        {                                                   // activer le message d'arrosage
            obj_ArrosezMessage.SetActive(true);
            arrosageScript.enabled = true;
        }
        if (objectToActivate != uIObjects[0]) // si ce n'est pas le menu principal, désactiver le collider de l'arrosoir
        {
            arrosageScript.enabled = false;
        }
    }
}
