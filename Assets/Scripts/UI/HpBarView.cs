using Gameplay;
using Gameplay.Stats;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    [RequireComponent(typeof(RectTransform))]
    public partial class HpBarView : MonoBehaviour
    {
        public RectTransform rectTransform => _rectTransform;

        [SerializeField] private Image _fillImage;
        [SerializeField] private FactionFillImage[] _factionImages; 
        private RectTransform _rectTransform;
        private Stat _stat;

        public void Init(IStatHudProvider provider)
        {
            _stat = provider.stat;

            _fillImage.sprite = GetFactionSprite(provider.faction);
            _fillImage.type = Image.Type.Filled;

            UpdateView(_stat.value);
            _stat.onValueUpdated -= UpdateView;
            _stat.onValueUpdated += UpdateView;
        }

        private void OnEnable()
        {
            if (_stat != null)
            {
                UpdateView(_stat.value);
                _stat.onValueUpdated += UpdateView;
            }
        }

        private void OnDisable()
        {
            if (_stat != null)
            {
                _stat.onValueUpdated -= UpdateView;
            }
        }

        private void Awake()
        {
            _rectTransform = GetComponent<RectTransform>();
        }

        private void UpdateView(float value)
        {
            _fillImage.fillAmount = value / _stat.baseValue;
        }

        private Sprite GetFactionSprite(Faction faction)
        {
            return _factionImages.First(image => image.faction == faction).sprite;
        }
    }
}