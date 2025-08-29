using Gameplay;
using Gameplay.Systems;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace UI
{
    public class HpBarViewsSystem : MonoBehaviour
    {
        [SerializeField] private Canvas _canvas;
        [SerializeField] private HpBarView _hpBarViewPrefab;
        [SerializeField] private float _smoothingSpeed = 20f;
        private IInstantiator _instantiator;
        private UnitHudTracker _unitHudTracker;
        private Camera _camera;
        private readonly Dictionary<IStatHudProvider, HpBarView> _bars = new Dictionary<IStatHudProvider, HpBarView>();
        private readonly List<IStatHudProvider> _toRemove = new List<IStatHudProvider>(20);

        [Inject]
        private void Construct(IInstantiator instantiator,
                               UnitHudTracker unitHudTracker,
                               Camera camera)
        {
            _instantiator = instantiator;
            _unitHudTracker = unitHudTracker;
            _camera = camera;
        }

        private void LateUpdate()
        {
            foreach (var kvp in _bars)
            {
                if (!_unitHudTracker.entities.Contains(kvp.Key))
                {
                    Destroy(kvp.Value.gameObject);
                    _toRemove.Add(kvp.Key);
                }
            }

            foreach (var key in _toRemove)
                _bars.Remove(key);
            _toRemove.Clear();

            foreach (var provider in _unitHudTracker.entities)
            {
                if (!_bars.ContainsKey(provider))
                {
                    _bars[provider] = CreateViewBar(provider);
                }

                var hpBar = _bars[provider];
                Vector3 screenPos = _camera.WorldToScreenPoint(provider.position);

                if (screenPos.z > 0)
                {
                    hpBar.gameObject.SetActive(true);
                    hpBar.rectTransform.position = Vector3.Lerp(hpBar.rectTransform.position, screenPos, _smoothingSpeed * Time.deltaTime);
                }
                else
                {
                    hpBar.gameObject.SetActive(false);
                }
            }
        }

        private HpBarView CreateViewBar(IStatHudProvider provider)
        {
            var bar = _instantiator.InstantiatePrefabForComponent<HpBarView>(_hpBarViewPrefab, _canvas.transform);
            bar.Init(provider);
            return bar;
        }
    }
}