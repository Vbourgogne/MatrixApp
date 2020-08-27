using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeAndNotifsBehaviour : MonoBehaviour
{
    public Material[] skyboxes;
    public GameObject lucioles_particles;
    public int[,] heuresNotifs;

    

    // Start is called before the first frame update
    void Start()
    {
        if (System.DateTime.UtcNow.Hour > 5 && System.DateTime.UtcNow.Hour < 6)
        {
            RenderSettings.skybox = skyboxes[6];
            lucioles_particles.SetActive(true);
        }
        if (System.DateTime.UtcNow.Hour > 6 && System.DateTime.UtcNow.Hour < 7)
        {
            RenderSettings.skybox = skyboxes[7];
            lucioles_particles.SetActive(true);
        }
        if (System.DateTime.UtcNow.Hour > 7 && System.DateTime.UtcNow.Hour < 8)
        {
            RenderSettings.skybox = skyboxes[8];
        }
        if (System.DateTime.UtcNow.Hour > 8 && System.DateTime.UtcNow.Hour < 9)
        {
            RenderSettings.skybox = skyboxes[9];
        }
        if (System.DateTime.UtcNow.Hour > 9 && System.DateTime.UtcNow.Hour < 17)
        {
            RenderSettings.skybox = skyboxes[0];
        }
        else if (System.DateTime.UtcNow.Hour > 17 && System.DateTime.UtcNow.Hour < 18)
        {
            RenderSettings.skybox = skyboxes[1];
        }
        else if (System.DateTime.UtcNow.Hour > 18 && System.DateTime.UtcNow.Hour < 20)
        {
            RenderSettings.skybox = skyboxes[2];
        }
        else if (System.DateTime.UtcNow.Hour > 20 && System.DateTime.UtcNow.Hour < 21)
        {
            RenderSettings.skybox = skyboxes[3];
            lucioles_particles.SetActive(true);
        }
        else if (System.DateTime.UtcNow.Hour > 21 && System.DateTime.UtcNow.Hour < 22)
        {
            RenderSettings.skybox = skyboxes[4];
            lucioles_particles.SetActive(true);
        }
        else if (System.DateTime.UtcNow.Hour > 22 || System.DateTime.UtcNow.Hour < 5)
        {
            RenderSettings.skybox = skyboxes[5];
            lucioles_particles.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
