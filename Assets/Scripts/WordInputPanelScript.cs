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
    //public TempRefScript temp;

    private void Start()
    {
        WordInput_btn.onClick.AddListener(InputWord);
    }

    // Start is called before the first frame update
    public void SetText()
    {
        switch (nbCadran)
        {
            case 0:
                txt_InputPanelTitle.text = "Ajouter une action de fuite";
                txt_PlaceholderName.text = "Entrez le nom de l'action de fuite";
                txt_PlaceholderDescription.text = "Décrivez cette action de fuite. Quand/comment est-ce que vous l'accomplissez ? Pourquoi cette action en particulier ? Ajoutez autant de détails que vous voulez en utilisant vos mots";
                break;
            case 1:
                txt_InputPanelTitle.text = "Ajouter une action qui vous rapproche d'une personne/valeur importante pour vous";
                txt_PlaceholderName.text = "Entrez le nom de l'action ";
                txt_PlaceholderDescription.text = "Décrivez cette action. En quoi cette action vous rapproche d'une personne ou d'une valeur importante pour vous ? Quand l'avez-vous fait pour la première fois ? Ajoutez autant de détails que vous voulez en utilisant vos mots";
                break;
            case 2:
                txt_InputPanelTitle.text = "Ajouter une personne/valeur importante";
                txt_PlaceholderName.text = "Entrez le nom de la personne ou de la valeur ";
                txt_PlaceholderDescription.text = "Décrivez cette personne ou cette valeur. Pourquoi est-elle importante pour vous ? Quels souvenirs vous viennent en tête ? Qu'est-ce que vous aimez chez elle ? Ajoutez autant de détails que vous voulez en utilisant vos mots";
                break;
            case 3:
                txt_InputPanelTitle.text = "Ajouter une pensée neutralisante";
                txt_PlaceholderName.text = "Entrez un nom pour cette pensée ";
                txt_PlaceholderDescription.text = "Décrivez cette pensée. Pourquoi cette action en particulier ? En quoi vous aide-t-elle à fuir ? En quoi vous est-elle négative ? Ajoutez autant de détails que vous voulez en utilisant vos mots";
                break;
            default:
                txt_InputPanelTitle.text = "ERROR";
                    break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InputWord()
    {
        switch (nbCadran)
        {
            case 0:
                compassMarkPos = new Vector3(-1*(Random.value*markMaxReach+markMinDistanceFrom0), Random.value * markMaxReach + markMinDistanceFrom0, 0);
                break;
            case 1:
                compassMarkPos = new Vector3(Random.value * markMaxReach + markMinDistanceFrom0, Random.value * markMaxReach + markMinDistanceFrom0, 0);
                break;
            case 2:
                compassMarkPos = new Vector3(Random.value * markMaxReach + markMinDistanceFrom0, -1*(Random.value * markMaxReach + markMinDistanceFrom0), 0);
                break;
            case 3:
                compassMarkPos = new Vector3(-1*(Random.value * markMaxReach + markMinDistanceFrom0), -1*(Random.value * markMaxReach + markMinDistanceFrom0), 0);
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
    }
}
