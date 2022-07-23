using UnityEngine;
using UnityEngine.Events;

namespace LiteNinja.SOEvents
{
    public class OnApplicationQuitListener : MonoBehaviour
    {
        [SerializeField] private UnityEvent quitEvent;

        private void OnApplicationQuit()
        {
            quitEvent.Invoke();
        }
    }
}