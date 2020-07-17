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

    // Start is called before the first frame update
    void Start()
    {
        btn_HautGaucheCadran.onClick.AddListener(delegate { InputFieldSpawn(0); });
        btn_HautDroiteCadran.onClick.AddListener(delegate { InputFieldSpawn(1); });
        btn_BasDroiteCadran.onClick.AddListener(delegate { InputFieldSpawn(2); });
        btn_BasGaucheCadran.onClick.AddListener(delegate { InputFieldSpawn(3); });
    }

    // Update is called once per frame
    void Update()
    {

    }

    void InputFieldSpawn(int cadran)
    {
        obj_inputWord.SetActive(true);
        obj_inputWord.GetComponent<WordInputPanelScript>().nbCadran = cadran;
        obj_inputWord.GetComponent<WordInputPanelScript>().SetText();
    }
}
