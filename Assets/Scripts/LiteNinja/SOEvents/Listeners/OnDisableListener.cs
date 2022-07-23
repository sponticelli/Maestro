using UnityEngine;
using UnityEngine.Events;

namespace LiteNinja.SOEvents
{
    public class OnDisableListener : MonoBehaviour
    {
        [SerializeField] private UnityEvent disableEvent;

        private void OnDisable()
        {
            disableEvent.Invoke();
        }
    }
}