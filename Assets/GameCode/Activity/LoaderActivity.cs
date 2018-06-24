using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;

namespace WheelchairTrainingGame.Activity
{
    public class LoaderActivity : MonoBehaviour
    {
        private IEnumerator Start()
        {
            yield return new WaitUntil(() => SplashScreen.isFinished);

            GameManager.Current.LoadFirstScene();
        }
    }
}