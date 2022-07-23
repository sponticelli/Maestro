using UnityEngine;
using UnityEngine.Events;

namespace LiteNinja.SOEvents
{
    public class OnDestroyListener : MonoBehaviour
    {
        [SerializeField] private UnityEvent destroyEvent;

        private void OnDestroy()
        {
            destroyEvent.Invoke();
        }
    }
}