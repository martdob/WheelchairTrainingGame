using UnityEngine;
using UnityEngine.EventSystems;

namespace WheelchairTrainingGame.Activity
{
    public class MainMenuActivity : MonoBehaviour
    {
        private void Start()
        {
            if (GameManager.Current.Transition.Visible)
            {
                GameManager.Current.Transition.Close();
            }
        }
        
        private void Update()
        {
            if(Input.GetButtonDown("B"))
            {
                QuitApplication();
            }
        }

        public void LoadDemoScene(string sceneName)
        {
            GameManager.Current.LoadScene(sceneName);
        }

        public void QuitApplication()
        {
            EventSystem.current.SetSelectedGameObject(null);
            GameManager.Current.Quit();
        }

        public void SelectUser(string userName)
        {
            Debug.LogFormat("Utilisateur sélectionné : {0}", userName);
        }
    }
}
