using UnityEngine;
using UnityEngine.UI;

namespace WheelchairTrainingGame.User
{
    public class UserWidget : MonoBehaviour
    {
        [SerializeField]
        private Text nameText;
        [SerializeField]
        private UserModel model;
        
        private void OnValidate()
        {
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
