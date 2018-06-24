using UnityEngine;

namespace WheelchairTrainingGame.Transition
{
    [RequireComponent(typeof(Animator))]
    public class TransitionScreen : MonoBehaviour
    {
        [Header("Type")]
        [SerializeField]
        private TransitionType type;

        [Header("Time")]
        [SerializeField]
        [Range(0.1f, 4.0f)]
        private float fadeInTimeFactor = 1.0f;
        [SerializeField]
        [Range(0.1f, 4.0f)]
        private float fadeOutTimeFactor = 1.0f;

        private Animator animator;
        private bool isFading = true;

        public bool IsFading
        {
            get { return isFading; }
        }

        public TransitionType Type
        {
            get { return type; }
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
        }

        private void Start()
        {
            FindInternalReferences();
            Open();
        }

        public void Close()
        {
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
    }
}
