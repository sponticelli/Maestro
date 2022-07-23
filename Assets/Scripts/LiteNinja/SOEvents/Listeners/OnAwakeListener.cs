using UnityEngine;
using UnityEngine.Events;

namespace LiteNinja.SOEvents
{
    public class OnAwakeListener : MonoBehaviour
    {
        [SerializeField] private UnityEvent awakeEvent;

        private void Awake()
        {
            awakeEvent.Invoke();
        }
    }
    
}