using System.Collections.Generic;
using UnityEngine;
using NotImplementedException = System.NotImplementedException;

namespace LiteNinja.Systems
{
    [AddComponentMenu("LiteNinja/Systems/Ticker")]
    public class SystemTicker : MonoBehaviour, ISystemTicker
    {
        private List<ITickableSystem> _tickableSystems;
        private void Awake()
        {
            Initialize();
        }

        public void Initialize()
        {
            _tickableSystems = new List<ITickableSystem>();
            _tickableSystems.AddRange(GetComponentsInChildren<ATickableSystem>());

            foreach (var system in _tickableSystems)
            {
                system.Initialize();
            }

 
        }
        
        private void Update()
        {
            Tick(Time.deltaTime);
        }
        
        public void Tick(float deltaTime)
        {
            foreach (var system in _tickableSystems)
            {
                system.Tick(deltaTime);
            }
        }
    }
}