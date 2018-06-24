using System;
using UnityEngine;

namespace WheelchairTrainingGame.Transition
{
    public class TransitionManager : MonoBehaviour
    {
        [Header("References")]
        [SerializeField]
        private TransitionScreen[] templates;
        
        private TransitionScreen current;

        public bool IsFading
        {
            get
            {
                if (Visible)
                    return current.IsFading;
                else
                    return false;
            }
        }

        public bool Visible
        {
            get { return current != null; }
        }

        private void FindInternalReferences()
        {
            templates = GetComponentsInChildren<TransitionScreen>(true);
        }

        private void OnValidate()
        {
            FindInternalReferences();
        }

        private void Start()
        {
            FindInternalReferences();
        }

        public void Close()
        {
            if (Visible)
                current.GetComponent<TransitionScreen>().Close();
        }

        public void CompleteClose()
        {
            if (Visible)
            {
                Destroy(current.gameObject);
                current = null;
            }
        }

        public void Open(TransitionType type)
        {
            TransitionScreen screenTemplate = Array.Find(templates, template => template.Type == type);
            if (screenTemplate != null)
            {
                GameObject screen = Instantiate(screenTemplate.gameObject, transform, false);
                screen.SetActive(true);

                current = screen.GetComponent<TransitionScreen>();
            }
        }
    }
}
