using LiteNinja.SOEvents;
using LiteNinja.Systems;
using UnityEngine;

namespace Maestro.Systems
{
    [AddComponentMenu("Maestro/Systems/Pause System")]
    public class PauseSystem : ASystem
    {
        [Header("Listened Events")]
        [SerializeField] private GameEvent _requestPause;
        
        [Header("Raised Events")]
        [SerializeField] private BoolEvent _pauseEvent;

        private bool _isPaused;
        
        protected override void OnLoadSystem()
        {
            _requestPause?.Register(OnRequestPause);
        }

        protected override void OnUnloadSystem()
        {
            _isPaused = false;
        }

        private void SetPaused(bool state)
        {
            _isPaused = state;
            _pauseEvent?.Raise(state);
        }
        
        private void OnRequestPause()
        {
            _isPaused = !_isPaused;
            SetPaused(_isPaused);
        }
        
    }
}