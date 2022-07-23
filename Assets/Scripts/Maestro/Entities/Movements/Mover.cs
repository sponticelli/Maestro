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
            transform.position = ((Vector2)transform.position + direction * speed * Time.deltaTime);
            DispatchMovement(direction, direction.x != 0 || direction.y != 0 ? speed : 0);
        }
        
        public void SetPosition(Vector2 position)
        {
            transform.position = position;
            DispatchMovement(Vector2.zero, 0);
        }
    }
}