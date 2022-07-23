using System;
using UnityEngine;

namespace Maestro.Entities
{
    public class HumanBrain : MonoBehaviour, IBrain
    {
        [SerializeField] private Mover _mover;

        [SerializeField] private float _maxSpeed = 5f;
        [SerializeField] private float _acceleration = 1f;

        private float _currentSpeed;
        private Vector2 _target;

        private void OnEnable()
        {
            if (!_mover) _mover = GetComponent<Mover>();
            _target = transform.position;
            _currentSpeed = 0f;
            _mover.SetPosition(transform.position);
        }

        private void Update()
        {
            Think();
        }

        public void Think()
        {
            //Do nothing, because humans are dumb ;)
            Move();
        }

        public void SetTarget(Vector2 target)
        {
            _target = target;
        }


        private void Move()
        {
            //calculate the direction to the target
            var direction = _target - (Vector2)transform.position;
            var magnitude = direction.magnitude;
            if (magnitude > 0.1f)
            {
                //calculate the speed we should be moving at
                _currentSpeed += _acceleration * Time.deltaTime;
                if (_currentSpeed > _maxSpeed) _currentSpeed = _maxSpeed;
            }
            else
            {
                //stop moving
                _currentSpeed = 0f;
            }

            _mover.Move(direction, _currentSpeed);
        }
    }
}