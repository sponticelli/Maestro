using UnityEngine;

namespace Maestro.Players
{
    public interface IMove
    {
        void Move(double angle, Vector2 direction, float speed);
    }
}