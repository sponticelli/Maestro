using LiteNinja.SOEvents;
using LiteNinja.Systems;
using UnityEngine;

namespace Maestro.Systems
{
    [AddComponentMenu("Maestro/Systems/Input System")]
    public class InputSystem : AFullTickableSystem
    {
        [Header("Listened Events")]
        [SerializeField]
        private BoolEvent pauseEvent;
        
        [Header("Raised Events")]
        [SerializeField] 
        private Vector2Event _mouseMovementEvent;
        [SerializeField]
        private Vector2Event _leftMouseDown;
        [SerializeField]
        private Vector2Event _rightMouseDown;
        [SerializeField]
        private Vector2Event _leftMouseUp;
        [SerializeField]
        private Vector2Event _rightMouseUp;
        
        private Camera _camera;
        private Vector3 _lastMousePosition;

        protected override void OnLoadSystem()
        {
            pauseEvent?.Register(Pause);
            _camera = Camera.main; //TODO find a better way to get the camera (maybe a camera manager that raises an event?)
        }

        protected override void OnUnloadSystem()
        {
            pauseEvent?.Unregister(Pause);
        }

        protected override void OnTick(float deltaTime)
        {
            if (Input.GetMouseButtonDown(0))
            {
                _leftMouseDown.Raise(_camera.ScreenToWorldPoint(_lastMousePosition));
            }
            
            if (Input.GetMouseButtonUp(0))
            {
                _leftMouseUp.Raise(_camera.ScreenToWorldPoint(_lastMousePosition));
            }
            
            if (Input.GetMouseButtonDown(1))
            {
                _rightMouseDown.Raise(_camera.ScreenToWorldPoint(_lastMousePosition));
            }
            
            if (Input.GetMouseButtonUp(1))
            {
                _rightMouseUp.Raise(_camera.ScreenToWorldPoint(_lastMousePosition));
            }
            
        }

        protected override void OnFixedTick(float fixedDeltaTime)
        {
            UpdateMousePosition();
        }

        private void UpdateMousePosition()
        {
            var mousePosition = Input.mousePosition;
            mousePosition.z = 0;

            if (_lastMousePosition == mousePosition) return;
            
            var mouseWorldPoint = _camera.ScreenToWorldPoint(mousePosition);
            _mouseMovementEvent?.Raise(mouseWorldPoint);
            _lastMousePosition = mousePosition;
        }
        
    }
}