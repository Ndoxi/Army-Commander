using Gameplay;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class EndGameView : MonoBehaviour
    {
        public event Action onRestart;

        [SerializeField] private Button _restartButton;
        [SerializeField] private RectTransform _root;
        [SerializeField] private RectTransform _winView;
        [SerializeField] private RectTransform _loseView;

        private void OnEnable()
        {
            _restartButton.onClick.AddListener(Restart);
        }

        private void OnDisable()
        {
            _restartButton.onClick.RemoveListener(Restart);
        }

        public void Show(EndGameType endGameType)
        {
            _root.gameObject.SetActive(true);
            _winView.gameObject.SetActive(endGameType == EndGameType.Win);
            _loseView.gameObject.SetActive(endGameType == EndGameType.Lose);
        }

        public void Hide()
        {
            _root.gameObject.SetActive(false);
        }

        private void Restart()
        {
            onRestart?.Invoke();
        }
    }
}