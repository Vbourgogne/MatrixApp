using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CompassBehavior : MonoBehaviour, IPointerDownHandler
{
    public GameObject compassMark;

    public Button btn_HautGaucheCadran;
    public Button btn_HautDroiteCadran;
    public Button btn_BasDroiteCadran;
    public Button btn_BasGaucheCadran;

    public GameObject obj_inputWord;

    public event EventHandler OnDoubleTap;

    private int screenWidthMid;
    private int screenHeightMid;

    public void OnPointerDown(PointerEventData eventData)
    {
        if (Input.mousePosition.y >= screenHeightMid && Input.mousePosition.x < screenWidthMid)
        { Debug.Log("Haut-gauche"); }
        else if (Input.mousePosition.y >= screenHeightMid && Input.mousePosition.x >= screenWidthMid)
        { Debug.Log("Haut-droite"); }
        else if (Input.mousePosition.y < screenHeightMid && Input.mousePosition.x >= screenWidthMid)
        { Debug.Log("Bas-droite"); }
        else if (Input.mousePosition.y < screenHeightMid && Input.mousePosition.x < screenWidthMid)
        { Debug.Log("Bas-gauche"); }
    }

    // Start is called before the first frame update
    void Start() // pour chaque cadran, affecte la fonction avec le paramètre correspondant
    {
        btn_HautGaucheCadran.onClick.AddListener(delegate { InputFieldSpawn(0); });
        btn_HautDroiteCadran.onClick.AddListener(delegate { InputFieldSpawn(1); });
        btn_BasDroiteCadran.onClick.AddListener(delegate { InputFieldSpawn(2); });
        btn_BasGaucheCadran.onClick.AddListener(delegate { InputFieldSpawn(3); });

        screenWidthMid = Screen.width / 2;
        screenHeightMid = Screen.height / 2;
    }

    void InputFieldSpawn(int cadran) // active l'objet d'input de valeur, transmet le paramètre du cadran et fais changer le texte
    {
        obj_inputWord.SetActive(true);
        obj_inputWord.GetComponent<WordInputPanelScript>().nbCadran = cadran;
        obj_inputWord.GetComponent<WordInputPanelScript>().SetText();
    }
}
