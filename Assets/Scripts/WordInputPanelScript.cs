﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WordInputPanelScript : MonoBehaviour
{
    public int nbCadran;
    public Button WordInput_btn;

    public TMP_InputField[] inputFields;
    //public TextMeshProUGUI txt_InputPanelTitle;
    public TMP_InputField if_InputPanelName;
    //public TextMeshProUGUI txt_PlaceholderName;
    public TMP_InputField if_InputPanelDescription;
    //public TextMeshProUGUI txt_PlaceholderDescription;

    public GameObject compassMarkPrefab;
    private GameObject instanceMark;
    public Vector3 compassMarkPos;
    public float markMaxReach;
    public float markMinDistanceFrom0;

    public Canvas canvas;
    public GameObject[] marksParents;

    public GameObject obj_DescriptionPanel;
    public TextMeshProUGUI txt_MarkNameLink;
    public TextMeshProUGUI txt_MarkDescriptionLink;

    private MarkBehaviour instanceMarkBehaviour;
    public CompassBehavior compassScript;

    public ScoreManager scoreScript;
    public int scoreToAdd;

    public Transform inputPanelsParent;
    private GameObject cloneInputPanel;
    public bool modify;
    public GameObject currentMark;

    private void Start()
    {
        WordInput_btn.onClick.AddListener(InputWord);
    }

    public void InputWord()
    {
        if (!modify)
        {
            compassMarkPos = compassScript.mousePosMarker;
            if (if_InputPanelName.text != "")
            {
                if (if_InputPanelDescription.text != "")
                { scoreScript.ArrosoirScoreUpdate(scoreToAdd); } //ajouter le score si la description est remplie
                else
                { scoreScript.ArrosoirScoreUpdate(scoreToAdd / 2); } // ajoute la moitié du score si la description n'est pas remplie

            }
            instanceMark = Instantiate(compassMarkPrefab, compassMarkPos, Quaternion.identity); // On crée le marqueur à l'endroit où l'user a cliqué
            instanceMark.transform.SetParent(canvas.transform, false);                          //Il est affecté au bon parent
            instanceMark.transform.SetParent(marksParents[nbCadran].transform, true);
            instanceMarkBehaviour = instanceMark.GetComponentInChildren<MarkBehaviour>();
            WordInput_btn.GetComponentInChildren<TextMeshProUGUI>().text = "Modifier";

            cloneInputPanel = Instantiate(gameObject);                                          // L'inputPanel avec toutes ses informations est cloné et affecté au bon parent
            cloneInputPanel.transform.SetParent(canvas.transform, false);
            cloneInputPanel.transform.SetParent(inputPanelsParent);
            cloneInputPanel.GetComponent<WordInputPanelScript>().modify = true;
            compassScript.inputPanels.Add(cloneInputPanel);                                     //L'inputPanel cloné est mis dans la liste d'inputPanels avant d'être désactivé
            cloneInputPanel.SetActive(false);
            instanceMarkBehaviour.index = compassScript.inputPanels.Count - 1;                  //l'index de l'inputPanel est donné au marqueur correspondant
            instanceMarkBehaviour.compassScript = compassScript;
            ResetInputFields();
            compassScript.isInputPanelActive = false;
            WordInput_btn.GetComponentInChildren<TextMeshProUGUI>().text = "Ajouter";
            instanceMark.GetComponentInChildren<TextMeshProUGUI>().text = inputFields[0].text; // Le nom entré apparaît sur le marqueur
        }
        else
        {
            currentMark.GetComponentInChildren<TextMeshProUGUI>().text = inputFields[0].text;
        }
        // Le nom entré apparaît sur le marqueur
        //instanceMarkBehaviour.obj_description = obj_DescriptionPanel;
        //instanceMarkBehaviour.txt_MarkName = txt_MarkNameLink;
        //instanceMarkBehaviour.txt_MarkDescription = txt_MarkDescriptionLink;
        //instanceMarkBehaviour.markName = if_InputPanelName.text;
        //instanceMarkBehaviour.markDescription = if_InputPanelDescription.text;

        gameObject.SetActive(false);
        // instancie le marqueur, le met dans le bon "dossier", get son script, met les informations de l'inputpanel dans ce script
    }   // reset le texte des inputFields et désactive le gameobject

    private void ResetInputFields()
    {
        foreach (TMP_InputField anInputField in inputFields)
        {
            anInputField.text = null;
        }
    }
}
