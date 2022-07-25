using System;
using LiteNinja.MathUtils;
using UnityEngine;

namespace Maestro.Players
{
    public class PlayerDust : MonoBehaviour, IMove
    {
        [SerializeField] private ParticleSystem _particleSystem;
        
        
        private double _currentAngle;
        private double _previousAngle;

        private void Awake()
        {
            if (!_particleSystem)
                _particleSystem = GetComponent<ParticleSystem>();
        }

        public void Move(double angle, Vector2 direction, float speed)
        {
            _currentAngle = angle;
            var deltaAngle = _currentAngle - _previousAngle;
            if (deltaAngle > 180) deltaAngle -= 360;
            if (deltaAngle < -180) deltaAngle += 360;
            deltaAngle = Math.Abs(deltaAngle);
            
            if (deltaAngle > 30)
            {
                if (!_particleSystem.isPlaying)
                    _particleSystem.Play();
            }
            
            _previousAngle = _currentAngle;
        }
    }
}