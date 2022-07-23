using UnityEngine;
using UnityEngine.Events;

namespace LiteNinja.SOEvents
{
    public class OnApplicationFocusListener : MonoBehaviour
    {
        [SerializeField] private UnityEvent focusEvent;
        [SerializeField] private UnityEvent unfocusEvent;
        
        private void OnApplicationFocus(bool focus)
        {
            if (focus)
            {
                focusEvent.Invoke();
            }
            else
            {
                unfocusEvent.Invoke();
            }
        }
    }
}