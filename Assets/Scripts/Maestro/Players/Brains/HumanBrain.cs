using System;
using UnityEngine;

namespace Maestro.Players
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
            _currentSpeed = _maxSpeed;
            //TODO implement acceleration
            _mover.Move(direction, _currentSpeed);
        }
    }
}