using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public GameObject HomeUI;
    public GameObject BoussoleUI;
    public GameObject AikidoUI;
    public GameObject SuccesUI;
    public GameObject ReglagesUI;
    public GameObject BackHome;

    public Button btn_Boussole;
    public Button btn_Aikido;
    public Button btn_BackHome;


    // Start is called before the first frame update
    void Start()
    {
        ActivateUI(true, false, false, false, false, false);
        btn_Boussole.onClick.AddListener(delegate { ActivateUI(false, true, false, false, false, true); });
        btn_Aikido.onClick.AddListener(delegate { ActivateUI(false, false, true, false, false, true); });
        btn_BackHome.onClick.AddListener(delegate { ActivateUI(true, false, false, false, false, false); });

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ActivateUI(bool Home, bool Boussole, bool Aikido, bool Succes, bool Reglages, bool HomeButton)
    {
        HomeUI.SetActive(Home);
        BoussoleUI.SetActive(Boussole);
        AikidoUI.SetActive(Aikido);
        SuccesUI.SetActive(Succes);
        ReglagesUI.SetActive(Reglages);
        BackHome.SetActive(HomeButton);
    }
}
