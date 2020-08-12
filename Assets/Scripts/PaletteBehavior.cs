using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PaletteBehavior : MonoBehaviour
{
    public Color[] colorsPalette;
    public Button[] paletteButtons;
    public Image currentMark;
    public GameObject[] selectionSquare;

    public bool firstEnable = true;
    private int index;
    public Color selectedColor;

    // Start is called before the first frame update
    private void OnEnable()
    {
        if (firstEnable)
        {
            foreach (Button aButtonOnPalette in paletteButtons)
            {
                aButtonOnPalette.GetComponent<Image>().color = colorsPalette[index];
                index++;
            }
            index = 0;
            selectedColor = colorsPalette[0];
            firstEnable = false;
        }
        selectionSquare[index].SetActive(true);
    }

    public void ColorSelect(int nbButton)
    {
        selectionSquare[index].SetActive(false);
        index = nbButton;
        selectedColor = colorsPalette[index];
        selectionSquare[index].SetActive(true);
    }

    // Update is called once per frame
    public void ColorEntry()
    {
        if (currentMark != null)
        { currentMark.color = selectedColor; }
        gameObject.SetActive(false);
    }
}
