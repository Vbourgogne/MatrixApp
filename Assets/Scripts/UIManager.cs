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

    public Button Boussole_btn;
    public Button Aikido_btn;
    public Button BackHome_btn;


    // Start is called before the first frame update
    void Start()
    {
        ActivateUI(true, false, false, false, false, false);
        Boussole_btn.onClick.AddListener(delegate { ActivateUI(false, true, false, false, false, true); });
        Aikido_btn.onClick.AddListener(delegate { ActivateUI(false, false, true, false, false, true); });
        BackHome_btn.onClick.AddListener(delegate { ActivateUI(true, false, false, false, false, false); });

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
