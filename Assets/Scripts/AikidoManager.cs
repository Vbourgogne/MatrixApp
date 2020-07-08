using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AikidoManager : MonoBehaviour
{
    public GameObject[] AikidoScreens;
    public int indexScreens = 0;
    public GameObject currentScreen;
    public UIManager UIScript;

    // Start is called before the first frame update
    void Start()
    {
        foreach (GameObject screen in AikidoScreens)
        {
            screen.SetActive(false);
        }
        currentScreen = AikidoScreens[indexScreens];
        currentScreen.SetActive(true);
    }
    private void OnMouseDown()
    {
        Debug.Log("oui");
        ScreenChange();
    }
    // Update is called once per frame
    void ScreenChange()
    {
        if (indexScreens < AikidoScreens.Length - 1)
        {
            currentScreen.SetActive(false);
            indexScreens++;
            AikidoScreens[indexScreens].SetActive(true);
            currentScreen = AikidoScreens[indexScreens];
        }
        else
        {

        }
    }
}
