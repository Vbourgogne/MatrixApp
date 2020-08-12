using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AchievementScreenBehaviour : MonoBehaviour
{
    public bool isAchieved;
    public float condition;

    public string titre;
    public string description;
    public Color clr_FondSuccesDesactive;
    public Color clr_ImageSuccesDesactive;


    public TextMeshProUGUI txt_AchievementTitle;
    public TextMeshProUGUI txt_AchievementDescription;
    public Image img_imageAchievement;


    // Start is called before the first frame update
    void Start()
    {
        txt_AchievementTitle.text = titre;
        txt_AchievementDescription.text = description;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AchievementActivation()
    {
        gameObject.GetComponent<Image>().color = clr_FondSuccesDesactive;
        transform.GetChild(2).GetComponent<Image>().color = clr_ImageSuccesDesactive;
    }
}
