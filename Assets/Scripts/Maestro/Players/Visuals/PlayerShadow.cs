using LiteNinja.MathUtils;
using UnityEngine;

namespace Maestro.Players
{
    public class PlayerShadow : MonoBehaviour, IMove
    {
        public void Move(Vector2 direction, float speed)
        {
            //rotate the shadow to match the direction of the player
            var angle = (float)MathHelper.Angle(Vector2.zero, direction);
            transform.rotation = Quaternion.Euler(0, 0, angle -90f);
        }
    }
}