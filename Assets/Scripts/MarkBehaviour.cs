using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MarkBehaviour : MonoBehaviour
{
    public string markName;
    public string markDescription;

    public GameObject obj_description;

    public TextMeshProUGUI txt_name;
    public TextMeshProUGUI txt_description;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(DisplayDescription);

    }

    // Update is called once per frame
    void Update()
    {
    }

    public void DisplayDescription()
    {
        obj_description.SetActive(true);
        txt_name.text = markName;
        txt_description.text = markDescription;
    }
}
