using UnityEngine;

namespace LiteNinja.Systems
{
    public abstract class ASystem : MonoBehaviour, ISystem
    {
        private bool _isInitialized;

        protected void Awake()
        {
            Initialize();
        }

        public void Initialize()
        {
            if (_isInitialized) return;

            OnLoadSystem();
            _isInitialized = true;
        }

        public void Deinitialize()
        {
            if (!_isInitialized) return;

            OnUnloadSystem();
            _isInitialized = false;
        }

        protected abstract void OnLoadSystem();
        protected abstract void OnUnloadSystem();
    }
}