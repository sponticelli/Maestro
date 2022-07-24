using System;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using LiteNinja.MathUtils;

namespace Maestro.Players
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
                if (((Component)component).gameObject == gameObject) continue;
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
            const double piOver180 = Math.PI / 180; //TODO Move to MathHelper
            direction.Normalize();

            var angle = MathHelper.Angle(0, 0, direction.x, direction.y);

            //TODO 50f is the FPS - move to a scriptable object config  
            var x = transform.position.x +
                    Math.Cos(piOver180 * angle) * speed * Time.deltaTime * 50f;
            var y = transform.position.y +
                    Math.Sin(piOver180 * angle) * speed * Time.deltaTime * 50f;

            transform.position = new Vector3((float)x, (float)y, (float)y / 100f);
            DispatchMovement(direction, direction.x != 0 || direction.y != 0 ? speed : 0);
        }

 
        public void SetPosition(Vector2 position)
        {
            transform.position = position;
            DispatchMovement(Vector2.zero, 0);
        }
    }
}