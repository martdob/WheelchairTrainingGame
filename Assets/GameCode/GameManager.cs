﻿using System.Collections;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.SceneManagement;
using WheelchairTrainingGame.Transition;

namespace WheelchairTrainingGame
{
    public class GameManager : MonoBehaviour
    {
        #region Managers

        [SerializeField]
        private TransitionManager transition;

        public TransitionManager Transition
        {
            get { return transition; }
        }

        #endregion

        #region Public methods

        public void LoadFirstScene()
        {
            StartCoroutine(DelayFirstLoad());
        }

        public void LoadScene(string sceneName)
        {
            StartCoroutine(DelaySceneLoad(sceneName));
        }

        public void Quit()
        {
            StartCoroutine(DelayQuit());
        }

        public void ReloadScene()
        {
            string currentSceneName = SceneManager.GetActiveScene().name;
            LoadScene(currentSceneName);
        }

        #endregion // Public methods

        #region Internal methods

        private void Awake()
        {
            if (Current != this)
            {
                Destroy(gameObject);
            }
        }

        private IEnumerator DelayFirstLoad()
        {
            yield return new WaitForEndOfFrame();

            AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(1);
            asyncLoad.allowSceneActivation = true;
            while (!asyncLoad.isDone)
            {
                yield return null;
            }
        }

        private IEnumerator DelayQuit()
        {
            transition.Open(TransitionType.Return);
            yield return new WaitWhile(() => transition.IsFading);

#if UNITY_EDITOR
            EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        }

        private IEnumerator DelaySceneLoad(string sceneName)
        {
            transition.Open(sceneName == "MainMenu" ? TransitionType.Return : TransitionType.Loading);
            yield return new WaitWhile(() => transition.IsFading);

            AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName);
            asyncLoad.allowSceneActivation = true;
            while (!asyncLoad.isDone)
            {
                yield return null;
            }
        }

        private void FindInternalreferences()
        {
            transition = GetComponentInChildren<TransitionManager>();
        }

        private void OnValidate()
        {
            FindInternalreferences();
        }
        private void Start()
        {
            FindInternalreferences();
        }

        #endregion // Internal methods

        #region Singleton Pattern

        private static GameManager current;

        public static GameManager Current
        {
            get
            {
                if (current == null)
                {
                    current = FindObjectOfType<GameManager>();

                    if (current == null)
                    {
                        Debug.LogErrorFormat("There is no game instance in the current scene ({0})", SceneManager.GetActiveScene().name);
                    }
                    else
                    {
                        DontDestroyOnLoad(current.gameObject);
                    }
                }

                return current;
            }
        }

        #endregion // Singleton Pattern
    }
}