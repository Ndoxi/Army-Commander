using Gameplay.Systems;
using TMPro;
using UnityEngine;
using Zenject;

namespace UI
{
    public class CurrencyView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _textMesh;
        private CurrencySystem _currencySystem;

        [Inject]
        private void Construct(CurrencySystem currencySystem)
        {
            _currencySystem = currencySystem;
        }

        private void Awake()
        {
            UpdateView(0);
        }

        private void OnEnable()
        {
            _currencySystem.onUpdate += UpdateView;
        }

        private void OnDisable()
        {
            _currencySystem.onUpdate += UpdateView;
        }

        private void UpdateView(int value)
        {
            _textMesh.text = value.ToString();
        }
    }
}