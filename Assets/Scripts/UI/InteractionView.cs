using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class InteractionView : MonoBehaviour
    {
        public event Action onConfirm;
        [SerializeField] private Button _interactButton;
        [SerializeField] private RectTransform _root;

        private void Awake()
        {
            Hide();
        }

        private void OnEnable()
        {
            _interactButton.onClick.AddListener(Interact);
        }

        private void OnDisable()
        {
            _interactButton.onClick.RemoveListener(Interact);
        }

        public void Show()
        {
            _root.gameObject.SetActive(true);
        }

        public void Hide()
        {
            _root.gameObject.SetActive(false);
        }

        private void Interact()
        {
            onConfirm?.Invoke();
        }
    }
}