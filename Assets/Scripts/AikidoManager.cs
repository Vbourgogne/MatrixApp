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
    public Image[] screenCounters;
    public Color screenCounterTransparencyLow;
    public Color screenCounterTransparencyHigh;
    public float lerpValue;
    public float lerpTime;
    public bool isFading;

    // Start is called before the first frame update
    void Start()
    {
        AikidoFond = GetComponent<SpriteRenderer>();
        AikidoTMP.text = AikidoTexts[indexScreens];
        AikidoFond.color = AikidoColors[indexScreens];
        foreach (Image screenCounter in screenCounters)
        { screenCounter.color = screenCounterTransparencyLow; }
        screenCounters[indexScreens].color = screenCounterTransparencyHigh;
    }
    private void OnMouseDown()
    {
        if (!isFading)
        {
            ScreenChange();
        }
    }
    // Update is called once per frame
    void ScreenChange()
    {
        if (indexScreens < AikidoTexts.Length - 1)
        {
            isFading = true;
            screenCounters[indexScreens].color = screenCounterTransparencyLow;
            StartCoroutine(FadeColor(AikidoColors[indexScreens], AikidoColors[indexScreens + 1], lerpTime));
            indexScreens++;
            AikidoTMP.text = AikidoTexts[indexScreens];
            AikidoFond.color = AikidoColors[indexScreens];
            screenCounters[indexScreens].color = screenCounterTransparencyHigh;
        }
        else
        {
            screenCounters[indexScreens].color = screenCounterTransparencyLow;
            indexScreens = 0;
            AikidoTMP.text = AikidoTexts[indexScreens];
            AikidoFond.color = AikidoColors[indexScreens];
            screenCounters[0].color = screenCounterTransparencyHigh;
            UIScript.ActivateUI(true, false, false, false, false, false);
        }
    }

    public IEnumerator FadeColor(Color from,Color to, float lerpTimeCoroutine)
    {
        if(lerpValue < 1)
        {
            lerpValue += Time.deltaTime / lerpTimeCoroutine;
            AikidoFond.color = Color.Lerp(from, to, lerpValue);
            yield return new WaitForSeconds(0.001f);
            StartCoroutine(FadeColor(from, to, lerpTimeCoroutine));
        }
        else
        {
            isFading = false;
            lerpValue = 0;
        }
    }
}
