using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WordInputPanelScript : MonoBehaviour
{
    public int nbCadran;
    public Button WordInput_btn;

    public TextMeshProUGUI txt_title;
    public TextMeshProUGUI txt_name;
    public TMP_InputField if_name;
    public TextMeshProUGUI txt_PlaceholderName;
    public TextMeshProUGUI txt_description;
    public TMP_InputField if_description;
    public TextMeshProUGUI txt_PlaceholderDescription;

    public GameObject compassMarkPrefab;

    public GameObject instanceMark;

    public Transform boussoleUI;

    public Vector3 compassMarkPos;

    public float markMaxReach;
    public float markMinDistanceFrom0;

    public Canvas canvas;
    public GameObject[] marksParents;
        
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
                txt_title.text = "Ajouter une action de fuite";
                txt_PlaceholderName.text = "Entrez le nom de l'action de fuite";
                txt_PlaceholderDescription.text = "Décrivez cette action de fuite. Quand/comment est-ce que vous l'accomplissez ? Pourquoi cette action en particulier ? Ajoutez autant de détails que vous voulez en utilisant vos mots";
                break;
            case 1:
                txt_title.text = "Ajouter une action qui vous rapproche d'une personne/valeur importante pour vous";
                txt_PlaceholderName.text = "Entrez le nom de l'action ";
                txt_PlaceholderDescription.text = "Décrivez cette action. En quoi cette action vous rapproche d'une personne ou d'une valeur importante pour vous ? Quand l'avez-vous fait pour la première fois ? Ajoutez autant de détails que vous voulez en utilisant vos mots";
                break;
            case 2:
                txt_title.text = "Ajouter une personne/valeur importante";
                txt_PlaceholderName.text = "Entrez le nom de la personne ou de la valeur ";
                txt_PlaceholderDescription.text = "Décrivez cette personne ou cette valeur. Pourquoi est-elle importante pour vous ? Quels souvenirs vous viennent en tête ? Qu'est-ce que vous aimez chez elle ? Ajoutez autant de détails que vous voulez en utilisant vos mots";
                break;
            case 3:
                txt_title.text = "Ajouter une pensée neutralisante";
                txt_PlaceholderName.text = "Entrez un nom pour cette pensée ";
                txt_PlaceholderDescription.text = "Décrivez cette pensée. Pourquoi cette action en particulier ? En quoi vous aide-t-elle à fuir ? En quoi vous est-elle négative ? Ajoutez autant de détails que vous voulez en utilisant vos mots";
                break;
            default:
                txt_title.text = "ERROR";
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
                txt_title.text = "ERROR";
                break;
        }
        instanceMark = Instantiate(compassMarkPrefab, compassMarkPos, Quaternion.identity);
        instanceMark.transform.SetParent(canvas.transform, false);
        instanceMark.GetComponentInChildren<TextMeshProUGUI>().text = if_name.text;
        instanceMark.transform.SetParent(marksParents[nbCadran].transform, true);
        instanceMark.GetComponent<MarkBehaviour>().markName = txt_name.text;
        instanceMark.GetComponent<MarkBehaviour>().markDescription = txt_description.text;
        gameObject.SetActive(false);
    }
}
