using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Notifications.Android;
using UnityEngine;

public class TimeAndNotifsBehaviour : MonoBehaviour
{
    public TutorialBehaviour tutoScript;
    public Material[] skyboxes;
    public GameObject lucioles_particles;
    public int[,] heuresNotifs;
    public string[] notificationTitles;
    public string[] notificationDescriptions;
    public DateTime[] timeNotifications;
    public AndroidNotification[] notifications;
    private DateTime today;

    // Start is called before the first frame update
    void Start()
    {
        today = System.DateTime.Today;
        var mainNotificationChannel = new AndroidNotificationChannel()
        {
            Id = "mainChannel_id",
            Name = "Main Channel",
            Importance = Importance.Default,
            Description = "Main Channel for Notifications"
        };
        AndroidNotificationCenter.RegisterNotificationChannel(mainNotificationChannel);
        for (int i = 0; i < notifications.Length; i++)
        {
            notifications[i] = new AndroidNotification()
            {
                Title = notificationTitles[tutoScript.tutoStep],
                Text = notificationDescriptions[tutoScript.tutoStep],
                FireTime = new DateTime(1973, 3, 1, 0, 0, 0),
                SmallIcon = "icon_small",
                LargeIcon = "icon_large",
            };
        }
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
    public void NotificationsUpdate(int nbNotifications)
    {
        for (int i = 0; i < nbNotifications; i++)
        {
            timeNotifications[i] = new DateTime(today.Year, today.Month, today.Day, heuresNotifs[i, 0], heuresNotifs[i, 1], 0);
            notifications[i].Title = notificationTitles[tutoScript.tutoStep-1];
            notifications[i].Text = notificationDescriptions[tutoScript.tutoStep-1];
            notifications[i].FireTime = timeNotifications[i];
            AndroidNotificationCenter.SendNotification(notifications[i], "mainChannel_id");
        }
    }
}
