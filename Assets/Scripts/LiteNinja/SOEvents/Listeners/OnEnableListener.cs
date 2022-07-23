using UnityEngine;
using UnityEngine.Events;

namespace LiteNinja.SOEvents
{
    public class OnEnableListener : MonoBehaviour
    {
        [SerializeField] private UnityEvent enableEvent;

        private void OnEnable()
        {
            enableEvent.Invoke();
        }
    }
}