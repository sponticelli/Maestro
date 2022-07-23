using System;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace Maestro.Entities
{
    public class Mover : MonoBehaviour, IMove
    {

        private readonly List<IMove> _iMoves = new();
        
        private void OnEnable()
        {
            AddChildrenMoves();
            DispatchMovement(Vector2.zero, 0);
        }

        private void AddChildrenMoves()
        {
            _iMoves.Clear();
            var components = GetComponentsInChildren<IMove>(true);
            foreach (var component in components)
            {
                if (((Component)component).gameObject == this.gameObject) continue;
                _iMoves.Add(component);
            }
        }


        private void DispatchMovement(Vector2 direction, float speed)
        {
            foreach (var move in _iMoves)
            {
                move.Move(direction, speed);
            }
        }

        public void Move(Vector2 direction, float speed)
        {
            direction.Normalize();
            
            var angle = Angle(0, 0, direction.x, direction.y);
            
            var x = this.transform.position.x + Math.Cos((float) Math.PI / 180f * angle) * speed * UnityEngine.Time.deltaTime * 50f;
            var y = this.transform.position.y + Math.Sin((float) Math.PI / 180f * angle) * speed * UnityEngine.Time.deltaTime * 50f;

            transform.position = new Vector3((float)x, (float)y, (float)y/100f);
            DispatchMovement(direction, direction.x != 0 || direction.y != 0 ? speed : 0);
        }
        
        public static double Angle(double cx, double cy, double px, double py)
        {
            var num = 180.0 / Math.PI * Math.Atan2(py - cy, px - cx);
            if (num < 0.0)
                num += 360.0;
            return num;
        }
        
        public void SetPosition(Vector2 position)
        {
            transform.position = position;
            DispatchMovement(Vector2.zero, 0);
        }
    }
}