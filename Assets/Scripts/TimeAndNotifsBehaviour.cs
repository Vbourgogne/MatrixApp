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
    public int[] heureNotifSoir;
    public int[,] heuresNotifsRandom;
    public string[] notificationTitles;
    public string[] notificationDescriptions;
    public DateTime[] timeNotifications;
    public DateTime eveningNotificationTime;
    private AndroidNotification[] randomNotifications;
    private AndroidNotification eveningNotification;
    private DateTime today;

    // Start is called before the first frame update
    void Start()
    {
        today = System.DateTime.Today;
        heureNotifSoir = new int[2];

        var randomNotifsNotificationChannel = new AndroidNotificationChannel()
        {
            Id = "randomNotifsChannel_id",
            Name = "Random Notifications Channel",
            Importance = Importance.Default,
            Description = "Channel for random notifications"
        };
        AndroidNotificationCenter.RegisterNotificationChannel(randomNotifsNotificationChannel);
        var eveningNotifsNotificationChannel = new AndroidNotificationChannel()
        {
            Id = "eveningNotifsChannel_id",
            Name = "Evening Notifications Channel",
            Importance = Importance.Default,
            Description = "Channel for evening notifications"
        };
        AndroidNotificationCenter.RegisterNotificationChannel(eveningNotifsNotificationChannel);

            /*if (System.DateTime.UtcNow.Hour > 5 && System.DateTime.UtcNow.Hour < 6)
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
            }*/
    }
    public void NotificationsUpdate(int nbNotifications, bool sendRandomNotifs, bool sendEveningNotifs)
    {
        if (sendRandomNotifs)
        {
            randomNotifications = new AndroidNotification[nbNotifications];
            for (int i = 0; i < nbNotifications; i++)
            {
                timeNotifications[i] = new DateTime(today.Year, today.Month, today.Day, heuresNotifsRandom[i, 0], heuresNotifsRandom[i, 1], 0);
                randomNotifications[i].Title = notificationTitles[tutoScript.tutoStep - 1];
                randomNotifications[i].Text = notificationDescriptions[tutoScript.tutoStep - 1];
                randomNotifications[i].SmallIcon = "icon_small";
                randomNotifications[i].LargeIcon = "icon_large";
                randomNotifications[i].FireTime = timeNotifications[i];
                AndroidNotificationCenter.SendNotification(randomNotifications[i], "randomNotifsChannel_id");
            }
        }
        if (sendEveningNotifs)
        {
            eveningNotificationTime = new DateTime(today.Year, today.Month, today.Day, heureNotifSoir[0], heureNotifSoir[1], 0);
            eveningNotification.Title = "Notification du soir";
            eveningNotification.Title = notificationTitles[tutoScript.tutoStep - 1];
            eveningNotification.SmallIcon = "icon_small";
            eveningNotification.LargeIcon = "icon_large";
            eveningNotification.FireTime = eveningNotificationTime;
            AndroidNotificationCenter.SendNotification(eveningNotification, "eveningNotifsChannel_id");
        }
    }
}
