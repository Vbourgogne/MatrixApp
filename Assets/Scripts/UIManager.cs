using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public GameObject[] uIObjects;
    public Button[] homeUIButtons;


    public GameObject HomeUI;
    public GameObject BoussoleUI;
    public GameObject AikidoUI;
    public GameObject SuccesUI;
    public GameObject ReglagesUI;
    public GameObject BackHome;
    public GameObject obj_ArrosezMessage;

    public Button btn_Boussole;
    public Button btn_Aikido;
    public Button btn_BackHome;
    public Button btn_Succes;

    public ScoreManager scoreScript;
    public ArrosoirButtonScript arrosageScript;
    
    void Start()
    {
        scoreScript = Camera.main.GetComponent<ScoreManager>();
        uIObjects[0].SetActive(true);
        //ActivateUI(true, false, false, false, false, false);
        for (int i = 0; i < homeUIButtons.Length-1; i++)
        {
            homeUIButtons[i].onClick.AddListener(delegate { ActivateUI(uIObjects[i], i); });
            Debug.Log(homeUIButtons[i] + " " + uIObjects[i]);
        }

        //btn_Boussole.onClick.AddListener(delegate { ActivateUI(false, true, false, false, false, true); });
        //btn_Aikido.onClick.AddListener(delegate { ActivateUI(false, false, true, false, false, true); });
        //btn_Succes.onClick.AddListener(delegate { ActivateUI(false, false, false, true, false, true); });
        //btn_BackHome.onClick.AddListener(delegate { ActivateUI(true, false, false, false, false, false); });

        if (scoreScript.arrosoirScore > 0) // si le score de l'arrosoir est supérieur à 0, montrer le message d'arrosage
        {
            obj_ArrosezMessage.SetActive(true);
        }
    }

    public void ActivateUI(GameObject objectToActivate, int test)
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
        Debug.Log("Index appuyé : " + test);
    }
}
