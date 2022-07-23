using System.Collections.Generic;
using UnityEngine;

namespace LiteNinja.Systems
{
    
    /// <summary>
    /// Add all the systems (tickable, fixedTickable, fullTickable) of the children
    /// Initialize the systems
    /// Update the systems
    /// </summary>
    public class SystemTicker : MonoBehaviour, ISystemFullTicker
    {
        private List<ITickableSystem> _tickableSystems;
        private List<IFixedTickableSystem> _fixedTickableSystems;
        private List<IFullTickableSystem> _fullTickableSystems;


        private void Awake()
        {
            Initialize();
        }

        public void Initialize()
        {
            _tickableSystems = new List<ITickableSystem>();
            _fixedTickableSystems = new List<IFixedTickableSystem>();
            _fullTickableSystems = new List<IFullTickableSystem>();

            _tickableSystems.AddRange(GetComponentsInChildren<ATickableSystem>());
            _fixedTickableSystems.AddRange(GetComponentsInChildren<AFixedTickableSystem>());
            _fullTickableSystems.AddRange(GetComponentsInChildren<AFullTickableSystem>());

            foreach (var system in _tickableSystems)
            {
                system.Initialize();
            }

            foreach (var system in _fixedTickableSystems)
            {
                system.Initialize();
            }

            foreach (var system in _fullTickableSystems)
            {
                system.Initialize();
            }
        }
        
        private void Update()
        {
            Tick(Time.deltaTime);
        }
        
        private void FixedUpdate()
        {
            FixedTick(Time.fixedDeltaTime);
        }

        public void Tick(float deltaTime)
        {
            foreach (var system in _tickableSystems)
            {
                system.Tick(deltaTime);
            }

            foreach (var system in _fullTickableSystems)
            {
                system.Tick(deltaTime);
            }
        }

        public void FixedTick(float fixedDeltaTime)
        {
            foreach (var system in _fixedTickableSystems)
            {
                system.FixedTick(fixedDeltaTime);
            }

            foreach (var system in _fullTickableSystems)
            {
                system.FixedTick(fixedDeltaTime);
            }
        }
    }
}