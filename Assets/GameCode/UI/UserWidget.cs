using UnityEngine;
using UnityEngine.UI;
using WheelchairTrainingGame.Activity;
using WheelchairTrainingGame.User;

namespace WheelchairTrainingGame.UI
{
    [RequireComponent(typeof(Button))]
    public class UserWidget : MonoBehaviour
    {
        private Button button;

        [SerializeField]
        MainMenuActivity activity;
        [SerializeField]
        private Text nameText;
        [SerializeField]
        private UserModel model;

        private void OnDisable()
        {
            button.onClick.RemoveAllListeners();
        }

        private void OnEnable()
        {
            button = GetComponent<Button>();
            button.onClick.AddListener(OnButtonClick);
        }

        private void OnButtonClick()
        {
            activity.SelectUser(model.Name);
        }

        private void OnValidate()
        {
            if (activity == null)
            {
                activity = FindObjectOfType<MainMenuActivity>();
            }
            if (nameText == null)
            {
                nameText = GetComponentInChildren<Text>();
            }
        }

        public void SetUserModel(UserModel user)
        {
            model = user;
            nameText.text = model.Name;
        }
    }
}
