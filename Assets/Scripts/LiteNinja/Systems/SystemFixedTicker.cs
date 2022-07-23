using System.Collections.Generic;
using UnityEngine;

namespace LiteNinja.Systems
{
    [AddComponentMenu("LiteNinja/Systems/Fixed Ticker")]
    public class SystemFixedTicker : MonoBehaviour, ISystemFixedTicker
    {
        private List<IFixedTickableSystem> _fixedTickableSystems;

        private void Awake()
        {
            Initialize();
        }

        
        public void Initialize()
        {
            _fixedTickableSystems = new List<IFixedTickableSystem>();
            _fixedTickableSystems.AddRange(GetComponentsInChildren<AFixedTickableSystem>());

            foreach (var system in _fixedTickableSystems)
            {
                system.Initialize();
            }

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