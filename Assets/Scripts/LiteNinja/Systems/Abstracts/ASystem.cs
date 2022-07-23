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

        protected abstract void OnLoadSystem();
    }
}