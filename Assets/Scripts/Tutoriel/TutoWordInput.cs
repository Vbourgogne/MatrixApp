using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TutoWordInput : MonoBehaviour
{
    public int nbCadran;
    public Button WordInput_btn;

    public TMP_InputField[] inputFields;
    public TMP_InputField if_InputPanelName;

    public GameObject compassMarkPrefab;
    private GameObject instanceMark;
    public Vector3 compassMarkPos;

    public Canvas canvas;
    public GameObject[] marksParents;

    private TutoMarqueur instanceMarkBehaviour;
    public TutoMatrice compassScript;

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
        if (if_InputPanelName.text != "")
        {
            if (!modify)
            {
                compassMarkPos = compassScript.mousePosMarker;

                instanceMark = Instantiate(compassMarkPrefab, compassMarkPos, Quaternion.identity); // On crée le marqueur à l'endroit où l'user a cliqué
                instanceMark.transform.SetParent(canvas.transform, false);                          //Il est affecté au bon parent
                instanceMark.transform.SetParent(marksParents[nbCadran].transform, true);
                instanceMarkBehaviour = instanceMark.GetComponentInChildren<TutoMarqueur>();
                WordInput_btn.GetComponentInChildren<TextMeshProUGUI>().text = "Modifier";

                cloneInputPanel = Instantiate(gameObject);                                          // L'inputPanel avec toutes ses informations est cloné et affecté au bon parent
                cloneInputPanel.transform.SetParent(canvas.transform, false);
                cloneInputPanel.transform.SetParent(inputPanelsParent);
                cloneInputPanel.GetComponent<WordInputPanelScript>().modify = true;
                compassScript.inputPanels.Add(cloneInputPanel);                                     //L'inputPanel cloné est mis dans la liste d'inputPanels avant d'être désactivé
                cloneInputPanel.SetActive(false);
                instanceMarkBehaviour.index = compassScript.inputPanels.Count - 1;                  //l'index de l'inputPanel est donné au marqueur correspondant
                instanceMarkBehaviour.compassScript = compassScript;
                instanceMark.GetComponentInChildren<TextMeshProUGUI>().text = inputFields[0].text; // Le nom entré apparaît sur le marqueur
                ResetInputFields(); //vide les inputfields du wordinputpanel originel
                WordInput_btn.GetComponentInChildren<TextMeshProUGUI>().text = "Ajouter";
            }
            else
            {
                currentMark.GetComponentInChildren<TextMeshProUGUI>().text = inputFields[0].text; // Le nom entré apparaît sur le marqueur
            }
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
}
