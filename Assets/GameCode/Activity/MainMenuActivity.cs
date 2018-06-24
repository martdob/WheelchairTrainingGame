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

            if (Input.GetKeyDown(KeyCode.I))
            {
                Debug.Log("Je suis une info à " + Time.timeSinceLevelLoad);
            }

            if (Input.GetKeyDown(KeyCode.W))
            {
                Debug.LogWarning("Je suis un avertissement à " + Time.timeSinceLevelLoad);
            }

            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.LogError("Je suis une erreur à " + Time.timeSinceLevelLoad);
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
    }
}
