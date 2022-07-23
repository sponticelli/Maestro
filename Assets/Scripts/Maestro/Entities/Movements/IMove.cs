using UnityEngine;

namespace Maestro.Entities
{
    public interface IMove
    {
        void Move(Vector2 direction, float speed);
    }
}