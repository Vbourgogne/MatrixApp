using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WordInputPanelScript : MonoBehaviour
{
    public int nbCadran;
    public Button WordInput_btn;

    public TMP_InputField[] inputFields;
    public TMP_InputField if_InputPanelName;
    public TMP_InputField if_InputPanelDescription;

    public GameObject compassMarkPrefab;
    private GameObject instanceMark;
    public Vector3 compassMarkPos;

    public Canvas canvas;
    public GameObject marksParent;

    private MarkBehaviour instanceMarkBehaviour;
    public CompassBehavior compassScript;

    public ScoreManager scoreScript;
    public int scoreToAdd;

    public Transform inputPanelsParent;
    private GameObject cloneInputPanel;
    public bool modify;
    public GameObject currentMark;

    public PaletteBehavior paletteScript;
    public Button cancelPanel_btn;
    public GameObject obj_poubelle;

    private void Start()
    {
        WordInput_btn.onClick.AddListener(InputWord);
        cancelPanel_btn.onClick.AddListener(CancelPanel);
    }

    public void CancelPanel()
    {
        ResetInputFields();
        compassScript.isInputPanelActive = false;
        paletteScript.gameObject.SetActive(false);
        gameObject.SetActive(false);
    }

    public void InputWord()
    {
        if (if_InputPanelName.text != "")
        {
            if (!modify)
            {
                compassMarkPos = compassScript.mousePosMarker;
                if (if_InputPanelDescription.text != "")
                { scoreScript.ArrosoirScoreUpdate(scoreToAdd); } //ajouter le score si la description est remplie
                else
                { scoreScript.ArrosoirScoreUpdate(scoreToAdd / 2); } // ajoute la moitié du score si la description n'est pas remplie

                instanceMark = Instantiate(compassMarkPrefab, compassMarkPos, Quaternion.identity); // On crée le marqueur à l'endroit où l'user a cliqué
                instanceMark.transform.SetParent(canvas.transform, false);                          //Il est affecté au bon parent
                instanceMark.transform.SetParent(marksParent.transform, true);
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
                instanceMarkBehaviour.obj_palette = paletteScript.gameObject;
                instanceMarkBehaviour.obj_poubelle = obj_poubelle;
                instanceMark.GetComponentInChildren<TextMeshProUGUI>().text = inputFields[0].text; // Le nom entré apparaît sur le marqueur
                ResetInputFields(); //vide les inputfields du wordinputpanel originel
                WordInput_btn.GetComponentInChildren<TextMeshProUGUI>().text = "Ajouter";
                paletteScript.currentMark = instanceMark.GetComponentInChildren<Image>();
                if (nbCadran < 4)
                {
                    //ajouter 1 au nb marqueur tuto si c'est le cas
                    compassScript.AddMarkerAchievement(nbCadran);
                    compassScript.AddMarkerAchievement(4);
                }
                else
                {
                    compassScript.nbMarksMatriceTuto[nbCadran - 4]++;
                    CheckMarksTuto();
                }
            }
            else
            {
                currentMark.GetComponentInChildren<TextMeshProUGUI>().text = inputFields[0].text; // Le nom entré apparaît sur le marqueur
                paletteScript.currentMark = currentMark.GetComponentInChildren<Image>();
            }
            paletteScript.ColorEntry();
            compassScript.isInputPanelActive = false;
            gameObject.SetActive(false);
        }
    }

    private void ResetInputFields() //fonction qui reset les inputfields
    {
        foreach (TMP_InputField anInputField in inputFields)
        {
            anInputField.text = null;
        }
    }

    private void CheckMarksTuto()
    {
        if(nbCadran == 4 || nbCadran == 5)
        {
            if(compassScript.nbMarksMatriceTuto[0] >= 3 && compassScript.nbMarksMatriceTuto[1] >= 3)
            {
                compassScript.tutoScript.tutoHitbox.enabled = true;
                compassScript.tutoScript.gameObjectsTestTuto[compassScript.tutoScript.tutoStep].SetActive(false);
                compassScript.tutoScript.TutorialNextStepEnableMessage(); 
            }
        }
        else if (nbCadran == 6 || nbCadran == 7)
        {
            if (compassScript.nbMarksMatriceTuto[2] >= 3 && compassScript.nbMarksMatriceTuto[3] >= 3)
            {
                compassScript.tutoScript.tutoHitbox.enabled = true;
                compassScript.tutoScript.gameObjectsTestTuto[compassScript.tutoScript.tutoStep].SetActive(false);
                compassScript.tutoScript.TutorialNextStepEnableMessage(); 
            }
        }
    }
}
