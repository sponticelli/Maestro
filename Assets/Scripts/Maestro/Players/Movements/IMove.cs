using UnityEngine;

namespace Maestro.Players
{
    public interface IMove
    {
        void Move(Vector2 direction, float speed);
    }
}