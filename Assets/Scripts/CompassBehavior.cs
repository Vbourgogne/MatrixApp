using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CompassBehavior : MonoBehaviour
{
    public GameObject compassMark;
    public GameObject inputField;

    public GameObject instanceMark;
    public GameObject instanceInputField;

    private Camera cam1;
    public Canvas canvas;

    public float inputFieldX;
    public float inputFieldY;


    public Button btn_ActionsPositives;
    public Button btn_ActionsFuite;
    public Button btn_ValeursImportantes;
    public Button btn_PenseesNegatives;

    public GameObject inputWord_obj;

    // Start is called before the first frame update
    void Start()
    {
        cam1 = Camera.main;
        btn_ActionsFuite.onClick.AddListener(delegate { InputFieldSpawn(0); });
        btn_ActionsPositives.onClick.AddListener(delegate { InputFieldSpawn(1); });
        btn_ValeursImportantes.onClick.AddListener(delegate { InputFieldSpawn(2); });
        btn_PenseesNegatives.onClick.AddListener(delegate { InputFieldSpawn(3); });
    }

    // Update is called once per frame
    void Update()
    {

    }

    void InputFieldSpawn(int cadran)
    {
        inputWord_obj.SetActive(true);
        inputWord_obj.GetComponent<WordInputPanelScript>().nbCadran = cadran;
        inputWord_obj.GetComponent<WordInputPanelScript>().SetText();
        //inputWord.GetComponent<CompassInputBehavior>();
    }
}
