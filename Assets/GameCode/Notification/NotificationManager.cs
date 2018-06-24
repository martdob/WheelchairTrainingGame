using System;
using System.Collections.Generic;
using UnityEngine;

namespace WheelchairTrainingGame.Notification
{
    public class NotificationManager : MonoBehaviour
    {
        [Header("References")]
        [SerializeField]
        private NotificationPopup[] templates = new NotificationPopup[3];

        [Header("Options")]
        [SerializeField]
        [Range(4, 10)]
        private int maxNotifications = 8;
        [SerializeField]
        private List<NotificationPopup> notifications = new List<NotificationPopup>();

        private void BroadcastLog(string message, string stackTrace, LogType type)
        {            
            notifications.RemoveAll(item => item == null);

            NotificationPopup duplicate = notifications.Find(popup => popup.Type == type && popup.Message == message);
            if (duplicate != null)
            {
                duplicate.Restore();
            }
            else
            {
                NotificationPopup popupTemplate = Array.Find(templates, template => template.Type == type);
                if (popupTemplate != null)
                {
                    if (notifications.Count >= maxNotifications - 1)
                    {
                        for (int i = 0; i <= notifications.Count - maxNotifications; i++)
                        {
                            Destroy(notifications[i].gameObject);
                        }
                    }
                    
                    GameObject popupObject = Instantiate(popupTemplate.gameObject, transform, false);
                    popupObject.SetActive(true);

                    NotificationPopup notification = popupObject.GetComponent<NotificationPopup>();
                    notification.Message = message;

                    notifications.Add(notification);
                }
            }
        }

        private void FindInternalReferences()
        {
            templates = GetComponentsInChildren<NotificationPopup>(true);
        }

        private void OnValidate()
        {
            FindInternalReferences();
        }

        private void Start()
        {
            FindInternalReferences();
        }

        public void Initialize()
        {
            Application.logMessageReceived += BroadcastLog;
        }

        public void Terminate()
        {
            Application.logMessageReceived -= BroadcastLog;
        }
    }
}
