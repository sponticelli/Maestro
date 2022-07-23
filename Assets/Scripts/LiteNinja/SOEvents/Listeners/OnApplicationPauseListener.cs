using UnityEngine;
using UnityEngine.Events;

namespace LiteNinja.SOEvents
{
    public class OnApplicationPauseListener : MonoBehaviour
    {
        [SerializeField] private UnityEvent pauseEvent;
        [SerializeField] private UnityEvent unpauseEvent;
        
        private void OnApplicationPause(bool pause)
        {
            if (pause)
            {
                pauseEvent.Invoke();
            }
            else
            {
                unpauseEvent.Invoke();
            }
        }
    }
}