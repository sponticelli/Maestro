using System.Collections.Generic;
using UnityEngine;

namespace LiteNinja.Systems
{
    [AddComponentMenu("LiteNinja/Systems/Fixed Ticker")]
    public class SystemFixedTicker : MonoBehaviour, ISystemFixedTicker
    {
        private List<IFixedTickableSystem> _fixedTickableSystems;
        private bool _isInitialized;
        

        private void Awake()
        {
            Initialize();
        }

        private void OnEnable()
        {
            Initialize();
        }

        private void OnDisable()
        {
            Deinitialize();
        }


        public void Initialize()
        {
            if (_isInitialized) return;
            _fixedTickableSystems = new List<IFixedTickableSystem>();
            _fixedTickableSystems.AddRange(GetComponentsInChildren<AFixedTickableSystem>());

            foreach (var system in _fixedTickableSystems)
            {
                system.Initialize();
            }
            _isInitialized = true;
        }

        public void Deinitialize()
        {
            foreach (var system in _fixedTickableSystems)
            {
                system.Deinitialize();
            }
            _isInitialized = false;
        }

        private void FixedUpdate()
        {
            FixedTick(Time.fixedDeltaTime);
        }
        
        public void FixedTick(float fixedDeltaTime)
        {
            foreach (var system in _fixedTickableSystems)
            {
                system.FixedTick(fixedDeltaTime);
            }
        }
    }
}