using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class AikidoManager : MonoBehaviour
{
    public TextMeshProUGUI AikidoTMP;
    public Color[] AikidoColors;
    public string[] AikidoTexts;
    public int indexScreens = 0;
    public UIManager UIScript;
    public SpriteRenderer AikidoFond;

    // Start is called before the first frame update
    void Start()
    {
        AikidoFond = GetComponent<SpriteRenderer>();
        AikidoTMP.text = AikidoTexts[indexScreens];
        AikidoFond.color = AikidoColors[indexScreens];
    }
    private void OnMouseDown()
    {
        ScreenChange();
    }
    // Update is called once per frame
    void ScreenChange()
    {
        if (indexScreens < AikidoTexts.Length - 1)
        {
            indexScreens++;
            AikidoTMP.text = AikidoTexts[indexScreens];
            AikidoFond.color = AikidoColors[indexScreens];
        }
        else
        {
            indexScreens = 0;
            AikidoTMP.text = AikidoTexts[indexScreens];
            AikidoFond.color = AikidoColors[indexScreens];
            UIScript.ActivateUI(true, false, false, false, false, false);
        }
    }
}
