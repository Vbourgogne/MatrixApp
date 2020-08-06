using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WordInputPanelScript : MonoBehaviour
{
    public int nbCadran;
    public Button WordInput_btn;

    public TextMeshProUGUI txt_InputPanelTitle;
    public TMP_InputField if_InputPanelName;
    public TextMeshProUGUI txt_PlaceholderName;
    public TMP_InputField if_InputPanelDescription;
    public TextMeshProUGUI txt_PlaceholderDescription;

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
    public int scoreAjouterMotCadranHautGauche;
    public int scoreAjouterMotCadranHautDroite;
    public int scoreAjouterMotCadranBasDroite;
    public int scoreAjouterMotCadranBasGauche;

    private void Start()
    {
        WordInput_btn.onClick.AddListener(InputWord);
    }

    public void InputWord()
    {
        compassMarkPos = compassScript.mousePosMarker;
        if (if_InputPanelName.text != "")
        {
            switch (nbCadran)
            {
                case 0:
                    if (if_InputPanelDescription.text != "")
                    { scoreScript.ArrosoirScoreUpdate(scoreAjouterMotCadranHautGauche); } //ajouter le score si la description est remplie
                    else
                    { scoreScript.ArrosoirScoreUpdate(scoreAjouterMotCadranHautGauche/2); } // ajoute la moitié du score si la description n'est pas remplie
                    break;
                case 1:
                    if (if_InputPanelDescription.text != "")
                    { scoreScript.ArrosoirScoreUpdate(scoreAjouterMotCadranHautDroite); }
                    else
                    { scoreScript.ArrosoirScoreUpdate(scoreAjouterMotCadranHautDroite / 2); }
                    break;
                case 2:
                    if (if_InputPanelDescription.text != "")
                    { scoreScript.ArrosoirScoreUpdate(scoreAjouterMotCadranBasDroite); }
                    else
                    { scoreScript.ArrosoirScoreUpdate(scoreAjouterMotCadranBasDroite / 2); }
                    break;
                case 3:
                    if (if_InputPanelDescription.text != "")
                    { scoreScript.ArrosoirScoreUpdate(scoreAjouterMotCadranBasGauche); }
                    else
                    { scoreScript.ArrosoirScoreUpdate(scoreAjouterMotCadranBasGauche / 2); }
                    break;
                default:
                    txt_InputPanelTitle.text = "ERROR";
                    break;
            }
            instanceMark = Instantiate(compassMarkPrefab, compassMarkPos, Quaternion.identity);
            instanceMark.transform.SetParent(canvas.transform, false);
            instanceMark.transform.SetParent(marksParents[nbCadran].transform, true);
            instanceMarkBehaviour = instanceMark.GetComponentInChildren<MarkBehaviour>();
            instanceMark.GetComponentInChildren<TextMeshProUGUI>().text = if_InputPanelName.text;
            instanceMarkBehaviour.obj_description = obj_DescriptionPanel;
            instanceMarkBehaviour.txt_MarkName = txt_MarkNameLink;
            instanceMarkBehaviour.txt_MarkDescription = txt_MarkDescriptionLink;
            instanceMarkBehaviour.markName = if_InputPanelName.text;
            instanceMarkBehaviour.markDescription = if_InputPanelDescription.text;
            if_InputPanelName.text = null;
            if_InputPanelDescription.text = null;
            gameObject.SetActive(false);
        } // instancie le marqueur, le met dans le bon "dossier", get son script, met les informations de l'inputpanel dans ce script
    }   // reset le texte des inputFields et désactive le gameobject
}       //
