using System;
using LiteNinja.MathUtils;
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
        private double _previousAngle;
        private double _currentAngle;

        private void OnEnable()
        {
            if (!_mover) _mover = GetComponent<Mover>();
            _target = transform.position;
            _currentSpeed = 0f;
            _previousAngle = 0;
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
            _currentAngle = MathHelper.Angle(Vector3.zero, direction);
            ChangeDirectionSpeed();
            _currentSpeed += _acceleration;
            if (_currentSpeed > _maxSpeed) _currentSpeed = _maxSpeed;

            _mover.Move(_target, direction, _currentSpeed);
            _previousAngle = _currentAngle;
        }

        private void ChangeDirectionSpeed()
        {
            var deltaAngle = _currentAngle - _previousAngle;
            if (deltaAngle > 180) deltaAngle -= 360;
            if (deltaAngle < -180) deltaAngle += 360;
            deltaAngle = Math.Abs(deltaAngle);
            
            _currentSpeed *= Mathf.Lerp(1f, 0f, (float)deltaAngle / 180f);
        }
    }
}