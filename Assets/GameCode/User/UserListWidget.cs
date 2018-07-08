using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace WheelchairTrainingGame.User
{
    public class UserListWidget : MonoBehaviour
    {
        [SerializeField]
        private UserList userList;

        [SerializeField]
        private GameObject femaleTemplate;
        [SerializeField]
        private GameObject maleTemplate;

        public List<UserWidget> widgets = new List<UserWidget>();

        private void Start()
        {
            foreach(UserModel model in userList.Users)
            {
                GameObject userObject = Instantiate(model.Gender == Gender.Female ? femaleTemplate : maleTemplate, transform, false);
                userObject.SetActive(true);

                UserWidget userWidget = userObject.GetComponent<UserWidget>();
                userWidget.SetUserModel(model);
                widgets.Add(userWidget);
            }


            EventSystem.current.SetSelectedGameObject(widgets[0].gameObject);
        }
    }
}