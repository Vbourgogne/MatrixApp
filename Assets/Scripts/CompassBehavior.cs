using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CompassBehavior : MonoBehaviour
{
    public GameObject compassMark;

    public Button btn_HautGaucheCadran;
    public Button btn_HautDroiteCadran;
    public Button btn_BasDroiteCadran;
    public Button btn_BasGaucheCadran;

    public GameObject obj_inputWord;

    public event EventHandler OnDoubleTap;

    // Start is called before the first frame update
    void Start() // pour chaque cadran, affecte la fonction avec le paramètre correspondant
    {
        btn_HautGaucheCadran.onClick.AddListener(delegate { InputFieldSpawn(0); });
        btn_HautDroiteCadran.onClick.AddListener(delegate { InputFieldSpawn(1); });
        btn_BasDroiteCadran.onClick.AddListener(delegate { InputFieldSpawn(2); });
        btn_BasGaucheCadran.onClick.AddListener(delegate { InputFieldSpawn(3); });
    }

    void InputFieldSpawn(int cadran) // active l'objet d'input de valeur, transmet le paramètre du cadran et fais changer le texte
    {
        obj_inputWord.SetActive(true);
        obj_inputWord.GetComponent<WordInputPanelScript>().nbCadran = cadran;
        obj_inputWord.GetComponent<WordInputPanelScript>().SetText();
    }
}
