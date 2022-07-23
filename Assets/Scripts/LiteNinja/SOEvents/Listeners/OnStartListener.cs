using UnityEngine;
using UnityEngine.Events;

namespace LiteNinja.SOEvents
{
    public class OnStartListener : MonoBehaviour
    {
        [SerializeField] private UnityEvent startEvent;

        private void Start()
        {
            startEvent.Invoke();
        }
    }
}