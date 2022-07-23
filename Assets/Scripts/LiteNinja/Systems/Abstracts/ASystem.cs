using UnityEngine;

namespace LiteNinja.Systems
{
    public abstract class ASystem : MonoBehaviour, ISystem
    {
        protected void Awake()
        {
            Initialize();
        }

        public abstract void Initialize();
    }
}