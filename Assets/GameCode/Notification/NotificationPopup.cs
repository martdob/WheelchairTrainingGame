using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace WheelchairTrainingGame.Notification
{
    [RequireComponent(typeof(Animator))]
    public class NotificationPopup : MonoBehaviour
    {
        [Header("References")]
        [SerializeField]
        private Text text;

        [Header("Notification")]
        [SerializeField]
        protected LogType type;
        [SerializeField]
        [Range(0.1f, 4.0f)]
        private float fadeInTimeFactor = 1.0f;
        [SerializeField]
        [Range(0.1f, 4.0f)]
        private float fadeOutTimeFactor = 1.0f;
        [SerializeField]
        private float duration = 4.0f;
        [SerializeField]
        private string message;

        private Animator animator;
        private bool isFading = true;

        public LogType Type
        {
            get { return type; }
        }

        public bool IsFading
        {
            get { return isFading; }
        }

        public string Message
        {
            get { return message; }
            set
            {
                message = value;
                if (text != null)
                    text.text = message;
            }
        }

        private IEnumerator DelayDuration()
        {
            yield return new WaitForSeconds(duration);

            Close();
        }

        private void FindInternalReferences()
        {
            animator = GetComponent<Animator>();
        }

        private void OnValidate()
        {
            FindInternalReferences();
            isFading = true;
        }

        private void OnWindowClose()
        {
            isFading = false;
            Destroy(gameObject);
        }

        private void OnWindowOpen()
        {
            isFading = false;
            StartCoroutine(DelayDuration());
        }

        private void Start()
        {
            FindInternalReferences();
            Open();
        }

        public void Close()
        {
            if (isFading) return;

            StopAllCoroutines();

            isFading = true;
            animator.SetFloat("CloseTimeFactor", fadeOutTimeFactor);
            animator.SetTrigger("Close");
        }

        public void Open()
        {
            isFading = true;
            animator.SetFloat("OpenTimeFactor", fadeInTimeFactor);
            animator.SetTrigger("Open");
        }

        public void Restore()
        {
            StopAllCoroutines();
            StartCoroutine(DelayDuration());
        }
    }
}
